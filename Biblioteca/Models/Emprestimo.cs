namespace Biblioteca.Models
{
    public class Emprestimo
    {
        private static int _proximoId = 1;
        public int Id { get; set;}
        public int UsuarioId { get; set;}
        public int LivroId { get; set;}
        public DateTime DataEmprestimo { get; set;}
        public DateTime DataDevolucaoPrevista {  get; set;}
        public DateTime DataDevolucaoRealizada { get; set;}

        public Emprestimo()
        {
            Id = _proximoId++;
            DataEmprestimo = DateTime.Now;
            DataDevolucaoPrevista = DataEmprestimo.AddDays(7);
        }
    }
}
