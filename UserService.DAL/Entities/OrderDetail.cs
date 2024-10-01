namespace UserService.DAL.Entities
{
    public class OrderDetail
    {
        //[SwaggerIgnore]
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string studySection { get; set; } = null!;
        public int studyHours { get; set; }
        public bool isOnline { get; set; }
        public string teacher { get; set; } = null!;
    }
}
