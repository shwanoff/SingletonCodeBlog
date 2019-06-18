using System;

namespace SingletonCodeBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Проверка стандартной реализации.
            // Можно создать несколько экземпляров класса
            // которые будут конфликтовать между собой.
            var text1 = new FileWorker();
            var text2 = new FileWorker();

            text1.WriteText("Hello, World!");
            text2.WriteText("Hi, Bro!");

            text1.Save();
            text2.Save();

            var singleton1 = FileWorkerSingleton.Instance;
            var singleton2 = FileWorkerSingleton.Instance;

            // var singleton = new FileWorkerSingleton(); // Создать новый экземпляр одиночки нельзя!

            singleton1.WriteText("Hello, World!");
            singleton2.WriteText("Hi, Bro!");

            singleton1.Save();
            singleton2.Save();
        }
    }
}
