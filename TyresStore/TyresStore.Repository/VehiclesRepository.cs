﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyresStore.Repository.Models;

namespace TyresStore.Repository
{
    public class VehiclesRepository
    {
        TyresStoreContext tyresContext = new TyresStoreContext();

        public int VehicleId { get; private set; }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return tyresContext.Vehicles.FirstOrDefault(x => x.ID == VehicleId);
        }
        public List<Vehicle> GetVehicles()
        {
            return tyresContext.Vehicles.ToList();
        }
    }
}
