using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        //IDataResult<List<RentalDetailDto>> GetRentalDtos();

        IDataResult<Rental> GetById(int rentalId);


        IResult add(Rental rental);
        //void delete(Brand brand);
        IResult delete(Rental rental);
        IResult update(Rental rental);
    }
}
