using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race
{
    class Runner:IComparable
    {
        public void setRunner(string Name , int TimeMin, int TimeSec, int age )
        {
            RunnerName = Name;
            RunnerAge = age;
            RunnerTimeMin = TimeMin;
            RunnerTimeSec = TimeSec;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public string RunnerName
        {
            get;set;
        }
        public int RunnerTimeMin
        {
            get; set;
        }
        public int RunnerTimeSec
        {
            get;set;
        }
        public int RunnerAge
        {
            get;set;
        }
    }
}
