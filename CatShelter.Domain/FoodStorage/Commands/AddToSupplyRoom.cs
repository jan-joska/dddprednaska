using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Dapper;
using Dapper.Contrib.Extensions;

namespace CatShelter.Domain.FoodStorage.Commands
{
    public interface ICommand
    {
        void Execute();
    }

    public class AddToSupplyRoom : ICommand
    {
        private readonly SupplyItem _item;

        public AddToSupplyRoom(SupplyItem item)
        {
            _item = item;
        }

        public void Execute()
        {
            var cs = @"Server=JJ-HQ-DESKTOP\SQLEXPRESS;Database=DDDSamples;Trusted_Connection=True;";
            using (IDbConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                connection.Execute("INSERT INTO dbo.SupplyItem (Name,Unit,UnitCount) VALUES (@Name, @Unit, @UnitCount)", new
                {
                    Name = _item.Name,
                    Unit = _item.Unit.Name,
                    UnitCount = _item.UnitCount.Value
                });
            }
        }
    }
}