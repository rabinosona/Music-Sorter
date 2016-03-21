using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication31
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TagLib;
    using System.IO;

        public class Worker
        {
            string class_path; // user's path for in-class use

            public string[] found_flacs; // for giving info through the class (don't mix these two arrays!)
            string[] found_mp3s;

            public void Search(string path)
            {
            try
            {
                string[] found = Directory.GetFiles(path, "*.mp3");
                string[] found_flac = Directory.GetFiles(path, "*.flac"); // find all .mp3 and .flac files in the folder.
                found_mp3s = found;
                found_flacs = found_flac; // assign local values to class variables to bring them into the class scope
                class_path = path;
            }
            catch (Exception E)
            {
                Console.WriteLine("Wrong input. \n Relaunch the program.");
                Console.WriteLine(E.ToString());
            }
            }

            public void Sort()
            {
            try
            {
                TagLib.File file;
                for (int i = 0; i < found_flacs.Length; i++)
                {
                    file = TagLib.File.Create(found_flacs[i]);
                    string filename = found_flacs[i].Substring(class_path.Length + 1); // name of the file
                    Directory.CreateDirectory(class_path + @"\" + file.Tag.FirstGenre); // create directory by genre
                    string newpath = Path.Combine(class_path, file.Tag.FirstGenre);
                    newpath = Path.Combine(newpath, file.Tag.FirstPerformer); // create path for performer
                    Directory.CreateDirectory(newpath);
                    Console.WriteLine(Path.Combine(class_path, found_flacs[i])); // to see that all is working
                    Console.WriteLine(newpath + @"\" + file.Tag.FirstGenre);
                    newpath = Path.Combine(newpath, file.Tag.Album); // album
                    Directory.CreateDirectory(newpath);
                    System.IO.File.SetAttributes(found_flacs[i], FileAttributes.Normal);
                    System.IO.File.Copy(Path.Combine(class_path, filename), Path.Combine(newpath, filename)); // copy to the new folder
                    System.IO.File.SetAttributes(found_flacs[i], FileAttributes.Normal); // to avoid "Access denied" error
                    System.IO.File.Delete(found_flacs[i]); // delete files
                }
                for (int i = 0; i < found_mp3s.Length; i++)
                {
                    file = TagLib.File.Create(found_mp3s[i]);
                    string filename = found_mp3s[i].Substring(class_path.Length + 1); // name of the file
                    Directory.CreateDirectory(class_path + @"\" + file.Tag.FirstGenre); // create directory by genre
                    string newpath = Path.Combine(class_path, file.Tag.FirstGenre);
                    newpath = Path.Combine(newpath, file.Tag.FirstPerformer); // create path for performer
                    Directory.CreateDirectory(newpath);
                    Console.WriteLine(Path.Combine(class_path, found_mp3s[i])); // to see that all is working
                    Console.WriteLine(newpath + @"\" + file.Tag.FirstGenre);
                    newpath = Path.Combine(newpath, file.Tag.Album);
                    Directory.CreateDirectory(newpath);
                    System.IO.File.SetAttributes(found_mp3s[i], FileAttributes.Normal);
                    System.IO.File.Copy(Path.Combine(class_path, filename), Path.Combine(newpath, filename)); // copy to new folder
                    System.IO.File.SetAttributes(found_mp3s[i], FileAttributes.Normal); // to avoid "Access denied" error
                    System.IO.File.Delete(found_mp3s[i]); // delete
                }
            }
            catch (Exception E)
            {
                Console.WriteLine("Wrong input!" + "\n Relaunch the program.");
                Console.WriteLine(E.ToString());
            }
        }

        }
    }
