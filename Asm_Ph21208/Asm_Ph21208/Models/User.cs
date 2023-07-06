namespace Asm_Ph21208.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public string Status { get; set; }
        public virtual List<Role> Roles { get; set;}
        public virtual List<Bill> Bill { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
