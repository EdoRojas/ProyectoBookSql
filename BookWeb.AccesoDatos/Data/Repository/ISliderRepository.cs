using BookWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface ISliderRepository : IRepository<Slider>
    {
        void Update(Slider slider);
    }
}
