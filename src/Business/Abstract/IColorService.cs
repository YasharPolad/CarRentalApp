using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResponse AddColor(Color color);
        IDataResponse<List<Color>> ListAllColors();
        IDataResponse<Color> GetColorById(int colorId);
        IResponse UpdateColor(Color color);
        IResponse DeleteColor(Color color);

    }
}
