using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Controllers
{
    public class EmprestimoController
    {
        private List<Emprestimo> _emprestimos = new List<Emprestimo>();

        /*  
            Método para saber se um livro está alugado ou não.
  
            Se a data de devolução for igual a null, significa que o livro ainda está alugado. Caso contrário, o livro está disponível.
        */

        public bool LivroEstaAlugado(int livroId)
        {
            return _emprestimos.Any(e => e.LivroId == livroId && e.DataDevolucaoRealizada == null);
        }

        /* 
        
            Método para Registrar o Empréstimo de algum livro.

            1º - Verifica se o Id do livro digitado existe dentro da lista de livros. 
        
            2º - Verifica se o livro está alugado, usando o método: LivroEstaAlugado.

            3º - Cria uma instância da classe empréstimo para registrar o empréstimo, passando livroId e usuario Id.

            4º - Adiciona o empréstimo na lista privada "_emprestimos".  
        
        */

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

            Emprestimo NovoEmprestimo = new Emprestimo
            {
                LivroId = livroId,
                UsuarioId = usuarioId,
            };

            _emprestimos.Add(NovoEmprestimo);

            Console.WriteLine($"\nLivro '{livro.Titulo}' alugado com sucesso! ");
            Console.WriteLine($"\nPrevisão de devolução: {NovoEmprestimo.DataDevolucaoPrevista:dd/MM/yyyy}");
        }

        /* 
        
            Método para Devolver o livro. 

            1º - Encontra qual livro está emprestado, usando como parâmetros, usuario Id e livroId. E verifica se a data de devolução está marcada como null 

            2º - Se o resultado for verdadeiro, marca a hora da Devolução do livro

        */

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
