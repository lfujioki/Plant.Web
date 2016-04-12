using Plants.Web.Models.Requests;

namespace Plants.Web.Models.Requests
{
    public class PlantUpdateRequest : PlantAddRequest
    {
        public int Id { get; set; }
    }
}