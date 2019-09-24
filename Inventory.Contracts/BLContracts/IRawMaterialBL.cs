using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface IRawMaterialBL : IDisposable
    {
        Task<bool> AddRawMaterialBL(RawMaterial newRawMaterial);
        Task<List<RawMaterial>> GetAllRawMaterialsBL();
        Task<RawMaterial> GetRawMaterialByRawMaterialIDBL(Guid searchRawMaterialID);
        Task<RawMaterial> GetRawMaterialByRawMaterialNameBL(string searchRawMaterialName);
        Task<RawMaterial> GetRawMaterialByRawMaterialCodeBL(string searchRawMaterialCode);
        Task<bool> UpdateRawMaterialBL(RawMaterial updateRawMaterial);
        Task<bool> DeleteRawMaterialBL(Guid deleteRawMaterialID);
    }
}
