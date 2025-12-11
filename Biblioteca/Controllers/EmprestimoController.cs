using Biblioteca.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Biblioteca.Controllers
{
    public class EmprestimoController
    {
        private List<Emprestimo> _emprestimos = new List<Emprestimo>();

        public bool LivroEstaAlugado(int livroId)
        {
            return _emprestimos.Any(e => e.LivroId == livroId && e.DataDevolucaoRealizada == null);
        }

        public void RegistrarEmprestimo(int usuarioId, int livroId, List<Livro> livros)
        {
            var livro = livros.FirstOrDefault(l => l.Id == livroId);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (LivroEstaAlugado(livroId))
            {
                Console.WriteLine("Erro, o livro já está alugado");
                return;
            }

            Emprestimo NovoEmprestimo = new Emprestimo{
                LivroId = livroId,
                UsuarioId = usuarioId,
            };

            _emprestimos.Add(NovoEmprestimo);

            Console.WriteLine($"\nLivro '{livro.Titulo}' alugado com sucesso! ");
            Console.WriteLine($"\nPrevisão de devolução: {NovoEmprestimo.DataDevolucaoPrevista:dd/MM/yyyy}");
        }

        public bool DevolverLivro(int livroId, int usuarioId)
        {
            var emprestimoAtivo = _emprestimos.FirstOrDefault(e =>
                e.LivroId == livroId &&
                e.UsuarioId == usuarioId &&
                e.DataDevolucaoRealizada == null
            );

            if (emprestimoAtivo != null)
            {
                emprestimoAtivo.DataDevolucaoRealizada = DateTime.Now;
                return true;
            }
            return false;
        }

        public List<int> ObterIdsLivrosAlugados(int usuarioId)
        {
            return _emprestimos
                .Where(e => e.UsuarioId == usuarioId && e.DataDevolucaoRealizada == null)
                .Select(e => e.LivroId)
                .ToList();
        }
    }
}
