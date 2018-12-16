namespace Models.DTOs
{
    public class CheckUniqueDTO
    {
        public string TableName { get; set; }
        public string[] Fields { get; set; }
        public string[] Values { get; set; }
    }
}
