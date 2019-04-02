using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovelCreator.Models
{
    [Table("MoveisCriados")]
    public class CriarMovel
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Movel")]
        public int MovelId { get; set; }

        [ForeignKey("Estilo")]
        public int EstiloId { get; set; }

        public Movel Movel { get; set; }

        public Estilo Estilo { get; set; }

    }
}
