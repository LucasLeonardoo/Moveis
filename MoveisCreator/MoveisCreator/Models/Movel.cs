using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovelCreator.Models
{
    [Table("Moveis")]
    public class Movel
    {
        [Key]
        public int MovelId { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Nome do Movel")]
        public string NomeDoMovel { get; set; }

    }
}
