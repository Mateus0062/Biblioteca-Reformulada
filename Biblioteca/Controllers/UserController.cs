using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
                Password = CalculateMD5Hash(password)
            });

            Console.WriteLine("Usuário cadastrado com sucesso !");
        }

        public void LoginUsuario(List<User> usuarios)
        {
            Console.WriteLine("Digite seu Email: ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite sua Senha: ");
            string senha = Console.ReadLine() ?? string.Empty;

            var UserEncontrado = usuarios.FirstOrDefault(s => s.Email == email && s.Password == senha);

            if (UserEncontrado.Email == "admin@gmail.com" && UserEncontrado.Password == "SenhaAdmin")
            {
                Console.WriteLine($"Olá, {UserEncontrado.UserName} ! Redirecionando para o painel de Administrador");
            } else
            {
                if (UserEncontrado != null)
                {
                    Console.WriteLine($"Seja bem vindo! {UserEncontrado.UserName}\n");
                    Console.WriteLine("Redirecionando para o painel de aluguel de livros! ");
                } else
                {
                    Console.WriteLine("Usuário não encontrado");
                }
            }
        }
        
        public string CalculateMD5Hash(string senha)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
