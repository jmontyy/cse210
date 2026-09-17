using System;
using System.Collections.Generic;
using System.Text;

namespace Resumes
{
    public class Resume
    {
        public string _name;
        public List<Job> _jobs = [];

        public void Display() {
            Console.WriteLine(_name + "\nJobs:");    
        foreach (var item in _jobs)
            {
                item.Display();
            }
        }
    }
}
