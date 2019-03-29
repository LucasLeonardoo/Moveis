using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovelCreator.Models
{
    [Table("Moveis")]
    public abstract class Movel
    {
        [Key]
        public int Id { get; set; }

        public virtual String NomeDoMovel { get; protected set; }

        public virtual String NomeDoEstilo { get; protected set; }

        public abstract String Propriedades();

    }
}
