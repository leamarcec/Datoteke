using System;
using System.IO;
using System.Collections.Generic;

namespace Datoteke
{
    class Program
    {
        static void Main(string[] args)
        {
            string direktorij = args[0];

            if (Directory.Exists(direktorij))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(direktorij);

                var dat = dirInfo.GetFiles();
                long vel = 0;
                DirectoryInfo dir = new DirectoryInfo(direktorij);


                Console.WriteLine("| Veličina       B ;          KB ;      MB | Nazivi datoteka                          |");


                foreach (FileInfo d in dat)


                    if (Directory.Exists(direktorij))
                    {
                        vel += d.Length;
                        Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB | {3,40} |",
                            d.Length,
                            d.Length / 1024,
                            d.Length / (1024 * 1024),
                            d.FullName);
                        var direktoriji = dir.GetDirectories();

                        List<DirectoryInfo> dirs = new List<DirectoryInfo>(direktoriji);


                        List<FileInfo> files = new List<FileInfo>(dat);


                        Console.WriteLine("| Veličina       B ;          KB ;      MB | Naziv  datoteke                          |");
                        Console.WriteLine("| Veličina       B ;          KB ;      MB | Naziv  direktorija/datoteke              |");


                        foreach (FileInfo fi in dat)
                        {
                            foreach (DirectoryInfo di in dirs)
                            {
                                long velicinaDirektorija = 0;
                                FileInfo[] fileInfos = di.GetFiles();


                                foreach (FileInfo f in fileInfos)
                                {
                                    velicinaDirektorija += f.Length;
                                }

                                Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB | {3,40} |",
                                    velicinaDirektorija,
                                    //racunanje KB
                                    velicinaDirektorija / 1024,
                                    //racunanje MB
                                    velicinaDirektorija / (1024 * 1024),
                                    di.Name);
                            }

                            foreach (FileInfo f in files)
                            {
                                vel += f.Length;

                                Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB | {3,40} |",
                                    f.Length,
                                    //racunanje u KB
                                    f.Length / 1024,
                                    //racunanje u MB
                                    f.Length / (1024 * 1024),
                                    f.FullName);
                            }

                            Console.WriteLine(vel / (1024 * 1024));
                        }
                        Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");

                        Console.SetCursorPosition(1, 3);


                        Console.SetCursorPosition(1, 3);
                        Console.Write(">");



                    }
                Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
                Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB |                                          |",
                    vel,
                    vel / 1024,
                    vel / (1024 * 1024));
                Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");

                Console.SetCursorPosition(1, 3);
                Console.Write(">");
                int brojRedova = dat.Length + 6;
            }



            else
            {

                DriveInfo[] diskovi = DriveInfo.GetDrives();
                int najvece = 0;
                foreach (DriveInfo d in diskovi)
                {
                    if (d.IsReady)
                    {
                        if (d.VolumeLabel.Length > najvece)
                        {
                            najvece = d.VolumeLabel.Length;
                        }


                    }
                }

                Console.Write("+------------------+---------------+---------+-----------+"); Console.Write("-".PadRight(najvece, '-')); Console.WriteLine("+");
                Console.Write("| Oznaka diska     |Ukupna veličina|Slobodno |     %     |"); Console.Write("Naziv Diska".PadRight(najvece)); Console.WriteLine("+");
                Console.Write("+------------------+---------------+---------+-----------+"); Console.Write("-".PadRight(najvece, '-')); Console.WriteLine("+");

                foreach (DriveInfo d in diskovi)
                {


                    if (d.IsReady)
                    {


                        Console.Write("|{0, 16}  | {1, 10} GB | {2, 4} GB | {3, 7} % |",
                        d.Name,
                        d.TotalSize / (1024 * 1024 * 1024),
                        d.TotalFreeSpace / (1024 * 1024 * 1024),
                        Math.Round(((double)d.TotalFreeSpace / (double)d.TotalSize) * 100, 2));
                        Console.Write("{0}".PadRight((najvece + 3) - d.VolumeLabel.Length), d.VolumeLabel); Console.WriteLine("|");
                    }

                    else
                    {
                        Console.Write("|{0, 16}  | {1, 12}  | {2, 6}  | {3, 8}  |", d.Name, "n/a", "n/a", "n/a");
                        Console.Write("n/a".PadRight((najvece))); Console.WriteLine("|");
                    }
                }
                Console.Write("+------------------+---------------+---------+-----------+"); Console.Write("-".PadRight((najvece), '-')); Console.WriteLine("+");
            }
            Console.ReadKey();
        }
    }

}
