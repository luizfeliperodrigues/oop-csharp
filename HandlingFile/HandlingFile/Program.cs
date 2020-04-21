using System;
using System.IO;
using System.Collections.Generic;

namespace HandlingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Felipe\Desktop\study\C# Udemy\11 Trabalhando com arquivos";

            try
            {
                List<Item> items = new List<Item>();
                Item item = new Item();

                using (FileStream fs = new FileStream(path + @"/source.csv", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] line = sr.ReadLine().Split(",");
                            item = new Item(line[0], double.Parse(line[1])/100, int.Parse(line[2]));
                            items.Add(item);
                        }
                    }
                }

                using (StreamWriter sw = File.AppendText(path + @"\out\summary.csv"))
                {
                    foreach (Item i in items)
                    {
                        sw.WriteLine(i.ToString());
                    }
                }
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
