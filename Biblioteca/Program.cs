using Biblioteca.Controllers;
using Biblioteca.Models;

class Program
{
    static void Main(string[] args)
    { 
        UserController controller = new UserController();
        List<User> usuarios = new List<User>();
        bool rodando = true;

        InicializarAdmin(usuarios, controller);

        while (rodando == true)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("===== Selecione uma Opção =====");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Login");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("==============================");

            int op = int.Parse(Console.ReadLine()!);

            switch (op)
            {
                case 0:
                    Console.WriteLine("Encerrando o sistema");
                    rodando = false;
                    break;
                case 1:
                    controller.RegistrarUsuario(usuarios);
                    break;
                case 2:
                    controller.LoginUsuario(usuarios);
                    break;
                default:
                    Console.WriteLine("Opção inválida ! Forneça uma opção válida para acessar o sistema");
                    break;
            }

            foreach (var i in usuarios)
            {
                Console.WriteLine($"Id: {i.Id}\n Name: {i.UserName}\n Email: {i.Email}\n Senha: {i.Password}");
            }
        }
    }

    static void InicializarAdmin(List<User> usuarios, UserController controller)
    {
        usuarios.Add(new User
        {
            UserName = "Admin",
            Email = "admin@biblioteca.com",
            Password = controller.CalculateMD5Hash("SenhaAdmin123"),
            Role = UserRole.Admin
        });
    }
}