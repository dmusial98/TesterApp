using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace TesterApp.NET.Data
{
    public class TesterDevice
    {
        [Index(0)]
        public int TesterId { get; set; }
        
        [Index(1)]
        public int DeviceId { get; set; }

    }
}
