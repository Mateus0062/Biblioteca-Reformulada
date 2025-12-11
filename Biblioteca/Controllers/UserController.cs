using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Controllers
{
    public class UserController
    {
        public void RegistrarUsuario(List<User> usuarios)
        {
            Console.WriteLine("Digite seu Nome: ");
            string nome = Console.ReadLine()  ?? string.Empty;

            Console.WriteLine("Digite seu E-mail: ");
            string email = Console.ReadLine() ?? string.Empty;

            if (usuarios.Any(cadastrado => cadastrado.Email == email))
            {
                Console.WriteLine("Usuário já cadastrado. Informe um outro e-mail válido.");
                return;
            }

            Console.WriteLine("Digite sua Senha: ");
            string password = Console.ReadLine() ?? string.Empty;

            usuarios.Add(new User {
                UserName = nome,
                Email = email, 
                Password = password
            });

            Console.WriteLine("Usuário cadastrado com sucesso !");
        }

        public void LoginUsuario(string email, string senha, List<User> usuarios)
        {
            var UserEncontrado = usuarios.FirstOrDefault(s => s.Email == email && s.Password == senha);

            if (UserEncontrado.Email == "admin@gmail.com" && UserEncontrado.Password == "SenhaAdmin")
            {
                Console.WriteLine($"Olá, {UserEncontrado.UserName} ! Redirecionando para o painel de Administrador");
            }

            if (UserEncontrado != null)
            {
                Console.WriteLine($"Seja bem vindo! {UserEncontrado.UserName}\n");
                Console.WriteLine("Redirecionando para o painel de aluguel de livros! ");
            }
        } 
    }
}
