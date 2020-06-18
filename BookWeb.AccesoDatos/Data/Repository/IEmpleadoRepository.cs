using BookWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface IEmpleadoRepository : IRepository<Empleados>
    {
        void Update(Empleados empleados);
    }
}
