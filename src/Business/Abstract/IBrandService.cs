﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void AddBrand(Brand brand);
        List<Brand> ListAllBrands();
    }
}
