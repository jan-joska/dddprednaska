using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CatShelter.Application;
using CatShelter.Domain.CatEvidence;
using CatShelter.Domain.FoodStorage;
using CatShelter.Domain.FoodStorage.Commands;
using CatShelter.Domain.FoodStorage.Queries;
using CatShelter.Infrastructure;
using NHibernate;

namespace CatShelter.Test
{
    class Program
    {

        static async Task Main(string[] args)
        {
            //var sf = Configuration.CreateSessionFactory();
            //var uowf = new UnitOfWorkFactory(sf);
            //var catRep = new CatRepository();   
            //var createCatUc = new CreateCatUseCase(uowf, catRep);
            //var id = createCatUc.CreateCat(new CreateCatDto("Micka"));
            //Console.WriteLine(id);

            var q = new GetListQuery();
            foreach (var item in q.GetList())
            {
                Console.WriteLine(item);
            }

            var q2 = new GetCatDetailQuery();
            var detail = q2.GetDetail(1);
            Console.WriteLine(detail);








            //var sf = Configuration.CreateSessionFactory();
            //var uc = new CreateCatUseCase(sf);
            //Console.WriteLine(await uc.CreateAsync(new CreateCatDto("Fousek")));

            //Console.ReadLine();


            //SupplyItem i = new SupplyItem("Granule", new Unit("kg"), new UnitCount(1.0d));
            //ICommand cmd = new AddToSupplyRoom(i);
            //cmd.Execute();
            //var query = new GetStoreContentQuery();
            //var items = query.Execute();
            //foreach (SupplyItem item in items)
            //{
            //    Console.WriteLine(item);
            //}



            //Cat c = new Cat("Mourek");  


            //using (var session = sf.OpenSession())
            //{
            //    var r = new CatRepository(session);
            //    {
            //        var result = r.GetById(1);

            //        if (result.HasNoValue)
            //        {
            //            return;
            //        }

            //        var c = result.Value;

            //        c.AddRecord("Evaluation of health completed");

            //        foreach (var item in c.Vaccinations)
            //        {
            //            Console.WriteLine(item);
            //        }

            //        if (c.MayBeVaccinated(DateTime.Now))
            //        {
            //            c.AddRecord("Cat may be vaccinated");
            //        }

            //        //c.RegisterVaccination(new VaccinationInfo("rabies", DateTime.Now));
            //        if (!c.Neutered)
            //        {
            //            c.NeuterThisCat();
            //        }

            //        r.Save(c);
            //        session.Flush();
            //    }

            //    session.Close();
            //}





            Console.ReadLine();
        }
    }
}
