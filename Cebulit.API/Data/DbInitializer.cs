using System.Linq;
using Cebulit.API.Core.Models;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Builds.Any())
                return;

            var tags = new[]
            {
                new Tag {Id = 1, Name = "dom"},
                new Tag {Id = 2, Name = "home office"},
                new Tag {Id = 3, Name = "kompaktowy"},
                new Tag {Id = 4, Name = "programowanie"},
                new Tag {Id = 5, Name = "cisza"},
                new Tag {Id = 6, Name = "maszyny wirtualne"},
                new Tag {Id = 7, Name = "esport"},
                new Tag {Id = 8, Name = "edycja wideo"},
                new Tag {Id = 9, Name = "dużo ramu"},
                new Tag {Id = 11, Name = "photoshop"},
                new Tag {Id = 12, Name = "gry aaa"}
            };
            foreach (var tag in tags)
            {
                context.Tags.Add(tag);
            }

            context.SaveChanges();

            var processors = new[]
            {
                new Processor
                {
                    Id = 1, Name = "AMD Ryzen 5600X", Cores = 6, Threads = 12, Socket = "AM4", BaseClock = 3.7,
                    BoostClock = 4.6, Price = 1549, Brand = "AMD"
                },
                new Processor
                {
                    Id = 2, Name = "Intel Core i5-11400", Cores = 6, Threads = 12, Socket = "LGA 1200", BaseClock = 2.6,
                    BoostClock = 4.4, Price = 859, Brand = "Intel"
                },
                new Processor
                {
                    Id = 3, Name = "AMD Ryzen 3600", Cores = 6, Threads = 12, Socket = "AM4", BaseClock = 3.6,
                    BoostClock = 4.2, Price = 849, Brand = "AMD"
                },
                new Processor
                {
                    Id = 4, Name = "AMD Ryzen 1600AF", Cores = 6, Threads = 12, Socket = "AM4", BaseClock = 3.2,
                    BoostClock = 3.6, Price = 559, Brand = "AMD"
                },
                new Processor
                {
                    Id = 5, Name = "AMD Ryzen 5800X", Cores = 8, Threads = 16, Socket = "AM4", BaseClock = 3.8,
                    BoostClock = 4.7, Price = 1999, Brand = "AMD"
                },
                new Processor
                {
                    Id = 6, Name = "Intel Core i7-11700K", Cores = 8, Threads = 16, Socket = "LGA 1200",
                    BaseClock = 3.8,
                    BoostClock = 4.7, Price = 1999, Brand = "Intel"
                },
                new Processor
                {
                    Id = 7, Name = "Intel Core i3-10105", Cores = 4, Threads = 8, Socket = "LGA 1200", BaseClock = 3.7,
                    BoostClock = 4.4, Price = 549, Brand = "Intel"
                },
                new Processor
                {
                    Id = 8, Name = "AMD Athlon 3000G", Cores = 2, Threads = 4, Socket = "AM4", BaseClock = 3.5,
                    BoostClock = 3.5, Price = 399, Brand = "AMD"
                },
                new Processor
                {
                    Id = 9, Name = "Intel Pentium G6405", Cores = 2, Threads = 4, Socket = "LGA 1200", BaseClock = 4.1,
                    BoostClock = 4.1, Price = 299, Brand = "Intel"
                },
                new Processor
                {
                    Id = 10, Name = "AMD Ryzen 9 5900X", Cores = 12, Threads = 24, Socket = "AM4", BaseClock = 3.7,
                    BoostClock = 4.8, Price = 2849, Brand = "AMD"
                },
                new Processor
                {
                    Id = 11, Name = "Intel Core i7-11700", Cores = 8, Threads = 16, Socket = "LGA 1200",
                    BaseClock = 3.7,
                    BoostClock = 4.8, Price = 2849, Brand = "Intel"
                },
            };

            var processorTagMatches = new[]
            {
                new Processor.ProcessorTagMatch {ProcessorId = 1, Tag = tags[3], MatchLevel = 1.8,},
                new Processor.ProcessorTagMatch {ProcessorId = 1, Tag = tags[5], MatchLevel = 1.4,},
                new Processor.ProcessorTagMatch {ProcessorId = 1, Tag = tags[6], MatchLevel = 1.8,},
                new Processor.ProcessorTagMatch {ProcessorId = 1, Tag = tags[7], MatchLevel = 1.6,},
                new Processor.ProcessorTagMatch {ProcessorId = 1, Tag = tags[9], MatchLevel = 1.6,},
                new Processor.ProcessorTagMatch {ProcessorId = 1, Tag = tags[10], MatchLevel = 2.0,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 2, Tag = tags[3], MatchLevel = 1.75,},
                new Processor.ProcessorTagMatch {ProcessorId = 2, Tag = tags[5], MatchLevel = 1.35,},
                new Processor.ProcessorTagMatch {ProcessorId = 2, Tag = tags[6], MatchLevel = 1.75,},
                new Processor.ProcessorTagMatch {ProcessorId = 2, Tag = tags[7], MatchLevel = 1.55,},
                new Processor.ProcessorTagMatch {ProcessorId = 2, Tag = tags[9], MatchLevel = 1.55,},
                new Processor.ProcessorTagMatch {ProcessorId = 2, Tag = tags[10], MatchLevel = 1.9,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 3, Tag = tags[3], MatchLevel = 1.7,},
                new Processor.ProcessorTagMatch {ProcessorId = 3, Tag = tags[5], MatchLevel = 1.3,},
                new Processor.ProcessorTagMatch {ProcessorId = 3, Tag = tags[6], MatchLevel = 1.85,},
                new Processor.ProcessorTagMatch {ProcessorId = 3, Tag = tags[7], MatchLevel = 1.5,},
                new Processor.ProcessorTagMatch {ProcessorId = 3, Tag = tags[9], MatchLevel = 1.5,},
                new Processor.ProcessorTagMatch {ProcessorId = 3, Tag = tags[10], MatchLevel = 1.9,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 4, Tag = tags[0], MatchLevel = 1.7,},
                new Processor.ProcessorTagMatch {ProcessorId = 4, Tag = tags[1], MatchLevel = 1.75,},
                new Processor.ProcessorTagMatch {ProcessorId = 4, Tag = tags[3], MatchLevel = 1.55,},
                new Processor.ProcessorTagMatch {ProcessorId = 4, Tag = tags[5], MatchLevel = 1.25,},
                new Processor.ProcessorTagMatch {ProcessorId = 4, Tag = tags[6], MatchLevel = 1.77,},
                new Processor.ProcessorTagMatch {ProcessorId = 4, Tag = tags[7], MatchLevel = 1.37,},
                new Processor.ProcessorTagMatch {ProcessorId = 4, Tag = tags[9], MatchLevel = 1.11,},
                new Processor.ProcessorTagMatch {ProcessorId = 4, Tag = tags[10], MatchLevel = 1.25,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 5, Tag = tags[3], MatchLevel = 1.88,},
                new Processor.ProcessorTagMatch {ProcessorId = 5, Tag = tags[5], MatchLevel = 1.86,},
                new Processor.ProcessorTagMatch {ProcessorId = 5, Tag = tags[6], MatchLevel = 1.68,},
                new Processor.ProcessorTagMatch {ProcessorId = 5, Tag = tags[7], MatchLevel = 1.87,},
                new Processor.ProcessorTagMatch {ProcessorId = 5, Tag = tags[8], MatchLevel = 1.87,},
                new Processor.ProcessorTagMatch {ProcessorId = 5, Tag = tags[9], MatchLevel = 1.89,},
                new Processor.ProcessorTagMatch {ProcessorId = 5, Tag = tags[10], MatchLevel = 1.97,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 6, Tag = tags[3], MatchLevel = 1.84,},
                new Processor.ProcessorTagMatch {ProcessorId = 6, Tag = tags[5], MatchLevel = 1.84,},
                new Processor.ProcessorTagMatch {ProcessorId = 6, Tag = tags[6], MatchLevel = 1.62,},
                new Processor.ProcessorTagMatch {ProcessorId = 6, Tag = tags[7], MatchLevel = 1.83,},
                new Processor.ProcessorTagMatch {ProcessorId = 6, Tag = tags[8], MatchLevel = 1.83,},
                new Processor.ProcessorTagMatch {ProcessorId = 6, Tag = tags[9], MatchLevel = 1.84,},
                new Processor.ProcessorTagMatch {ProcessorId = 6, Tag = tags[10], MatchLevel = 1.92,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 7, Tag = tags[0], MatchLevel = 1.99,},
                new Processor.ProcessorTagMatch {ProcessorId = 7, Tag = tags[1], MatchLevel = 1.97,},
                new Processor.ProcessorTagMatch {ProcessorId = 7, Tag = tags[2], MatchLevel = 1.75,},
                new Processor.ProcessorTagMatch {ProcessorId = 7, Tag = tags[4], MatchLevel = 1.86,},
                new Processor.ProcessorTagMatch {ProcessorId = 7, Tag = tags[6], MatchLevel = 1.83,},
                new Processor.ProcessorTagMatch {ProcessorId = 7, Tag = tags[9], MatchLevel = 1.84,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 8, Tag = tags[0], MatchLevel = 1.92,},
                new Processor.ProcessorTagMatch {ProcessorId = 8, Tag = tags[1], MatchLevel = 1.92,},
                new Processor.ProcessorTagMatch {ProcessorId = 8, Tag = tags[2], MatchLevel = 1.72,},
                new Processor.ProcessorTagMatch {ProcessorId = 8, Tag = tags[4], MatchLevel = 1.82,},
                new Processor.ProcessorTagMatch {ProcessorId = 8, Tag = tags[6], MatchLevel = 1.78,},
                new Processor.ProcessorTagMatch {ProcessorId = 8, Tag = tags[9], MatchLevel = 1.80,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 9, Tag = tags[0], MatchLevel = 1.92,},
                new Processor.ProcessorTagMatch {ProcessorId = 9, Tag = tags[1], MatchLevel = 1.92,},
                new Processor.ProcessorTagMatch {ProcessorId = 9, Tag = tags[2], MatchLevel = 1.72,},
                new Processor.ProcessorTagMatch {ProcessorId = 9, Tag = tags[4], MatchLevel = 1.82,},
                new Processor.ProcessorTagMatch {ProcessorId = 9, Tag = tags[6], MatchLevel = 1.78,},
                new Processor.ProcessorTagMatch {ProcessorId = 9, Tag = tags[9], MatchLevel = 1.80,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 10, Tag = tags[3], MatchLevel = 1.89,},
                new Processor.ProcessorTagMatch {ProcessorId = 10, Tag = tags[5], MatchLevel = 1.87,},
                new Processor.ProcessorTagMatch {ProcessorId = 10, Tag = tags[6], MatchLevel = 1.68,},
                new Processor.ProcessorTagMatch {ProcessorId = 10, Tag = tags[7], MatchLevel = 1.88,},
                new Processor.ProcessorTagMatch {ProcessorId = 10, Tag = tags[8], MatchLevel = 1.88,},
                new Processor.ProcessorTagMatch {ProcessorId = 10, Tag = tags[9], MatchLevel = 1.91,},
                new Processor.ProcessorTagMatch {ProcessorId = 10, Tag = tags[10], MatchLevel = 1.99,},
                
                new Processor.ProcessorTagMatch {ProcessorId = 11, Tag = tags[3], MatchLevel = 1.89,},
                new Processor.ProcessorTagMatch {ProcessorId = 11, Tag = tags[5], MatchLevel = 1.87,},
                new Processor.ProcessorTagMatch {ProcessorId = 11, Tag = tags[6], MatchLevel = 1.68,},
                new Processor.ProcessorTagMatch {ProcessorId = 11, Tag = tags[7], MatchLevel = 1.88,},
                new Processor.ProcessorTagMatch {ProcessorId = 11, Tag = tags[8], MatchLevel = 1.88,},
                new Processor.ProcessorTagMatch {ProcessorId = 11, Tag = tags[9], MatchLevel = 1.91,},
                new Processor.ProcessorTagMatch {ProcessorId = 11, Tag = tags[10], MatchLevel = 1.99,},
            };


            foreach (var processor in processors)
            {
                var tagMatches = processorTagMatches.Where(x => x.ProcessorId == processor.Id).ToList();
                if (tagMatches.Any())
                    processor.ProcessorTagMatches = tagMatches;

                context.Processors.Add(processor);
            }

            context.SaveChanges();

            var motherboards = new[]
            {
                new Motherboard
                {
                    Id = 1, Name = "Gigabyte B450 AORUS ELITE V2", Socket = "AM4", MemorySlots = 4,
                    FormFactor = MotherboardFormFactor.ATX, Price = 389, Brand = "Gigabyte"
                },
                new Motherboard
                {
                    Id = 2, Name = "MSI Z490-A PRO", Socket = "LGA 1200", MemorySlots = 4,
                    FormFactor = MotherboardFormFactor.ATX, Price = 719, Brand = "MSI"
                },
                new Motherboard
                {
                    Id = 3, Name = "ASUS PRIME B450M-A II", Socket = "AM4", MemorySlots = 4,
                    FormFactor = MotherboardFormFactor.microATX, Price = 259, Brand = "ASUS"
                },
                new Motherboard
                {
                    Id = 4, Name = "MSI B550-A PRO", Socket = "AM4", MemorySlots = 4,
                    FormFactor = MotherboardFormFactor.ATX, Price = 539, Brand = "MSI"
                },
                new Motherboard
                {
                    Id = 5, Name = "MSI X570-A PRO", Socket = "AM4", MemorySlots = 4,
                    FormFactor = MotherboardFormFactor.ATX, Price = 729, Brand = "MSI"
                },
                new Motherboard
                {
                    Id = 6, Name = "Gigabyte B460M DS3H V2", Socket = "LGA 1200", MemorySlots = 4,
                    FormFactor = MotherboardFormFactor.microATX, Price = 379, Brand = "Gigabyte"
                },
                new Motherboard
                {
                    Id = 7, Name = "ASRock B560 Pro4", Socket = "LGA 1200", MemorySlots = 4,
                    FormFactor = MotherboardFormFactor.ATX, Price = 569, Brand = "ASRock"
                },
                new Motherboard
                {
                    Id = 8, Name = "Gigabyte Z590 UD AC", Socket = "LGA 1200", MemorySlots = 4,
                    FormFactor = MotherboardFormFactor.ATX, Price = 799, Brand = "Gigabyte"
                }
            };

            var moboTagMatches = new[]
            {
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[0], MatchLevel = 1.3,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[1], MatchLevel = 1.5,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[2], MatchLevel = 0.6,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[3], MatchLevel = 1.6,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[4], MatchLevel = 1.9,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[5], MatchLevel = 1.7,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[6], MatchLevel = 1.8,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[7], MatchLevel = 1.6,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[8], MatchLevel = 1.5,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[9], MatchLevel = 1.7,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 1, Tag = tags[10], MatchLevel = 1.8,},
                
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[0], MatchLevel = 1.3,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[1], MatchLevel = 0.9,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[2], MatchLevel = 0.3},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[3], MatchLevel = 1.85,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[4], MatchLevel = 0.9,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[5], MatchLevel = 1.8,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[6], MatchLevel = 1.3,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[7], MatchLevel = 1.9,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[8], MatchLevel = 1.5,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[9], MatchLevel = 1.8,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 2, Tag = tags[10], MatchLevel = 1.8,},
                
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[0], MatchLevel = 1.9,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[1], MatchLevel = 1.99,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[2], MatchLevel = 1.75},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[3], MatchLevel = 1.2,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[4], MatchLevel = 1.75,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[5], MatchLevel = 1.25,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[6], MatchLevel = 1.6,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[7], MatchLevel = 1.9,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[8], MatchLevel = 1.25,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[9], MatchLevel = 1.0},
                new Motherboard.MotherboardTagMatch {MotherboardId = 3, Tag = tags[10], MatchLevel = 1.2,},
                
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[0], MatchLevel = 1,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[1], MatchLevel = 1.2,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[2], MatchLevel = 0.75},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[3], MatchLevel = 1.2,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[4], MatchLevel = 1,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[5], MatchLevel = 1.5,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[6], MatchLevel = 1.5,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[7], MatchLevel = 1.77,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[8], MatchLevel = 1.88,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[9], MatchLevel = 1.78},
                new Motherboard.MotherboardTagMatch {MotherboardId = 4, Tag = tags[10], MatchLevel = 1.8,},
                
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[0], MatchLevel = 1.05},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[1], MatchLevel = 1.22,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[2], MatchLevel = 0.78},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[3], MatchLevel = 1.24,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[4], MatchLevel = 1.02,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[5], MatchLevel = 1.55,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[6], MatchLevel = 1.52,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[7], MatchLevel = 1.75,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[8], MatchLevel = 1.82,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[9], MatchLevel = 1.74},
                new Motherboard.MotherboardTagMatch {MotherboardId = 5, Tag = tags[10], MatchLevel = 1.87,},
                
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[0], MatchLevel = 1.9,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[1], MatchLevel = 1.99,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[2], MatchLevel = 1.75},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[3], MatchLevel = 1.2,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[4], MatchLevel = 1.75,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[5], MatchLevel = 1.25,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[6], MatchLevel = 1.6,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[7], MatchLevel = 1.9,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[8], MatchLevel = 1.25,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[9], MatchLevel = 1.0},
                new Motherboard.MotherboardTagMatch {MotherboardId = 6, Tag = tags[10], MatchLevel = 1.2,},
                
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[0], MatchLevel = 1.91,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[1], MatchLevel = 1.97,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[2], MatchLevel = 1.72},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[3], MatchLevel = 1.24,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[4], MatchLevel = 1.77,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[5], MatchLevel = 1.26,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[6], MatchLevel = 1.62,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[7], MatchLevel = 1.91,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[8], MatchLevel = 1.24,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[9], MatchLevel = 1.02},
                new Motherboard.MotherboardTagMatch {MotherboardId = 7, Tag = tags[10], MatchLevel = 1.24,},
                
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[0], MatchLevel = 1.05},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[1], MatchLevel = 1.22,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[2], MatchLevel = 0.78},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[3], MatchLevel = 1.24,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[4], MatchLevel = 1.02,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[5], MatchLevel = 1.55,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[6], MatchLevel = 1.52,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[7], MatchLevel = 1.75,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[8], MatchLevel = 1.82,},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[9], MatchLevel = 1.74},
                new Motherboard.MotherboardTagMatch {MotherboardId = 8, Tag = tags[10], MatchLevel = 1.87,},
            };
            
            foreach (var mobo in motherboards)
            {
                var tagMatches = moboTagMatches.Where(x => x.MotherboardId == mobo.Id).ToList();
                if (tagMatches.Any())
                    mobo.MotherboardTagMatches = tagMatches;

                context.Motherboards.Add(mobo);
            }

            context.SaveChanges();

            var memoryModules = new[]
            {
                new Memory
                {
                    Id = 1, Name = "HyperX Fury RGB", Capacity = 16, Modules = 2, Speed = 3200, Latency = 16,
                    Price = 455, Brand = "HyperX"
                },
                new Memory
                {
                    Id = 2, Name = "GoodRam IRDM", Capacity = 16, Modules = 2, Speed = 3200, Latency = 16, Price = 469,
                    Brand = "GoodRam"
                },
                new Memory
                {
                    Id = 3, Name = "Team Group T-Force VulcanZ", Capacity = 8, Modules = 2, Speed = 3000, Latency = 16,
                    Price = 209, Brand = "Team Group"
                },
                new Memory
                {
                    Id = 4, Name = "HyperX Fury Black", Capacity = 32, Modules = 2, Speed = 3600, Latency = 18,
                    Price = 809, Brand = "HyperX"
                },
                new Memory
                {
                    Id = 5, Name = "Patriot Viper Steel", Capacity = 64, Modules = 2, Speed = 3600, Latency = 18,
                    Price = 1749, Brand = "Patriot"
                },
                new Memory
                {
                    Id = 6, Name = "HyperX Fury Black RGB", Capacity = 128, Modules = 4, Speed = 3200, Latency = 16,
                    Price = 3669, Brand = "HyperX"
                }
            };
            
            var ramTagMatches = new[]
            {
                new Memory.MemoryTagMatch {MemoryId = 1, Tag = tags[3], MatchLevel = 1.5,},
                new Memory.MemoryTagMatch {MemoryId = 1, Tag = tags[5], MatchLevel = 1.25,},
                new Memory.MemoryTagMatch {MemoryId = 1, Tag = tags[6], MatchLevel = 2.0,},
                new Memory.MemoryTagMatch {MemoryId = 1, Tag = tags[7], MatchLevel = 1.35,},
                new Memory.MemoryTagMatch {MemoryId = 1, Tag = tags[8], MatchLevel = 1.25,},
                new Memory.MemoryTagMatch {MemoryId = 1, Tag = tags[9], MatchLevel = 1.35,},
                new Memory.MemoryTagMatch {MemoryId = 1, Tag = tags[10], MatchLevel = 1.8,},
                
                new Memory.MemoryTagMatch {MemoryId = 2, Tag = tags[3], MatchLevel = 1.51,},
                new Memory.MemoryTagMatch {MemoryId = 2, Tag = tags[5], MatchLevel = 1.26,},
                new Memory.MemoryTagMatch {MemoryId = 2, Tag = tags[6], MatchLevel = 2.01,},
                new Memory.MemoryTagMatch {MemoryId = 2, Tag = tags[7], MatchLevel = 1.37,},
                new Memory.MemoryTagMatch {MemoryId = 2, Tag = tags[8], MatchLevel = 1.26,},
                new Memory.MemoryTagMatch {MemoryId = 2, Tag = tags[9], MatchLevel = 1.36,},
                new Memory.MemoryTagMatch {MemoryId = 2, Tag = tags[10], MatchLevel = 1.82,},
                
                new Memory.MemoryTagMatch {MemoryId = 3, Tag = tags[0], MatchLevel = 1.87,},
                new Memory.MemoryTagMatch {MemoryId = 3, Tag = tags[1], MatchLevel = 1.75,},
                new Memory.MemoryTagMatch {MemoryId = 3, Tag = tags[6], MatchLevel = 1.22,},
                new Memory.MemoryTagMatch {MemoryId = 3, Tag = tags[8], MatchLevel = 1,},
                
                new Memory.MemoryTagMatch {MemoryId = 4, Tag = tags[3], MatchLevel = 1.85,},
                new Memory.MemoryTagMatch {MemoryId = 4, Tag = tags[5], MatchLevel = 1.5,},
                new Memory.MemoryTagMatch {MemoryId = 4, Tag = tags[6], MatchLevel = 1.85,},
                new Memory.MemoryTagMatch {MemoryId = 4, Tag = tags[7], MatchLevel = 1.75,},
                new Memory.MemoryTagMatch {MemoryId = 4, Tag = tags[8], MatchLevel = 1.75,},
                new Memory.MemoryTagMatch {MemoryId = 4, Tag = tags[9], MatchLevel = 1.75,},
                new Memory.MemoryTagMatch {MemoryId = 4, Tag = tags[10], MatchLevel = 1.99,},
                
                new Memory.MemoryTagMatch {MemoryId = 5, Tag = tags[3], MatchLevel = 1.89,},
                new Memory.MemoryTagMatch {MemoryId = 5, Tag = tags[5], MatchLevel = 1.59,},
                new Memory.MemoryTagMatch {MemoryId = 5, Tag = tags[6], MatchLevel = 1.65,},
                new Memory.MemoryTagMatch {MemoryId = 5, Tag = tags[7], MatchLevel = 1.85,},
                new Memory.MemoryTagMatch {MemoryId = 5, Tag = tags[8], MatchLevel = 1.90,},
                new Memory.MemoryTagMatch {MemoryId = 5, Tag = tags[9], MatchLevel = 1.85,},
                new Memory.MemoryTagMatch {MemoryId = 5, Tag = tags[10], MatchLevel = 1.99,},
                
                new Memory.MemoryTagMatch {MemoryId = 6, Tag = tags[3], MatchLevel = 1.89,},
                new Memory.MemoryTagMatch {MemoryId = 6, Tag = tags[5], MatchLevel = 1.2,},
                new Memory.MemoryTagMatch {MemoryId = 6, Tag = tags[6], MatchLevel = 1.89,},
                new Memory.MemoryTagMatch {MemoryId = 6, Tag = tags[7], MatchLevel = 1.78,},
                new Memory.MemoryTagMatch {MemoryId = 6, Tag = tags[8], MatchLevel = 1.95,},
                new Memory.MemoryTagMatch {MemoryId = 6, Tag = tags[9], MatchLevel = 1.79,},
                new Memory.MemoryTagMatch {MemoryId = 6, Tag = tags[10], MatchLevel = 1.99,},
            };
            
            foreach (var ram in memoryModules)
            {
                var tagMatches = ramTagMatches.Where(x => x.MemoryId == ram.Id).ToList();
                if (tagMatches.Any())
                    ram.MemoryTagMatches = tagMatches;

                context.Memory.Add(ram);
            }

            context.SaveChanges();

            var graphicsCards = new[]
            {
                new GraphicsCard
                {
                    Id = 1, Name = "Zotac GeForce GTX 1650 Gaming D6", MemoryCapacity = 4, Price = 750, Brand = "Nvidia"
                },
                new GraphicsCard
                {
                    Id = 2, Name = "Gigabyte GeForce GTX 1660 OC", MemoryCapacity = 6, Price = 1299, Brand = "Nvidia"
                },
                new GraphicsCard
                {
                    Id = 3, Name = "Zotac GeForce RTX 3060 AMP White Edition", MemoryCapacity = 12, Price = 1699,
                    Brand = "Nvidia"
                },
                new GraphicsCard
                {
                    Id = 4, Name = "Gigabyte GeForce RTX 3060 Ti Eagle", MemoryCapacity = 8, Price = 1999,
                    Brand = "Nvidia"
                },
                new GraphicsCard
                {
                    Id = 5, Name = "EVGA GeForce RTX 3070 XC3 Gaming", MemoryCapacity = 8, Price = 2549,
                    Brand = "Nvidia"
                },
                new GraphicsCard
                    {Id = 6, Name = "MSI GeForce RTX 3080 Suprim", MemoryCapacity = 10, Price = 3449, Brand = "Nvidia"},
                new GraphicsCard
                    {Id = 7, Name = "EVGA RTX 3090 Ultra Gaming", MemoryCapacity = 24, Price = 7399, Brand = "Nvidia"},
                new GraphicsCard
                    {Id = 8, Name = "ASRock Radeon 6700XT", MemoryCapacity = 12, Price = 2499, Brand = "AMD"},
                new GraphicsCard
                {
                    Id = 9, Name = "MSI Radeon RX 6800 GAMING X TRIO", MemoryCapacity = 16, Price = 2999, Brand = "AMD"
                },
                new GraphicsCard
                {
                    Id = 10, Name = "Gigabyte Radeon RX 6800 XT", MemoryCapacity = 16, Price = 3399, Brand = "AMD"
                },
                new GraphicsCard
                    {Id = 11, Name = "MSI Radeon RX 6900 XT", MemoryCapacity = 16, Price = 7699, Brand = "AMD"},
            };
 
            var gpuTagMatches = new[]
            {
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[0], MatchLevel = 1.85,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[1], MatchLevel = 1.75,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[2], MatchLevel = 1.9,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[3], MatchLevel = 1.65,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[4], MatchLevel = 1.95,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[6], MatchLevel = 1.5,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[7], MatchLevel = 0.8,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[8], MatchLevel = 0.8,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[9], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 1, Tag = tags[10], MatchLevel = 0.75,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[0], MatchLevel = 1.80,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[1], MatchLevel = 1.70,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[2], MatchLevel = 1.92,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[3], MatchLevel = 1.7,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[4], MatchLevel = 1.9,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[6], MatchLevel = 1.7,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[7], MatchLevel = 0.9,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[8], MatchLevel = 0.85,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[9], MatchLevel = 1.1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 2, Tag = tags[10], MatchLevel = 0.8,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[0], MatchLevel = 1.75,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[1], MatchLevel = 1.70,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[2], MatchLevel = 1.4,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[3], MatchLevel = 1.68,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[4], MatchLevel = 1.98,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[6], MatchLevel = 1.85,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[7], MatchLevel = 1.35,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[8], MatchLevel = 1.65,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[9], MatchLevel = 1.72,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 3, Tag = tags[10], MatchLevel = 1.35,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[0], MatchLevel = 1.6,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[1], MatchLevel = 1.6,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[2], MatchLevel = 0.9,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[3], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[4], MatchLevel = 0.75,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[6], MatchLevel = 1.89,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[7], MatchLevel = 1.75,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[8], MatchLevel = 1.82,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[9], MatchLevel = 1.86,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 4, Tag = tags[10], MatchLevel = 1.89,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[0], MatchLevel = 0.5,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[1], MatchLevel = 0.5,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[2], MatchLevel = 0.5,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[3], MatchLevel = 1.65,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[4], MatchLevel = 0.5,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[6], MatchLevel = 1.75,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[7], MatchLevel = 1.90,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[8], MatchLevel = 1.77,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[9], MatchLevel = 1.90,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 5, Tag = tags[10], MatchLevel = 1.99,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[0], MatchLevel = 0.4,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[1], MatchLevel = 0.4,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[2], MatchLevel = 0.4,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[3], MatchLevel = 1.25,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[4], MatchLevel = 0.4,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[6], MatchLevel = 1.89,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[7], MatchLevel = 1.32,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[8], MatchLevel = 1.67,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[9], MatchLevel = 1.77,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 6, Tag = tags[10], MatchLevel = 1.38,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[0], MatchLevel = 0.2,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[1], MatchLevel = 0.2,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[2], MatchLevel = 0.2,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[3], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[4], MatchLevel = 0.2,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[6], MatchLevel = 1.6,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[7], MatchLevel = 1.85,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[8], MatchLevel = 1.89,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[9], MatchLevel = 1.45,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 7, Tag = tags[10], MatchLevel = 1.96,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[0], MatchLevel = 0.51,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[1], MatchLevel = 0.51,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[2], MatchLevel = 0.51,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[3], MatchLevel = 1.64,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[4], MatchLevel = 0.51,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[6], MatchLevel = 1.74,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[7], MatchLevel = 1.89,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[8], MatchLevel = 1.76,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[9], MatchLevel = 1.89,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 8, Tag = tags[10], MatchLevel = 1.98,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[0], MatchLevel = 0.41,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[1], MatchLevel = 0.41,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[2], MatchLevel = 0.41,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[3], MatchLevel = 1.24,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[4], MatchLevel = 0.41,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[6], MatchLevel = 1.88,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[7], MatchLevel = 1.31,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[8], MatchLevel = 1.66,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[9], MatchLevel = 1.76,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 9, Tag = tags[10], MatchLevel = 1.37,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[0], MatchLevel = 0.41,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[1], MatchLevel = 0.41,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[2], MatchLevel = 0.41,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[3], MatchLevel = 1.24,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[4], MatchLevel = 0.41,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[6], MatchLevel = 1.88,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[7], MatchLevel = 1.31,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[8], MatchLevel = 1.66,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[9], MatchLevel = 1.76,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 10, Tag = tags[10], MatchLevel = 1.37,},
                
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[0], MatchLevel = 0.21,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[1], MatchLevel = 0.21,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[2], MatchLevel = 0.21,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[3], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[4], MatchLevel = 0.21,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[5], MatchLevel = 1,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[6], MatchLevel = 1.61,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[7], MatchLevel = 1.86,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[8], MatchLevel = 1.90,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[9], MatchLevel = 1.46,},
                new GraphicsCard.GraphicsCardTagMatch {GraphicsCardId = 11, Tag = tags[10], MatchLevel = 1.97,},
            };
            
            foreach (var gpu in graphicsCards)
            {
                var tagMatches = gpuTagMatches.Where(x => x.GraphicsCardId == gpu.Id).ToList();
                if (tagMatches.Any())
                    gpu.GraphicsCardsTagMatches = tagMatches;

                context.GraphicsCards.Add(gpu);
            }

            var storageDevices = new[]
            {
                new Storage
                {
                    Id = 1, Name = "Crucial BX500", Interface = StorageInterface.SATA, Capacity = 480,
                    Type = StorageType.SSD, Price = 219, ReadSpeed = 540, WriteSpeed = 500, Brand = "Crucial"
                },
                new Storage
                {
                    Id = 2, Name = "Kingston A2000", Interface = StorageInterface.NVME, Capacity = 500,
                    Type = StorageType.SSD, Price = 280, ReadSpeed = 2200, WriteSpeed = 2000, Brand = "Kingston A2000"
                },
                new Storage
                {
                    Id = 3, Name = "WD Blue SN550", Interface = StorageInterface.NVME, Capacity = 1000,
                    Type = StorageType.SSD, Price = 459, ReadSpeed = 2400, WriteSpeed = 1950, Brand = "WD"
                },
                new Storage
                {
                    Id = 4, Name = "Samsung 970 EVO", Interface = StorageInterface.NVME, Capacity = 1000,
                    Type = StorageType.SSD, Price = 629, ReadSpeed = 3400, WriteSpeed = 2500, Brand = "Samsung"
                },
                new Storage
                {
                    Id = 5, Name = "Corsair MP400", Interface = StorageInterface.NVME, Capacity = 2000,
                    Type = StorageType.SSD, Price = 1399, ReadSpeed = 3480, WriteSpeed = 3000, Brand = "Corsair"
                },
                new Storage
                {
                    Id = 6, Name = "WD Blue", Interface = StorageInterface.SATA, Capacity = 2000,
                    Type = StorageType.HDD, Price = 249, ReadSpeed = 147, WriteSpeed = 147, Brand = "WD"
                },
                new Storage
                {
                    Id = 7, Name = "Seagate Barracuda", Interface = StorageInterface.SATA, Capacity = 4000,
                    Type = StorageType.HDD, Price = 439, ReadSpeed = 190, WriteSpeed = 190, Brand = "Seagate"
                },
            };
            
            var storageTagMatches = new[]
            {
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[0], MatchLevel = 1.9,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[1], MatchLevel = 1.9,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[2], MatchLevel = 1.7,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[3], MatchLevel = 1.6,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[4], MatchLevel = 0.8,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[5], MatchLevel = 0.8,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[6], MatchLevel = 1.7,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[7], MatchLevel = 0.8,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[8], MatchLevel = 0.9,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[9], MatchLevel = 0.9,},
                new Storage.StorageTagMatch {StorageId = 1, Tag = tags[10], MatchLevel = 1.7,},
                
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[0], MatchLevel = 1.7,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[1], MatchLevel = 1.7,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[2], MatchLevel = 1.9,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[3], MatchLevel = 1.8,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[4], MatchLevel = 2,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[5], MatchLevel = 1.6,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[6], MatchLevel = 1.85,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[7], MatchLevel = 1.6,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[8], MatchLevel = 1.2,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[9], MatchLevel = 1.1,},
                new Storage.StorageTagMatch {StorageId = 2, Tag = tags[10], MatchLevel = 1.75,},
                
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[0], MatchLevel = 1.65,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[1], MatchLevel = 1.65,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[2], MatchLevel = 1.9,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[3], MatchLevel = 1.85,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[4], MatchLevel = 2,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[5], MatchLevel = 1.65,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[6], MatchLevel = 1.87,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[7], MatchLevel = 1.62,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[8], MatchLevel = 1.25,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[9], MatchLevel = 1.67,},
                new Storage.StorageTagMatch {StorageId = 3, Tag = tags[10], MatchLevel = 1.79,},
                
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[0], MatchLevel = 1.6,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[1], MatchLevel = 1.6,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[2], MatchLevel = 1.9,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[3], MatchLevel = 1.87,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[4], MatchLevel = 2,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[5], MatchLevel = 1.68,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[6], MatchLevel = 1.89,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[7], MatchLevel = 1.65,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[8], MatchLevel = 1.26,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[9], MatchLevel = 1.75,},
                new Storage.StorageTagMatch {StorageId = 4, Tag = tags[10], MatchLevel = 1.85,},
                
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[0], MatchLevel = 1.55,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[1], MatchLevel = 1.55,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[2], MatchLevel = 1.9,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[3], MatchLevel = 1.88,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[4], MatchLevel = 2,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[5], MatchLevel = 1.72,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[6], MatchLevel = 1.89,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[7], MatchLevel = 1.65,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[8], MatchLevel = 1.25,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[9], MatchLevel = 1.85,},
                new Storage.StorageTagMatch {StorageId = 5, Tag = tags[10], MatchLevel = 1.79,},
                
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[0], MatchLevel = 1,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[1], MatchLevel = 1,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[2], MatchLevel = 0.5,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[3], MatchLevel = 0.7,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[4], MatchLevel = 0.5,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[5], MatchLevel = 0.5,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[6], MatchLevel = 0.8,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[7], MatchLevel = 0.25,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[8], MatchLevel = 0.25,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[9], MatchLevel = 0.25,},
                new Storage.StorageTagMatch {StorageId = 6, Tag = tags[10], MatchLevel = 0.6,},
                
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[0], MatchLevel = 1,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[1], MatchLevel = 1,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[2], MatchLevel = 0.5,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[3], MatchLevel = 0.71,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[4], MatchLevel = 0.4,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[5], MatchLevel = 0.51,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[6], MatchLevel = 0.51,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[7], MatchLevel = 0.26,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[8], MatchLevel = 0.26,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[9], MatchLevel = 0.26,},
                new Storage.StorageTagMatch {StorageId = 7, Tag = tags[10], MatchLevel = 0.61,},

            };
            
            foreach (var storage in storageDevices)
            {
                var tagMatches = storageTagMatches.Where(x => x.StorageId == storage.Id).ToList();
                if (tagMatches.Any())
                    storage.StorageTagMatches = tagMatches;

                context.Storage.Add(storage);
            }

            context.SaveChanges();

            var powerSupplies = new[]
            {
                new PowerSupply
                    {Id = 1, Name = "SilentiumPC Elementum E2", Power = 450, Price = 165, Brand = "SilentiumPC"},
                new PowerSupply
                    {Id = 2, Name = "SilentiumPC Vero L3 Bronze", Power = 500, Price = 205, Brand = "SilentiumPC"},
                new PowerSupply
                    {Id = 3, Name = "SilentiumPC Supremo FM2 Gold", Power = 750, Price = 449, Brand = "SilentiumPC"},
                new PowerSupply
                    {Id = 4, Name = "be quiet! Straight Power 11 Gold", Power = 750, Price = 620, Brand = "be quiet!"},
                new PowerSupply {Id = 5, Name = "Corsair HX850 Platinum", Power = 850, Price = 899, Brand = "Corsair"},
                new PowerSupply {Id = 6, Name = "Corsair RM1000x Gold", Power = 1000, Price = 899, Brand = "Corsair"},
            };

            var psuTagMatches = new[]
            {
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[0], MatchLevel = 1.9,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[1], MatchLevel = 1.85,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[2], MatchLevel = 1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[3], MatchLevel = 1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[4], MatchLevel = 0.7,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[5], MatchLevel = 0.6,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[6], MatchLevel = 1.1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[7], MatchLevel = 0.6,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[8], MatchLevel = 0.9,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[9], MatchLevel = 0.6,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 1, Tag = tags[10], MatchLevel = 0.5,},

                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[0], MatchLevel = 1.85,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[1], MatchLevel = 1.80,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[2], MatchLevel = 1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[3], MatchLevel = 1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[4], MatchLevel = 0.75,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[5], MatchLevel = 1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[6], MatchLevel = 1.6,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[7], MatchLevel = 1.2,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[8], MatchLevel = 1.25,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[9], MatchLevel = 1.4,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 2, Tag = tags[10], MatchLevel = 1.25,},
                
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[0], MatchLevel = 1.45,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[1], MatchLevel = 1.45,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[2], MatchLevel = 1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[3], MatchLevel = 1.86},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[4], MatchLevel = 1.25,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[5], MatchLevel = 1.75,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[6], MatchLevel = 1.95,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[7], MatchLevel = 1.95,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[8], MatchLevel = 1.9,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[9], MatchLevel = 1.9,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 3, Tag = tags[10], MatchLevel = 1.8,},
                
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[0], MatchLevel = 1.4,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[1], MatchLevel = 1.4,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[2], MatchLevel = 1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[3], MatchLevel = 1.89},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[4], MatchLevel = 1.75,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[5], MatchLevel = 1.78,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[6], MatchLevel = 1.9,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[7], MatchLevel = 1.98,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[8], MatchLevel = 1.92,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[9], MatchLevel = 1.92,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 4, Tag = tags[10], MatchLevel = 1.75,},
                
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[0], MatchLevel = 1.35,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[1], MatchLevel = 1.35},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[2], MatchLevel = 1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[3], MatchLevel = 1.82},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[4], MatchLevel = 1.65,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[5], MatchLevel = 1.74,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[6], MatchLevel = 1.92,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[7], MatchLevel = 1.94,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[8], MatchLevel = 1.91,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[9], MatchLevel = 1.91,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 5, Tag = tags[10], MatchLevel = 1.85,},
                
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[0], MatchLevel = 1.3,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[1], MatchLevel = 1.3,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[2], MatchLevel = 1,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[3], MatchLevel = 1.89},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[4], MatchLevel = 1.82,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[5], MatchLevel = 1.78,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[6], MatchLevel = 1.92,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[7], MatchLevel = 1.99,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[8], MatchLevel = 1.94,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[9], MatchLevel = 1.94,},
                new PowerSupply.PowerSupplyTagMatch {PowerSupplyId = 6, Tag = tags[10], MatchLevel = 1.9,},
            };
            
            foreach (var psu in powerSupplies)
            {
                var tagMatches = psuTagMatches.Where(x => x.PowerSupplyId == psu.Id).ToList();
                if (tagMatches.Any())
                    psu.PowerSupplyTagMatches = tagMatches;

                context.PowerSupplies.Add(psu);
            }

            context.SaveChanges();

            var cases = new[]
            {
                new Case
                {
                    Id = 1, Name = "SilentiumPC Armis AR1", FormFactor = MotherboardFormFactor.microATX,
                    Price = 129, Brand = "SilentiumPC"
                },
                new Case
                {
                    Id = 2, Name = "SilentiumPC Signum SG7V", FormFactor = MotherboardFormFactor.ATX, Price = 387,
                    Brand = "SilentiumPC"
                },
                new Case
                {
                    Id = 3, Name = "be quiet! Pure Base 500", FormFactor = MotherboardFormFactor.ATX, Price = 299,
                    Brand = "be quiet!"
                },
                new Case
                {
                    Id = 4, Name = "Fractal Design Define 7 Compact", FormFactor = MotherboardFormFactor.ATX,
                    Brand = "Fractal Design",
                    Price = 535
                },
                new Case
                {
                    Id = 5, Name = "Phanteks Eclipse P500A", FormFactor = MotherboardFormFactor.ATX,
                    Price = 689, Brand = "Phanteks"
                },
                new Case
                {
                    Id = 6, Name = "be quiet! Silent Base 802", FormFactor = MotherboardFormFactor.ATX,
                    Price = 759, Brand = "be quiet!"
                },
                new Case
                {
                    Id = 7, Name = "SilentiumPC Ventrum VT2", FormFactor = MotherboardFormFactor.ATX,
                    Price = 179, Brand = "SilentiumPC"
                }
            };
            
            var caseTagMatches = new[]
            {
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[0], MatchLevel = 1.9,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[1], MatchLevel = 1.85,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[2], MatchLevel = 1.65,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[3], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[4], MatchLevel = 0.8,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[5], MatchLevel = 0.75,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[6], MatchLevel = 0.9,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[7], MatchLevel = 0.75,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[8], MatchLevel = 0.85,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[9], MatchLevel = 0.75,},
                new Case.CaseTagMatch {CaseId = 1, Tag = tags[10], MatchLevel = 0.75,},
                
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[0], MatchLevel = 1.7,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[1], MatchLevel = 1.5,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[2], MatchLevel = 1.2,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[3], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[4], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[5], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[6], MatchLevel = 1.5,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[7], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[8], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[9], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 2, Tag = tags[10], MatchLevel = 1,},
                
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[0], MatchLevel = 1.6,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[1], MatchLevel = 1.5,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[2], MatchLevel = 1.2,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[3], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[4], MatchLevel = 1.65,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[5], MatchLevel = 1.5,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[6], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[7], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[8], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[9], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 3, Tag = tags[10], MatchLevel = 1.25,},
                
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[0], MatchLevel = 1.85,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[1], MatchLevel = 1.8,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[2], MatchLevel = 1.65,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[3], MatchLevel = 1.7,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[4], MatchLevel = 1.75,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[5], MatchLevel = 1.55,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[6], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[7], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[8], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[9], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 4, Tag = tags[10], MatchLevel = 1.15,},
                
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[0], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[1], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[2], MatchLevel = 0.8,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[3], MatchLevel = 1.33,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[4], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[5], MatchLevel = 1.75,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[6], MatchLevel = 1.75,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[7], MatchLevel = 1.65,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[8], MatchLevel = 1.65,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[9], MatchLevel = 1.65,},
                new Case.CaseTagMatch {CaseId = 5, Tag = tags[10], MatchLevel = 1.9,},
                
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[0], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[1], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[2], MatchLevel = 0.8,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[3], MatchLevel = 1.33,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[4], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[5], MatchLevel = 1.75,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[6], MatchLevel = 1.75,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[7], MatchLevel = 1.65,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[8], MatchLevel = 1.65,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[9], MatchLevel = 1.65,},
                new Case.CaseTagMatch {CaseId = 6, Tag = tags[10], MatchLevel = 1.9,},
                
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[0], MatchLevel = 1.75,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[1], MatchLevel = 1.7,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[2], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[3], MatchLevel = 1.25,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[4], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[5], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[6], MatchLevel = 1.45,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[7], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[8], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[9], MatchLevel = 1,},
                new Case.CaseTagMatch {CaseId = 7, Tag = tags[10], MatchLevel = 1.1,},
            };
            
            foreach (var pcCase in cases)
            {
                var tagMatches = caseTagMatches.Where(x => x.CaseId == pcCase.Id).ToList();
                if (tagMatches.Any())
                    pcCase.CaseTagMatches = tagMatches;

                context.Cases.Add(pcCase);
            }

            context.SaveChanges();

            var builds = new[]
            {
                new Build
                {
                    Id = 1, Name = "Minimalizm", Description = "Idealny prezent na Dzień Matki", ProcessorId = 8,
                    MotherboardId = 3, MemoryId = 3,
                    Storage = new[] {storageDevices[0]}, PowerSupplyId = 1, CaseId = 1, Price = 1399,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1hE1YKUf7kMSvpvh8hGXGIxLqBbn1LMDT"
                },
                new Build
                {
                    Id = 2, Name = "Warstwy", Description = "Gwarantowana odporność na wycieki pamięci",
                    ProcessorId = 5, MotherboardId = 5, MemoryId = 6, Storage = new[] {storageDevices[4]},
                    GraphicsCardId = 3, PowerSupplyId = 4, CaseId = 4, Price = 10499,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1oJx-Klp-H72BYYJZmZ-WNOGlKnVd6Uuz"
                },
                new Build
                {
                    Id = 3, Name = "Kowalski", Description = "W zestawie schabowy z ziemniakami i zasmażaną kapustą",
                    ProcessorId = 7, MotherboardId = 6, MemoryId = 3, Storage = new[] {storageDevices[0]},
                    GraphicsCardId = 2, PowerSupplyId = 2, CaseId = 7, Price = 2999,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1VZzUmcmSpmInAhGiomuSVAO3cAAxrx11"
                },
                new Build
                {
                    Id = 4, Name = "Zestaw Młodego Streamera", Description = "Poggers", ProcessorId = 3,
                    MotherboardId = 4,
                    MemoryId = 2, GraphicsCardId = 4, Storage = new[] {storageDevices[2]}, PowerSupplyId = 3,
                    CaseId = 3, Price = 4999,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1PE1XNrBNvlKwN08eQKALi6S09wjVS-Ob"
                },
                new Build
                {
                    Id = 5, Name = "4k/60fps", Description = "*tylko z wyłączonym ray tracingiem", ProcessorId = 5,
                    MotherboardId = 5, MemoryId = 4, GraphicsCardId = 7,
                    Storage = new[] {storageDevices[3], storageDevices[6]}, PowerSupplyId = 5, CaseId = 5, Price = 13299,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1bDQG9JcDjLupbE_LAIo5LJ5KnRQinWZ3"
                },
                new Build
                {
                    Id = 6, Name = "Korpo", Description = "Dołączamy fakturę", ProcessorId = 2, MotherboardId = 6,
                    MemoryId = 1, Storage = new[] {storageDevices[2]}, PowerSupplyId = 2, CaseId = 1, Price = 2499,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1hE1YKUf7kMSvpvh8hGXGIxLqBbn1LMDT"
                },
                new Build
                {
                    Id = 7, Name = "Komunia", Description = "Komputer do nauki", ProcessorId = 4, MotherboardId = 1,
                    MemoryId = 3, GraphicsCardId = 3, Storage = new[] {storageDevices[0]}, PowerSupplyId = 2,
                    CaseId = 7, Price = 3399,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1VZzUmcmSpmInAhGiomuSVAO3cAAxrx11"
                },
                new Build
                {
                    Id = 8, Name = "Cisza", Description = "Leczy nerwicę natręctw", ProcessorId = 2, MotherboardId = 6,
                    MemoryId = 2, Storage = new [] {storageDevices[0]}, PowerSupplyId = 4, CaseId = 4, Price = 2449,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1oJx-Klp-H72BYYJZmZ-WNOGlKnVd6Uuz"
                },
                new Build
                {
                    Id = 9, Name = "AMD", Description = "Zaawansowane małe urządzenia", ProcessorId = 10, MotherboardId = 5,
                    MemoryId = 5, GraphicsCardId = 11, Storage = new [] {storageDevices[4]}, PowerSupplyId = 6, CaseId = 6, Price = 9999,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1S60ialDxd_1txtaVOX76JSvrkDbLODrt"
                },            
                new Build
                {
                    Id = 10, Name = "Balans", Description = "Balansuje pomiędzy ceną a jakością", ProcessorId = 3, MotherboardId = 4,
                    MemoryId = 1, Storage = new[] {storageDevices[1]}, GraphicsCardId = 3, PowerSupplyId = 3, CaseId = 1, Price = 4449,
                    PhotoUrl = "https://drive.google.com/uc?export=view&id=1hE1YKUf7kMSvpvh8hGXGIxLqBbn1LMDT"
                }
            };

            var buildsTagMatches = new[]
            {
                new Build.BuildTagMatch {BuildId = 1, Tag = tags[0], MatchLevel = 2.0,},
                new Build.BuildTagMatch {BuildId = 1, Tag = tags[1], MatchLevel = 1.7},
                new Build.BuildTagMatch {BuildId = 1, Tag = tags[2], MatchLevel = 1.5},
                new Build.BuildTagMatch {BuildId = 1, Tag = tags[3], MatchLevel = 0.3},
                new Build.BuildTagMatch {BuildId = 1, Tag = tags[4], MatchLevel = 1.4},
                new Build.BuildTagMatch {BuildId = 2, Tag = tags[1], MatchLevel = 1},
                new Build.BuildTagMatch {BuildId = 2, Tag = tags[3], MatchLevel = 1.2},
                new Build.BuildTagMatch {BuildId = 2, Tag = tags[5], MatchLevel = 1.7},
                new Build.BuildTagMatch {BuildId = 2, Tag = tags[7], MatchLevel = 1.4},
                new Build.BuildTagMatch {BuildId = 2, Tag = tags[8], MatchLevel = 2.0},
                new Build.BuildTagMatch {BuildId = 2, Tag = tags[9], MatchLevel = 2.0},
                new Build.BuildTagMatch {BuildId = 3, Tag = tags[0], MatchLevel = 1.7},
                new Build.BuildTagMatch {BuildId = 3, Tag = tags[1], MatchLevel = 1.67},
                new Build.BuildTagMatch {BuildId = 3, Tag = tags[3], MatchLevel = 1.2},
                new Build.BuildTagMatch {BuildId = 3, Tag = tags[6], MatchLevel = 1.2},
                new Build.BuildTagMatch {BuildId = 3, Tag = tags[10], MatchLevel = 1},
                new Build.BuildTagMatch {BuildId = 4, Tag = tags[3], MatchLevel = 1.7},
                new Build.BuildTagMatch {BuildId = 4, Tag = tags[5], MatchLevel = 1.3},
                new Build.BuildTagMatch {BuildId = 4, Tag = tags[6], MatchLevel = 2},
                new Build.BuildTagMatch {BuildId = 4, Tag = tags[7], MatchLevel = 1.5},
                new Build.BuildTagMatch {BuildId = 4, Tag = tags[9], MatchLevel = 1},
                new Build.BuildTagMatch {BuildId = 4, Tag = tags[10], MatchLevel = 1.7},
                new Build.BuildTagMatch {BuildId = 5, Tag = tags[3], MatchLevel = 1.4},
                new Build.BuildTagMatch {BuildId = 5, Tag = tags[5], MatchLevel = 1.75},
                new Build.BuildTagMatch {BuildId = 5, Tag = tags[7], MatchLevel = 1.7},
                new Build.BuildTagMatch {BuildId = 5, Tag = tags[8], MatchLevel = 1.2},
                new Build.BuildTagMatch {BuildId = 5, Tag = tags[9], MatchLevel = 1.7},
                new Build.BuildTagMatch {BuildId = 5, Tag = tags[10], MatchLevel = 2},
                new Build.BuildTagMatch {BuildId = 6, Tag = tags[0], MatchLevel = 1.85},
                new Build.BuildTagMatch {BuildId = 6, Tag = tags[1], MatchLevel = 2},
                new Build.BuildTagMatch {BuildId = 6, Tag = tags[3], MatchLevel = 1.3},
                new Build.BuildTagMatch {BuildId = 6, Tag = tags[5], MatchLevel = 1.1},
                new Build.BuildTagMatch {BuildId = 7, Tag = tags[1], MatchLevel = 0.8},
                new Build.BuildTagMatch {BuildId = 7, Tag = tags[2], MatchLevel = 0.75},
                new Build.BuildTagMatch {BuildId = 7, Tag = tags[4], MatchLevel = 1.65},
                new Build.BuildTagMatch {BuildId = 7, Tag = tags[5], MatchLevel = 2},
                new Build.BuildTagMatch {BuildId = 7, Tag = tags[6], MatchLevel = 1.4},
                new Build.BuildTagMatch {BuildId = 7, Tag = tags[7], MatchLevel = 1.2},
                new Build.BuildTagMatch {BuildId = 7, Tag = tags[9], MatchLevel = 1.42},
                new Build.BuildTagMatch {BuildId = 7, Tag = tags[10], MatchLevel = 1.78},
                new Build.BuildTagMatch {BuildId = 8, Tag = tags[0], MatchLevel = 1.85},
                new Build.BuildTagMatch {BuildId = 8, Tag = tags[1], MatchLevel = 1.75},
                new Build.BuildTagMatch {BuildId = 8, Tag = tags[2], MatchLevel = 1.25},
                new Build.BuildTagMatch {BuildId = 8, Tag = tags[4], MatchLevel = 1.9},
                new Build.BuildTagMatch {BuildId = 8, Tag = tags[3], MatchLevel = 1.35},
                new Build.BuildTagMatch {BuildId = 9, Tag = tags[3], MatchLevel = 1.78},
                new Build.BuildTagMatch {BuildId = 9, Tag = tags[5], MatchLevel = 1.9},
                new Build.BuildTagMatch {BuildId = 9, Tag = tags[7], MatchLevel = 1.7},
                new Build.BuildTagMatch {BuildId = 9, Tag = tags[8], MatchLevel = 1.5},
                new Build.BuildTagMatch {BuildId = 9, Tag = tags[9], MatchLevel = 1.9},
                new Build.BuildTagMatch {BuildId = 9, Tag = tags[10], MatchLevel = 1.86},
                new Build.BuildTagMatch {BuildId = 10, Tag = tags[0], MatchLevel = 1.21},
                new Build.BuildTagMatch {BuildId = 10, Tag = tags[1], MatchLevel = 1.35},
                new Build.BuildTagMatch {BuildId = 10, Tag = tags[3], MatchLevel = 1.44},
                new Build.BuildTagMatch {BuildId = 10, Tag = tags[5], MatchLevel = 1.24},
                new Build.BuildTagMatch {BuildId = 10, Tag = tags[6], MatchLevel = 1.79},
                new Build.BuildTagMatch {BuildId = 10, Tag = tags[10], MatchLevel = 1.56},
            };


            foreach (var build in builds)
            {
                var tagMatches = buildsTagMatches.Where(x => x.BuildId == build.Id).ToList();
                if (tagMatches.Any())
                    build.BuildTagMatches = tagMatches;

                context.Builds.Add(build);
            }

            // TODO - auto calculate price?

            context.SaveChanges();
        }
    }
}