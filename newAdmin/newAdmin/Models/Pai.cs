using System;
using System.Collections.Generic;

#nullable disable

namespace newAdmin.Models
{
    public partial class Pai
    {
        public Pai()
        {
            News = new HashSet<News>();
        }

        public string CodePais { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
