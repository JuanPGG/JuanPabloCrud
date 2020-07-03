using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace crudA.Models
{
    public class Users
    {
        public int Id { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Telefono { set; get; }
        public string Correo { set; get; }

    }
}
