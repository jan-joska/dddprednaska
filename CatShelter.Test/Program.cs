using System;
using CatShelter.Domain.CatEvidence;
using CatShelter.Domain.FoodStorage;
using CatShelter.Domain.FoodStorage.Commands;
using CatShelter.Domain.FoodStorage.Queries;
using CatShelter.Infrastructure;

namespace CatShelter.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            

            var sf = Configuration.CreateSessionFactory();

            //Cat c = new Cat("Mourek");  


            using (var session = sf.OpenSession())
            {
                var r = new CatRepository(session);
                {
                    var c = r.GetById(1);

                    foreach (var item in c.Vaccinations)
                    {
                        Console.WriteLine(item);
                    }

                    //c.RegisterVaccination(new VaccinationInfo("rabies", DateTime.Now));
                    if (!c.Neutered)
                    {
                        c.NeuterThisCat();
                    }

                    r.Save(c);
                    session.Flush();
                }
                
                session.Close();
            }

            
            


            Console.ReadLine();
        }
    }
}
