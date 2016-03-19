using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto.Models
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual float Valor { get; set; }
    }
}