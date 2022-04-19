using System;
using System.Collections.Generic;

#nullable disable

namespace ApiNoticia.Models
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public string Nameusuario { get; set; }
        public string PasswordUsuario { get; set; }
        public string Rol { get; set; }
    }
}
