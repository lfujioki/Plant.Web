//using Plants.Web.Domain;
using Plants.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Web.Services
{
    public interface IPlantsService
    {
        //List<Plant> GetPlants();
        //Plant GetPlantById(int id);
        int InsertPlant(PlantAddRequest model);
        //void UpdatePlant(PlantUpdateRequest model);
    }
}
