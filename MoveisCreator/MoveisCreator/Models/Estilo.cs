using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovelCreator.Models
{
    [Table("Estilos")]
    public abstract class Estilo
    {
        [Key]
        public int Id { get; set; }

        public virtual String NomeDoEstilo { get; protected set; }

        public abstract String Propriedades();
    }

}
