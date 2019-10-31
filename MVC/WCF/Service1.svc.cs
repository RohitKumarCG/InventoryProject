using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Inventory.WCFService
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/10/30
    // Last Modified Date : 2019/10/31

    public class RawMaterialService : IRawMaterialsService
    {
        public List<RawMaterialDataContract> GetRawMaterials()
        {
            //Create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(System.Configuration.ConfigurationManager.ConnectionStrings["Inventory.WCFService.Properties.Settings.Setting"].ProviderName);

            //Create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Inventory.WCFService.Properties.Settings.Setting"].ConnectionString;

            //Create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "Team_D.GetAllRawMaterials";
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            //Create adapter
            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            //Create dataset
            DataSet dataSet = new DataSet();

            //Execute
            adapter.Fill(dataSet);

            //Convert datatable to collection
            List<RawMaterialDataContract> rawMaterials = dataSet.Tables[0]
                .AsEnumerable()
                .Select(p => new RawMaterialDataContract()
                {
                    RawMaterialID = p.Field<System.Guid>("RawMaterialID"),
                    RawMaterialName = p.Field<string>("RawMaterialName"),
                    RawMaterialCode = p.Field<string>("RawMaterialCode"),
                    RawMaterialUnitPrice = p.Field<decimal>("RawMaterialUnitPrice")
                })
                .ToList();

            return rawMaterials;
        }
    }
}
