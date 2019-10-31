using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Inventory.WCFService
{
    // Developed by Rohit Kumar (Group 4)
    // Creation Date : 2019/10/30
    // Last Modified Date : 

    //Interface for RawMaterialsService class
    [ServiceContract]
    public interface IRawMaterialsService
    {
        [OperationContract]
        List<RawMaterialDataContract> GetRawMaterials();
    }
    
    //RawMaterialDataContract class
    [DataContract]
    public class RawMaterialDataContract
    {
        //Data members
        [DataMember]
        public System.Guid RawMaterialID { get; set; }

        [DataMember]
        public string RawMaterialName { get; set; }

        [DataMember]
        public string RawMaterialCode { get; set; }

        [DataMember]
        public decimal? RawMaterialUnitPrice { get; set; }
    }
}
