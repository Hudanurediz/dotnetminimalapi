namespace DotnetMinimalApi.Entities
{
    public class RequestData:BaseEntity
    {
        public string Key { get; set; }
        public string Data { get; set; }

        public RequestData(string key, string data) : base()
        {
            Key = key;
            Data = data;
        }
    }
}
