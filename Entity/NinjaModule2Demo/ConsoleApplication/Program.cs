using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System.Data.Entity;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
            //InsertNinja();
            //InsertMultipleNinjas();
            //SimpleNinjaQueries();
            //QueryAndUpdateNinja();
            //QueryUpdateNinjaDisconnected();
            //RetrieveDataWithFind();
            //RetrieveDataWithStoredProc();
            //DeleteNinja();
            //DeleteNinjaWithKeyValue();
            //InsertNinjaWithEquipment();
            //SimpleNinjagraphQuery();
            ProjectionQuery();
            Console.ReadKey();
        }

        private static void InsertNinja()
        {
            var ninja = new Ninja
            {
                Name = "SampsonSan",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(2008, 1, 28),
                ClanId = 1
            };
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.Write;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleNinjas()
        {
            var ninja1 = new Ninja
            {
                Name = "Leonardo",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1984, 1, 1),
                ClanId = 1
            };

            var ninja2 = new Ninja
            {
                Name = "Raphael",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1985, 1, 1),
                ClanId = 1
            };

            //var ninja3 = new Ninja
            //{
            //    Name = "Michelangelo",
            //    ServedInOniwaban = false,
            //    ClanId = 1,
            //    DateOfBirth = new DateTime(1986, 9, 24)
            //};

            //var ninja4 = new Ninja
            //{
            //    Name = "Michelangelo",
            //    ServedInOniwaban = false,
            //    ClanId = 1,
            //    DateOfBirth = new DateTime(1986, 9, 24)
            //};

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.Write;
                context.Ninjas.AddRange(new List<Ninja> { ninja1, ninja2 });
                context.SaveChanges();
            }
        }


        private static void SimpleNinjaQueries()
        {
            using (var context = new NinjaContext())
            {
                //var ninjas = context.Ninjas.ToList();
                //var query = context.Ninjas; retorna o select
                var ninjas = context.Ninjas
                                    //.Where(n => n.Name == "Raphael");
                                    .Where(n => n.DateOfBirth >= new DateTime(1984, 1, 1))
                                    .OrderBy(n => n.Name)
                                    .Skip(1).Take(1)
                                    .FirstOrDefault()
                                    //.FirstOrDefault(n => n.DateOfBirth >= new DateTime(1984, 1, 1));
                                    ;

                //foreach (var ninja in ninjas)
                //{
                //    Console.WriteLine(ninja.Name);
                //}

                Console.WriteLine(ninjas.Name);

            }

        }


        private static void QueryAndUpdateNinja()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.FirstOrDefault();
                ninja.ServedInOniwaban = !ninja.ServedInOniwaban;
                context.SaveChanges();
            }
        }


        private static void QueryUpdateNinjaDisconnected()
        {
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
            }

            ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Attach(ninja);
                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        private static void RetrieveDataWithFind()
        {
            var keypad = 9;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.Find(keypad);
                Console.Write("After Find#1:" + ninja.Name);

                var someNinja = context.Ninjas.Find(keypad);
                Console.Write("After Find#2:" + someNinja.Name);
                ninja = null;
            }

        }

        private static void RetrieveDataWithStoredProc()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninjas = context.Ninjas.SqlQuery("exec GetOldNinjas");
                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
            }
        }

        private static void DeleteNinja()
        {
            //using (var context = new NinjaContext())
            //{
            //    context.Database.Log = Console.WriteLine;
            //    var ninjas = context.Ninjas.FirstOrDefault();
            //    context.Ninjas.Remove(ninjas);
            //    context.SaveChanges();
            //}
            Ninja ninjas;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninjas = context.Ninjas.FirstOrDefault();
                //context.Ninjas.Remove(ninjas);
                //context.SaveChanges();
            }
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Ninjas.Attach(ninjas);
                //context.Ninjas.Remove(ninjas);
                context.Entry(ninjas).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        private static void DeleteNinjaWithKeyValue()
        {
            var keyval = 13;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //var ninja = context.Ninjas.Find(keyval);
                //context.Ninjas.Remove(ninja);
                //context.SaveChanges();

                context.Database.ExecuteSqlCommand("exec DeleteNinjaViaId {0}", keyval);
            }
        }


        private static void InsertNinjaWithEquipment()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = new Ninja
                {
                    Name = "Michelangelo",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1990, 1, 14),
                    ClanId = 1
                };

                var Nunchaku = new NinjaEquipment
                {
                    Name = "Nunchaku1",
                    Type = EquipmentType.Weapon
                };
                var Nunchaku2 = new NinjaEquipment
                {
                    Name = "Nunchaku2",
                    Type = EquipmentType.Weapon
                };

                context.Ninjas.Add(ninja);
                ninja.EquipmentOwned.Add(Nunchaku);
                ninja.EquipmentOwned.Add(Nunchaku2);
                context.SaveChanges();


            }

        }

        private static void SimpleNinjagraphQuery()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //var ninja = context.Ninjas.Include(n => n.EquipmentOwned)
                //                    .FirstOrDefault(a => a.Name.StartsWith("Michelangelo"));

                var ninja = context.Ninjas
                                    .FirstOrDefault(n => n.Name.StartsWith("Michelangelo"));
                Console.WriteLine("Ninja Retrivied: " + ninja.Name);
                context.Entry(ninja).Collection(n => n.EquipmentOwned).Load();

                //var ninja = context.Ninjas
                //                    .FirstOrDefault(n => n.Name.StartsWith("Michelangelo"));
                //Console.WriteLine("Ninja Retrivied: " + ninja.EquipmentOwned.Count());



            }
        }

        private static void ProjectionQuery()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninjas = context.Ninjas
                                    .Select(n => new { n.Name, n.DateOfBirth, n.EquipmentOwned })
                                    .ToList();
            }

        }
    }
}
