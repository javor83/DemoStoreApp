namespace RestoreApp.Models
{
    public class DTO_Product_Select
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Preview { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

    }
    
}
