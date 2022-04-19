using System;
using System.Collections.Generic;

#nullable disable

namespace newAdmin.Models
{
    public partial class News
    {
        public int IdNews { get; set; }
        public string Codepais { get; set; }
        public int? Categoria { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string UrlNews { get; set; }
        public string UrlImage { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Autor { get; set; }
        public bool? Visible { get; set; }

        public virtual Categorium CategoriaNavigation { get; set; }
        public virtual Pai CodepaisNavigation { get; set; }
    }
}
