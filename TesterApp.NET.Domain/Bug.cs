using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace TesterApp.NET.Data
{
    public class Bug
    {
        public int Id { get; set; }
        
        public int DeviceId { get; set; }
        
        public int TesterId { get; set; }
        
        public string Description { get; set; }
    }

    public sealed class BugMap : ClassMap<Bug>
    {
        public BugMap()
        {
            Map(b => b.Id).Index(0);
            Map(b => b.DeviceId).Index(1);
            Map(b => b.TesterId).Index(2);  
            Map(b => b.Description).Ignore();
        }
    }
}
