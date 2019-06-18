using System;
using System.IO;

namespace SingletonCodeBlog
{
    /// <summary>
    /// Класс для работы с текстом. Сохранение изменений в файл 
    /// выполняется только по запросу Save.
    /// До этого изменения хранятся в динамической памяти.
    /// </summary>
    public class FileWorker
    {
        /// <summary>
        /// Путь к файлу записи.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Содержимое файла в динамической памяти.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Создать новый экземпляр для работы с текстом.
        /// </summary>
        public FileWorker()
        {
            FilePath = "test.txt";
            ReadTextFromFile();
        }

        /// <summary>
        /// Добавить текст в файл (без сохранения в постоянную память).
        /// </summary>
        /// <param name="text"> Добавляемый текст. </param>
        public void WriteText(string text)
        {
            Text += text;
        }

        /// <summary>
        /// Сохранить текст в файл.
        /// </summary>
        public void Save()
        {
            using (var writer = new StreamWriter(FilePath, false))
            {
                writer.WriteLine(Text);
            }
        }

        /// <summary>
        /// Прочитать данные из файла.
        /// </summary>
        private void ReadTextFromFile()
        {
            if(!File.Exists(FilePath))
            {
                Text = "";
            }
            else
            {
                using (var reader = new StreamReader(FilePath))
                {
                    Text = reader.ReadToEnd();
                }
            }
        }
    }
}
