using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
      /*  List<Brand> GetAll(); */ //listlerde data result kullanılmalı hem işlem sonucu hem mesaj hemde veriyi döndüren
        IDataResult<List<Brand>> GetAll();  

        IDataResult<Brand> GetById(int brandId);  //marka detayı
        IDataResult<Brand> GetBrandByBrandId(int brandid);

        IResult add(Brand brand);
        //void delete(Brand brand);
        IResult delete(Brand brand);
        IResult update(Brand brand);

    }
}
