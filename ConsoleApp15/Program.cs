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
    internal class Program
    {
        static  void Main(string[] args)
        {
            int k = 0;
            string text="";
            long maxmemo = 0;
            string maxmemo_process_name;
            int maxmemo_process_id;
            foreach (Process process1 in Process.GetProcesses())
            {
               text+=($"ID: {process1.Id},NameProcess: {process1.ProcessName}, " +
                    $"Heap: {process1.VirtualMemorySize64}")+"\n";
                k++;
                if (process1.VirtualMemorySize64>maxmemo)
                {
                    maxmemo= process1.VirtualMemorySize64; 
                    maxmemo_process_name = process1.ProcessName;
                    maxmemo_process_id= process1.Id;
                }
                

            }
            DateTime data = DateTime.Now;
            string path = data.Day.ToString()+"."+data.Month.ToString()+"."+data.Year.ToString()+"process.txt";
            File.AppendAllText(path, text);
           
            
            
        }
    }
}
