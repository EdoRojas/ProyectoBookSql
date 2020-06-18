using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo
    {
        IInventarioRepository Inventario { get; }
        ICategoriaRepository Categoria { get; }
        ISliderRepository Slider { get; }
        IPerfilesRepository Perfiles { get; }
        IEmpleadoRepository Empleado { get; }
        IUsuarioRepository Usuario { get; }
        IEmpresaRepository Empresa { get; }
        IRubroRepository Rubro { get; }

        void Save();
    }
}
