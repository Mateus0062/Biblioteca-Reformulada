 namespace Biblioteca.Models
{
    public enum UserRole
    {
        Padrao,
        Admin,
    } 
    
    public class User
    {
        private static int _proximoId = 0;
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Padrao;

        public User()
        {
            Id = _proximoId++;
        }
    }
}
