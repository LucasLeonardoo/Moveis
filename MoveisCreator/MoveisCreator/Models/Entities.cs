using MovelCreator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoveisCreator.Models
{
    public class Entities : DbContext
    {
        public DbSet<Movel> Moveis { get; set; }
        public DbSet<Estilo> Estilos { get; set; }
        public DbSet<CriarMovel> CriarMoveis { get; set; }
    }
}