using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
namespace training_schedule
{
    [MemoryDiagnoser]
    public class BenchmarkClass
    {
        [Params(100, 1000, 10000, 100000)]
        public int iteration { get; set; }
         
        [Benchmark]
       public void BuildReportString()
        {
            string report = "";
            for(int i = 0; i < iteration; i++)
            {
                report += i.ToString();
            }
        }
        [Benchmark]
        public void BuildReportStringBuilder()
        {
            StringBuilder report =new StringBuilder();
            for(int i = 0; i < iteration; i++)
            {
                report.Append(i.ToString());
            }
        }
    }
   

}
