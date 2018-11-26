namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        // public string Name { get; set; }
        // public bool IsComplete { get; set; }
        public string clientName {get;set;}
        public string date {get;set;}
        public string paymentMethod {get;set;}
        public string productCode {get;set;}
        public string productDescription {get;set;}
        public string quantity {get;set;}
    }
}