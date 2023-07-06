namespace Asm_Ph21208.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int Status { get; set; }
        public string img { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public virtual List<BillDetail> BillDetails { get; set; }
        



        public List<Product> ListProduct()
        {
            var db =new ShoppingDbContext();
            var data = db.Products.ToList();
            return data;
        }
    }
}
