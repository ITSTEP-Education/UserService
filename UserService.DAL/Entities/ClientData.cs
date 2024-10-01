using UserService.DAL.Filters;

namespace UserService.DAL.Entities
{
    
    public class ClientData
    {
        [SwaggerIgnore]
        public int id { get; set; }
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public int age { get; set; }
        public string mobile { get; set; } = null!;

        [SwaggerIgnore]
        public ClientOrder? clientOrder { get; set; }
    }
}
