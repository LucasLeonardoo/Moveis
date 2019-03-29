using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovelCreator.Models
{
    public class Mesa : Movel
    {

        public string Estilo { get; set; }

        Mesa()
        {
            NomeDoMovel = "Mesa";
            NomeDoEstilo = this.Estilo;
        }

        public override string Propriedades()
        {
            return $"{this.NomeDoMovel} do estilo {this.NomeDoEstilo}";
        }
    }
}
