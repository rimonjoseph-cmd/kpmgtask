using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Building
{
    public interface IBuildingBLL
    {
        Task<EntityCollection> getall();
        bool Block(Guid buildingid);
        bool UnBlock(Guid buildingid);
    }
}
