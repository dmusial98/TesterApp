using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using CsvHelper;
using CsvHelper.Configuration;
using TesterApp.NET.Data;
using Microsoft.EntityFrameworkCore;

namespace TesterApp.NET.Console
{
    class Program
    {
        private static TesterContext _context = new TesterContext(new DbContextOptions<TesterContext>() );

        static void Main(string[] args)
        {
            //_context.Database.EnsureCreated();
            //var testersCSV = ReadDataFromCSV<Tester>(@"..\\..\\..\\..\\csv\\testers.csv");
            //AddTesters(testersCSV);

            //var bugsCSV = ReadDataFromCSV<Bug>(@"..\\..\\..\\..\\csv\\bugs.csv");
            //AddBugs(bugsCSV);

            //var devicesCSV = ReadDataFromCSV<Device>(@"..\\..\\..\\..\\csv\\devices.csv");
            //AddDevices(devicesCSV);

            //var testerDeviceCSV = ReadDataFromCSV<TesterDevice>(@"..\\..\\..\\..\\csv\\tester_device.csv");
            //AddTesterDevices(testerDeviceCSV);

            var testers = GetTesters();
            var CountryCodes = testers.GroupBy(t => t.CountryCode).ToList();

            System.Console.WriteLine("Press any key...");
            System.Console.ReadKey();
        }

        private static List<T> ReadDataFromCSV<T>(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
            };

            try
            {
                using var streamReader = new StreamReader(path);
                using var csvReader = new CsvReader(streamReader, config);
                csvReader.Context.RegisterClassMap<BugMap>();
                var records = csvReader.GetRecords<T>().ToList();
                return records;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }


            return null;
        }

        private static void AddTesters(List<Tester> testers)
        {
            if (testers != null && testers.Count != 0)
            {
                _context.Testers.AddRange(testers.Select(t => new Tester
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    LastLogin = t.LastLogin,
                    CountryCode = t.CountryCode
                }));
                _context.SaveChanges();
            }
        }

        private static List<Tester> GetTesters()
        {
            return _context.Testers.ToList();
        }

        private static void AddBugs(List<Bug> bugs)
        {
            if (bugs != null && bugs.Count != 0)
            {
                _context.Bugs.AddRange(bugs.Select(b => new Bug
                {
                    DeviceId = b.DeviceId,
                    TesterId = b.TesterId
                }));
                _context.SaveChanges();
            }
        }

        private static void AddDevices(List<Device> devices)
        {
            if (devices != null && devices.Count != 0)
            {
                _context.Devices.AddRange(devices.Select(d => new Device
                {
                    Description = d.Description
                }));
                _context.SaveChanges();
            }
        }

        private static void AddTesterDevices(List<TesterDevice> testerDevices)
        {
            if (testerDevices != null && testerDevices.Count != 0)
            {
                foreach (var testerDevice in testerDevices)
                {
                    var tester = _context.Testers.Find(testerDevice.TesterId);
                    var device = _context.Devices.Find(testerDevice.DeviceId);
                    tester.Devices.Add(device);
                    _context.SaveChanges();
                }

            }
        }

        private static void RemoveQuotes()
        {
            string text = System.IO.File.ReadAllText(@"..\\..\\..\\..\\csv\\devices.csv");
            string outText = text.Replace("\"", "").Replace("\r\r\r\n", "\r\n");

            File.WriteAllText(@"..\\..\\..\\..\\csv\\devices1.csv", outText);

        }
    }
}
