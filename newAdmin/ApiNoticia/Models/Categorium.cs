using System;
using System.Collections.Generic;

#nullable disable

namespace ApiNoticia.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            News = new HashSet<News>();
        }

        public int Idcategoria { get; set; }
        public string NombreCategoria { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
