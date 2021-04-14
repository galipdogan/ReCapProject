﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValitadion;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(image.CarId));
            if (result != null)
            {
                return result;
            }

            image.ImagePath = FileHelper.Add(file);
            image.Date = DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult(CarImageMessages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(Environment.CurrentDirectory + @"\wwwroot\" + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(CarImageMessages.CarImageDeleted);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(Environment.CurrentDirectory + @"\wwwroot\" + _carImageDal.Get(c => c.CarImageId == carImage.CarImageId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), CarImageMessages.CarImageListed);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        private IResult CheckIfCarImageLimitExceded(int Carid)
        {
            var result = _carImageDal.GetAll(c => c.CarId == Carid).Count;
            if (result > 5)
            {
                return new ErrorResult(CarImageMessages.CarImageCountofCarImageError);
            }

            return new SuccessResult();
        }

        private List<CarImage> CheckIfAnyCarImageExists(int carId)
        {
            string path = @"\images\DefaultCar.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return _carImageDal.GetAll(p => p.CarId == carId);
            }

            return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now } };
        }
        
    }
}
