using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovelCreator.Models
{
    public class Barroco: Estilo
    {
        public string NomeEstilo { get; set; }

        public Barroco()
        {
            NomeDoEstilo = "Barroco";
        }
        public override string Propriedades()
        {
            return $"Características do Estílo {this.NomeEstilo}" +
                $"\n Cheios de personalidade e força estética";
        }
    }
}
