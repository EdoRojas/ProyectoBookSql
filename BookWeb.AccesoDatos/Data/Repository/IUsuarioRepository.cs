using BookWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface IUsuarioRepository : IRepository<ApplicationUser>
    {
        void BloqueaUsuario(string IdUsuario);
        void DesbloquearUsuario(string IdUsuario);
    }
}
