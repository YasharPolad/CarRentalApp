using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResponse AddBrand(Brand brand);
        IDataResponse<List<Brand>> ListAllBrands();
        IDataResponse<Brand> GetBrandById(int brandId);
        IResponse UpdateBrand(Brand brand);
        IResponse DeleteBrand(Brand brand);
    }
}
