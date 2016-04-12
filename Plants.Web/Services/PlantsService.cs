//using Plants.Web.Domain;
using Plants.Web.Models.Requests;
using Starter.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plants.Web.Services
{
    public class PlantsService : BaseService, IPlantsService
    {
        //public List<Plant> GetPlants()
        //{
        //    List<Plant> list = null;

        //    DataProvider.ExecuteCmd(GetConnection, "dbo.Plants_GetAll"
        //       , inputParamMapper: null
        //       , map: delegate (IDataReader reader, short set)
        //       {
        //           Plant plant = MapPlant(reader);

        //           if (list == null)
        //           {
        //               list = new List<Plant>();
        //           }
        //           list.Add(plant);
        //       }
        //       );

        //    return list;
        //}

        //public Plant GetPlantById(int id)
        //{
        //    Plant p = null;

        //    DataProvider.ExecuteCmd(GetConnection, "dbo.Plants_GetById"
        //       , inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //       {
        //           paramCollection.AddWithValue("@Id", id);
        //       }
        //       , map: delegate (IDataReader reader, short set)
        //       {
        //           p = MapPlant(reader);
        //       }
        //       );

        //    return p;
        //}

        public int InsertPlant(PlantAddRequest model)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Plants_Insert"
                   , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                   {
                       paramCollection.AddWithValue("@Name", model.Name);
                       paramCollection.AddWithValue("@Description", model.Description);
                       paramCollection.AddWithValue("@CategoryId", model.CategoryId);
                       paramCollection.AddWithValue("@SizeId", model.SizeId);
                       paramCollection.AddWithValue("@IsBioluminescent", model.IsBioluminescent);

                       SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                       p.Direction = System.Data.ParameterDirection.Output;

                       paramCollection.Add(p);
                   }
                   , returnParameters: delegate (SqlParameterCollection param)
                   {
                       int.TryParse(param["@Id"].Value.ToString(), out id);
                   }
                   );

            return id;
        }

        public void UpdatePlant(PlantUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Plants_Update"
                   , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                   {
                       paramCollection.AddWithValue("@Id", model.Id);
                       paramCollection.AddWithValue("@Name", model.Name);
                       paramCollection.AddWithValue("@Description", model.Description);
                       paramCollection.AddWithValue("@Keywords", model.Keywords);
                       paramCollection.AddWithValue("@CategoryId", model.CategoryId);
                       paramCollection.AddWithValue("@SizeId", model.SizeId);
                       paramCollection.AddWithValue("@IsBioluminescent", model.IsBioluminescent);
                   }
                   , returnParameters: delegate (SqlParameterCollection param)
                   {
                   }
                   );
        }


        ////------------------------------------------------------

        //private Plant MapPlant(IDataReader reader)
        //{
        //    Plant p = new Plant();
        //    int startingIndex = 0; //startingOrdinal

        //    p.Id = reader.GetSafeInt32(startingIndex++);
        //    p.Name = reader.GetSafeString(startingIndex++);
        //    p.Description = reader.GetSafeString(startingIndex++);
        //    p.Keyword = reader.GetSafeString(startingIndex++);
        //    p.CategoryId = reader.GetSafeInt32(startingIndex++);
        //    p.SizeId = reader.GetSafeInt32(startingIndex++);
        //    p.IsBioluminescent = reader.GetSafeBool(startingIndex++);

        //    return p;
        //}
    }
}