using Biblioteca.Controllers;
using Biblioteca.Models;

class Program
{
    static void Main(string[] args)
    { 
        UserController controller = new UserController();
        bool rodando = true;

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
                    controller.RegistrarUsuario();
                    break;
                case 2:
                    controller.LoginUsuario();
                    break;
                default:
                    Console.WriteLine("Opção inválida ! Forneça uma opção válida para acessar o sistema");
                    break;
            }
        }
    }
}