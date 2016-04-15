//using Plants.Web.Domain;
using Plants.Web.Domain;
using Plants.Web.Models.Requests;
using Plants.Web.Models.Responses;
using Plants.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plants.Web.Controllers.Api
{
    [RoutePrefix("api/plants")]
    public class PlantsApiController : ApiController
    {
        private IPlantsService _plantsService = null;

        public PlantsApiController(IPlantsService plantsService)
        {
            _plantsService = plantsService;
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAllPlants()
        {
            ItemsResponse<Plant> response = new ItemsResponse<Plant>();

            response.Items = _plantsService.GetPlants();

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetOnePlant(int id)
        {
            ItemResponse<Plant> response = new ItemResponse<Plant>();

            response.Item = _plantsService.GetPlantById(id);

            return Request.CreateResponse(response);
        }

        [Route, HttpPost]
        public HttpResponseMessage InsertPlant(PlantAddRequest model)
        {
            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = _plantsService.InsertPlant(model);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdatePlant(PlantUpdateRequest model, int id)
        {
            // If the Model does not pass validation, then return Error response with errors
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();

            _plantsService.UpdatePlant(model);

            return Request.CreateResponse(response);
        }
    }
}
