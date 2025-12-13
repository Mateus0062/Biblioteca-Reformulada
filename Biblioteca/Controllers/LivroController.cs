using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Controllers
{
    public class LivroController
    {
        private List<Livro> _livros = new List<Livro>();

        private EmprestimoController _emprestimoController;

        public LivroController(EmprestimoController emprestimoController)
        {
            _emprestimoController = emprestimoController;
            _livros = new List<Livro>();

            _livros.Add(new Livro { Titulo = "O Senhor dos Anéis", Autor = "J.R.R Tolkien"});
            _livros.Add(new Livro { Titulo = "Ao Farol", Autor = "Virginia Woolf"});
            _livros.Add(new Livro { Titulo = "A casa dos espíritos", Autor = "Isabel Allende" });
            _livros.Add(new Livro { Titulo = "Memórias Póstumas de Brás Cubas", Autor = "Machado de Assis" });
            _livros.Add(new Livro { Titulo = "Cem Anos de Solidão", Autor = "Gabriel García Márquez" });
            _livros.Add(new Livro { Titulo = "O rei lear", Autor = "Wiliam Shakespeare" });
        }

        public void ConsultarLivros()
        {
            Console.WriteLine("\n===== ACERVO DA BIBLIOTECA =====");
            if (!_livros.Any())
            {
                Console.WriteLine("O acervo está vazio.");
                return;
            }

            foreach (var livro in _livros)
            {
                bool alugado = _emprestimoController.LivroEstaAlugado(livro.Id);
                string status = alugado ? "ALUGADO" : "DISPONÍVEL";

                Console.WriteLine($"[ID: {livro.Id}] | Título: {livro.Titulo} | Autor: {livro.Autor} | Status: {status}");
            }
        }
        private Livro ObterLivroPorId(int id)
        {
            return _livros.FirstOrDefault(l => l.Id == id);
        }

        public void AlugarLivro(User userLogado)
        {
            int op = 1;

            do
            {
                if (userLogado == null)
                {
                    Console.WriteLine("Você precisa estar logado para alugar um livro");
                    return;
                }

                Console.WriteLine("Veja a lista de livros disponível para aluguel: ");
                ConsultarLivros();

                Console.WriteLine("\nInforme o Id do livro que deseja alugar: ");
                int IdAluguel = int.Parse(Console.ReadLine()!);

                var livro = ObterLivroPorId(IdAluguel);

                _emprestimoController.RegistrarEmprestimo(userLogado.Id, IdAluguel, _livros);

                Console.WriteLine("Deseja alugar outro Livro? (1 - Sim || 2 - Não)");
                op = int.Parse(Console.ReadLine()!);
            } while (op == 1);
        }

        public void DevolverLivro(User UserLogado)
        {
            int op = 1;

            do
            {
                if (UserLogado == null)
                {
                    Console.WriteLine("Você precisa estar logado para devolver um livro.");
                    return;
                }

                Console.WriteLine("\n===== Livros Alugados por Você =====");

                var idsLivrosAlugados = _emprestimoController.ObterIdsLivrosAlugados(UserLogado.Id);

                if (!idsLivrosAlugados.Any())
                {
                    Console.WriteLine("Você não possui livros alugados no momento.");
                    return;
                }

                var livrosAlugadosPeloUser = _livros
                    .Where(l => idsLivrosAlugados.Contains(l.Id))
                    .ToList();

                foreach (var livro in livrosAlugadosPeloUser)
                {
                    Console.WriteLine($"[ID: {livro.Id}] | Título: {livro.Titulo} | Autor: {livro.Autor}");
                }

                Console.Write("\nDigite o Id do livro que deseja Devolver: ");
                if (!int.TryParse(Console.ReadLine(), out int idDevolucao) || idDevolucao <= 0)
                {
                    Console.WriteLine("ID de livro inválido.");
                    return;
                }

                if (idsLivrosAlugados.Contains(idDevolucao))
                {
                    if (_emprestimoController.DevolverLivro(idDevolucao, UserLogado.Id))
                    {
                        var livroDevolvido = ObterLivroPorId(idDevolucao);
                        Console.WriteLine($"\nLivro '{livroDevolvido?.Titulo ?? "Desconhecido"}' devolvido com sucesso!");
                        Console.WriteLine("Obrigado por Ler um de nossos livros! Esperamos que tenha gostado da experiência.");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao processar a devolução. Verifique o ID.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido ou este livro não está na sua lista de aluguel.");
                }
                
                Console.WriteLine("Deseja devolver outro Livro ? (1 - Sim || 2 - Não)");
                op = int.Parse(Console.ReadLine()!);
            } while (op == 1); 
        }
    }
}
