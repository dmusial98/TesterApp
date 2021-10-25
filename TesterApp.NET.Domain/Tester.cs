using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace TesterApp.NET.Data
{
    public class Tester
    {
        //[Name("testerId")]
        [Index(0)]
        public int Id { get; set; }

        //[Name("firstName")]
        [Index(1)]
        public string FirstName { get; set; }

        //[Name("lastName")]
        [Index(2)]
        public string LastName { get; set; }

        //[Name("country")]
        [Index(3)]
        public string CountryCode { get; set; }

        //[Name("lastLogin")]
        [Index(4)]
        public DateTime LastLogin { get; set; }

        public List<Device> Devices { get; set; } = new();
    }
}
