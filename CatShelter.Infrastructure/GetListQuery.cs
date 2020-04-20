using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CatShelter.Application;
using Dapper;

namespace CatShelter.Infrastructure
{
    public class GetCatDetailQuery : IGetCatDetailQuery
    {
        public CatDetailDto GetDetail(int id)
        {
            var cs = @"Server=JJ-HQ-DESKTOP\SQLEXPRESS;Database=DDDSamples;Trusted_Connection=True;";
            using (IDbConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                var cat = connection.QuerySingleOrDefault<CatDetailDto>("SELECT Id, Name, Neutered FROM dbo.Cat where id = @Id", new {Id = id});
                if (cat == null)
                {
                    return null;
                }
                var vaccinations = connection.Query<string>("SELECT Disease FROM dbo.Vaccination where id = @Id", new { Id = id });
                var detail = new CatDetailDto() {Id = cat.Id, IsNeutered = cat.IsNeutered, Name = cat.Name};
                detail.Vaccinations.AddRange(vaccinations);
                return detail;
            }
        }
    }

    public class GetListQuery : IGetCatListdQuery
    {
        public IReadOnlyList<CatListItemDto> GetList()
        {
            var cs = @"Server=JJ-HQ-DESKTOP\SQLEXPRESS;Database=DDDSamples;Trusted_Connection=True;";
            using (IDbConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                return connection.Query<CatListItemDto>("SELECT Id, Name FROM dbo.Cat").ToImmutableArray();
            }
        }
    }
}
