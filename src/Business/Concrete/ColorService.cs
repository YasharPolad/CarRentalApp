using Business.Abstract;
using Business.Constants;
using Core.Utilities;
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

        public IResponse AddColor(Color color)
        {
            _colorRepository.Add(color);
            return new SuccessResponse();
        }

        public IResponse DeleteColor(Color color)
        {
            _colorRepository.Delete(color);
            return new SuccessResponse();
        }

        public IDataResponse<Color> GetColorById(int colorId)
        {
            var color = _colorRepository
                    .Get(c => c.Id == colorId);
            if(color == null)
            {
                return new ErrorDataResponse<Color>(Messages.ItemNotFound(typeof(Color), colorId));
            }
            else
            {
                return new SuccessDataResponse<Color>(color);
            }
        }

        public IDataResponse<List<Color>> ListAllColors()
        {
            var colors = _colorRepository.GetAll();
            return new SuccessDataResponse<List<Color>>(colors);
        }

        public IResponse UpdateColor(Color color)
        {
            _colorRepository.Update(color);
            return new SuccessResponse();
        }
    }
}
