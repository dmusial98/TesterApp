using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;

namespace TesterApp.NET.Data
{
    public class Device
    {
        [Index(0)]
        public int Id { get; set; }
        
        [Index(1)]
        public string Description { get; set; }

        public List<Tester> Testers { get; set; } = new();
    }
}
