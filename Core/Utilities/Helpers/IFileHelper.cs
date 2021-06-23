using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        Task<IResult> Upload(IFormFile file, string root);
        void Delete(string filePath);
        IResult Update(IFormFile file, string original, string root);
    }
}
