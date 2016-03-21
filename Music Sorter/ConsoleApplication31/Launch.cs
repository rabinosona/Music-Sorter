using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication31
{
    class Launch
    {
        static void Main(string[] args)
        {
            Worker work = new Worker(); // work examplar + user's input
            string path_user;

            Console.WriteLine("Hello, user! Enter the path to the music folder you want to sort.");
            Console.WriteLine("Remember! You can sort only mp3 and flac formats. If you want to sort more formats, add them by changing the source code.");
            path_user = Console.ReadLine();
            work.Search(path_user); // using classes
            work.Sort();
            Console.WriteLine("Process ended. Press ENTER to continue...");
            Console.ReadKey(); // terminate process
        }
    }
}
