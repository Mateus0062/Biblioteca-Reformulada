using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Models
{
    public class Livro
    {
        private static int _proximoId = 1;
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public User UserAlugou { get; set; }
        public bool FoiAlugado { get; set; }

        public Livro()
        {
            this.Id = _proximoId;
            _proximoId++;
        }
    }
}
