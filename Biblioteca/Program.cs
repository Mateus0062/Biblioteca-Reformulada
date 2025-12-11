using Biblioteca.Controllers;
using Biblioteca.Models;

class Program
{
    static void Main(string[] args)
    { 
        List<User> usuarios = new List<User>();

        foreach(var i in usuarios)
        {
            Console.WriteLine($"Id: {i.Id}\n Name: {i.UserName}\n Email{i.Email}");
        }
    }
}