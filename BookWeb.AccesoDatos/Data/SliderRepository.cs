using BookWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _db;

        public SliderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Slider slider)
        {
            var objdesdeDb = _db.Sliders.FirstOrDefault(s => s.Idslider == slider.Idslider);
            objdesdeDb.Nombre = slider.Nombre;
            objdesdeDb.Estado = slider.Estado;
            objdesdeDb.Urlimagen = slider.Urlimagen;
            _db.SaveChanges();
        }
    }
}
