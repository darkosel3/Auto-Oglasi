namespace CarAds.Models
{

    public class MongoDBSettings
    {
        public string AtlasURI { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString => AtlasURI;
    }


}