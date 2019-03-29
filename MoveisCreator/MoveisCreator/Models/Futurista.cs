using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovelCreator.Models
{
    public class Futurista: Estilo
    {

        public string NomeEstilo { get; set; }

        public Futurista()
        {
            NomeDoEstilo = "Futurista";
        }
        public override string Propriedades()
        {
            return $"Características do estilo {this.NomeEstilo}: " +
                $"\n Formas redondas e exóticas,\n Ideia de coisas do espaço,\n Cores contrastantes e motivos espaciais,\n Minimalismo  ";
        }

    }
}
