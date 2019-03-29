using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovelCreator.Models
{
    public class Cadeira : Movel
    {


        public string Estilo { get; set; }

        Cadeira()
        {
            this.NomeDoMovel = "Cadeira";
            this.NomeDoEstilo = this.Estilo;
        }
        public override string Propriedades()
        {
            return $"{this.NomeDoMovel} do estilo {this.NomeDoEstilo}" ;
        }
    }
}
