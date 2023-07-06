namespace Asm_Ph21208.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
