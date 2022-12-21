using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Dynamic;
using System.Text;
using System.IO;

namespace ConsoleApp15
{
    internal class proc
    {
        public long id { get; set; }
        public string name { get; set; }
        public long memo { get; set; }
        public void Print()
        {
            Console.WriteLine($"Process ID:{this.id}");
            Console.WriteLine($"Process Name:{this.name}");
            Console.WriteLine($"Process Memmory size:{this.memo}");
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
                    a.memo = pr.PagedMemorySize64;
                    procList.Add(a);                 
                }
                procList.Sort(delegate (proc p1, proc p2) { return p1.id.CompareTo(p2.id); }); 
               
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
