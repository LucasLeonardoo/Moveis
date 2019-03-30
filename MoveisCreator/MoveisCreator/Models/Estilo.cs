using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovelCreator.Models
{
    [Table("Estilos")]
    public class Estilo
    {
        [Key]
        public int EstiloId { get; set; }
        
        [Display(Name = "Nome do Estilo")]
        public string NomeDoEstilo { get; set; }
    }

}
