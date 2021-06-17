using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
       
        IColorDal _colorDal;  //bagımlılıgı azaltmank için ıcolordal dan ctor yapıldı

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof (ColorValidator))]
        public IResult add(Color color)
        {
            if (color.ColorName.Length<2)
            {
                return new ErrorResult(Messages.ColorNameInValid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }


        //iş kodlarını yazalır

        public IDataResult<List<Color>> GetAll()
        {
            //İş kodları yazılır
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        //public IDataResult<Color> GetBrandByBrandId(int colorid)
        //{
        //    return new SuccessDataResult<Color> (_colorDal.Get(c => c.ColorId == colorid),Messages.FilterId);
        //}

        public IDataResult<Color> GetById(int colorId)
        {
           return new SuccessDataResult<Color> (_colorDal.Get(x => x.ColorId == colorId),Messages.FilterId);
        }

        public IResult update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
