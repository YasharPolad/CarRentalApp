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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IResponse AddBrand(Brand brand)
        {
            _brandRepository.Add(brand);
            return new SuccessResponse();
        }

        public IResponse DeleteBrand(Brand brand)
        {
            _brandRepository.Delete(brand);
            return new SuccessResponse();
        }

        public IDataResponse<Brand> GetBrandById(int brandId)
        {
            var brand = _brandRepository
                    .Get(b => b.Id == brandId);
            if(brand == null)
            {
                return new ErrorDataResponse<Brand>(Messages.ItemNotFound(typeof(Brand), brandId));
            }
            else
            {
                return new SuccessDataResponse<Brand>(brand);
            }
        }

        public IDataResponse<List<Brand>> ListAllBrands()
        {
            var brands =  _brandRepository.GetAll();
            return new SuccessDataResponse<List<Brand>>(brands);
        }

        public IResponse UpdateBrand(Brand brand)
        {
            _brandRepository.Update(brand);
            return new SuccessResponse();
        }
    }
}
