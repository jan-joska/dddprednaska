using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace CatShelter.Domain.FoodStorage.Queries
{
    public interface IQuery<T>
    {
        T Execute();
    }

    public class StoreItemDataObject
    {
        public string Name { get;set;}
        public string Unit { get; set; }
        public float UnitCount { get; set; }
    }

    public class GetStoreContentQuery : IQuery<IReadOnlyList<SupplyItem>>
    {
        public IReadOnlyList<SupplyItem> Execute()
        {
            var cs = @"Server=JJ-HQ-DESKTOP\SQLEXPRESS;Database=DDDSamples;Trusted_Connection=True;";
            using (IDbConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                var list = connection.Query<StoreItemDataObject>("SELECT * FROM dbo.SupplyItem");
                return list.Select(i => new SupplyItem(i.Name, new Unit(i.Unit), new UnitCount(i.UnitCount))).ToImmutableArray();
            }
        }
    }
}
