using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Models
{
    public class User
    {
        private static int _proximoId = 1;
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public User()
        {
            this.Id = _proximoId;
            _proximoId++;
        }
    }
}
