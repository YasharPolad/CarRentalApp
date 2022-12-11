using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public void AddColor(Color color)
        {
            _colorRepository.Add(color);
        }

        public List<Color> ListAllColors()
        {
            return _colorRepository.GetAll();
        }
    }
}
