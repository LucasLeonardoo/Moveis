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
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Nome do Movel")]
        public string NomeDoMovel { get; set; }
        
        [Display(Name = "Estilo")]
        public Estilo Estilo { get; set; }

    }
}
