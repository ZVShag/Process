using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Dynamic;
using System.Text;
using System.IO;
using System.Threading;

namespace ConsoleApp15
{
    internal class proc
    {
        public long id { get; set; }
        public string name { get; set; }
        public long memo { get; set; }
        public ProcessThreadCollection threads { get; set; }
        public void Print()
        {
            Console.WriteLine($"Process ID:{this.id}");
            Console.WriteLine($"Process Name:{this.name}");
            Console.WriteLine($"Process Memmory size:{this.memo}");
            foreach(ProcessThread thread in threads)
            {
                Console.WriteLine($"\tThread id:{thread.Id}\n\tPrioritet {thread.CurrentPriority}\n\t Start Adress{thread.StartAddress}");
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                
                List<proc> procList = new List<proc>();
                
                foreach (Process pr in Process.GetProcesses())
                {
                    proc a = new proc();
                    a.id = pr.Id;
                    a.name = pr.ProcessName;
                    a.memo = pr.PagedMemorySize64/1024;
                    a.threads = pr.Threads;
                    procList.Add(a);
                }
                string nm;
                Console.WriteLine("Sort:\n1.Name\n2.ID\n3.Size\n4.Find process\n5.List and count");
                int menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        procList.Sort(delegate (proc p1, proc p2) { return p1.name.CompareTo(p2.name); });
                        break;
                    case 2:
                        procList.Sort(delegate (proc p1, proc p2) { return p1.id.CompareTo(p2.id); });
                        break;
                    case 3:
                        procList.Sort(delegate (proc p1, proc p2) { return p1.memo.CompareTo(p2.memo); });
                        break;
                    case 4:
                         Console.WriteLine("Введите имя процесса:");
                        nm=Console.ReadLine();
                        for (int i = 0; i < procList.Count; i++)
                            if (nm == procList[i].name)
                            {
                                Console.WriteLine("YES");
                                break;
                            }

                        break;
                    case 5:
                        for (int i=0;i<procList.Count-1;i++)
                        {
                            int z = 0;
                            for (int j=i+1;j<procList.Count;j++)
                            {
                                if (procList[i].name == procList[j].name)
                                    z++;
                            }
                            Console.WriteLine($"Количество экземпляров: {procList[i].name} составляет: {z}");
                        }
                        break;

                }
                foreach (proc proc in procList)
                {
                    proc.Print();
                }

                string text = "";

                /*DateTime data = DateTime.Now;
                string path = data.Day.ToString()+"."+data.Month.ToString()+"."+data.Year.ToString()+"process.txt";
                File.AppendAllText(path, text);
                File.AppendAllText(path, $"Max memory process\n {maxmemo_process_id}\t{maxmemo_process_name}\t{maxmemo}");
                File.AppendAllText(path, $"\nMin memory process\n {minmemo_process_id}\t{minmemo_process_name}\t{minmemo}");
                */



            }
        }
    }
}
