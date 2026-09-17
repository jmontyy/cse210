using Resumes;
using System;

class Program
{
    static void Main(string[] args)
    {
        Resume r = new()
        {
            _name = "Todd",
            _jobs = [
            new() { _company = "Google", _jobTitle = "Programmer", _startYear = 2002, _endYear = 2022},
            new() { _company = "Microsoft", _jobTitle = "Developer", _startYear = 2022, _endYear = 2026}
            ]
        };

        r.Display();
    }
}