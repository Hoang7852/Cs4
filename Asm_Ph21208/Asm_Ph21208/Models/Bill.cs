namespace Asm_Ph21208.Models
{
    public class Bill
    {
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserID { get; set; }
        public int Status { get; set; }
        public List<BillDetail> BillDetails { get;set; }
        public User User { get; set; }
    }
}
