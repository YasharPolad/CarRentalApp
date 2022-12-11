using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void AddBrand(Brand brand)
        {
            _brandRepository.Add(brand);
        }

        public List<Brand> ListAllBrands()
        {
            return _brandRepository.GetAll();
        }
    }
}
