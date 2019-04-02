using MoveisCreator.Models;
using MovelCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoveisCreator.DAO
{
    public class CriarMovelDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        // Criando Movel
        public static bool CriandoMovel(CriarMovel newMovel)
        {
            try
            {
                entities.CriarMoveis.Add(newMovel);
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}