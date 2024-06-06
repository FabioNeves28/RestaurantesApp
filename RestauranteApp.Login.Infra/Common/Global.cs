using RestauranteApp.Login.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp.Login.Infra.Common
{
    public class Global
    {
        public static List<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
    }
}
