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
            foreach (Process process1 in Process.GetProcesses())
            {
               text+=($"ID: {process1.Id},NameProcess: {process1.ProcessName}, " +
                    $"Heap: {process1.VirtualMemorySize64}")+"\n";
                k++;
                

            }
            DateTime data = DateTime.Now;
            string path = data.Day.ToString()+"."+data.Month.ToString()+"."+data.Year.ToString()+"process.txt";
            File.AppendAllText(path, text);
           
            
            
        }
    }
}
