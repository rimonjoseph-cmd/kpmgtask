﻿using KPMG.CRM.Business.Models;
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
        Task<List<BuildingModel>> getall();
        Task<BuildingModel> get(string id);
        bool Block(Guid buildingid);
        bool UnBlock(Guid buildingid);
        Task<BuildingModel> createBuilding(BuildingModel value);
        Task<BuildingModel> updateBuilding(string id, BuildingModel value);
    }
}
