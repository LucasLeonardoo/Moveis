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
        
        public int CadeiraId { get; set; }

        public Movel Movel { get; set; }

        public Estilo Estilo { get; set; }

    }
}
