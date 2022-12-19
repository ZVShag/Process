﻿using System;
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
            string maxmemo_process_name="";
            int maxmemo_process_id=0;
            long minmemo = 11015555555;
            string minmemo_process_name = "";
            int minmemo_process_id = 0;
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
                if (process1.VirtualMemorySize64 < minmemo)
                {
                    minmemo = process1.VirtualMemorySize64;
                    minmemo_process_name = process1.ProcessName;
                    minmemo_process_id = process1.Id;
                }


            }
            DateTime data = DateTime.Now;
            string path = data.Day.ToString()+"."+data.Month.ToString()+"."+data.Year.ToString()+"process.txt";
            File.AppendAllText(path, text);
            File.AppendAllText(path, $"Max memory process\n {maxmemo_process_id}\t{maxmemo_process_name}\t{maxmemo}");
            File.AppendAllText(path, $"\nMin memory process\n {minmemo_process_id}\t{minmemo_process_name}\t{minmemo}");




        }
    }
}
