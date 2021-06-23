using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class WebFileHelper : IFileHelper
    {
        public void Delete(string filePath)
        {
            if ((File.Exists(filePath))) File.Delete(filePath);
        }

        public IResult Update(IFormFile file, string original, string root)
        {
            if (File.Exists(original))
            {
                File.Delete(original);
            }
            var result = Upload(file,root);
            return result.IsCompleted ? new SuccessResult(result.Result.Message) : null;
        }
        
        public async Task<IResult> Upload(IFormFile file, string root)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            try
            {
                var path = file.FileName; //gelen dosyanın yolunu alalım 
                if (file.FileName.Length<0)
                {
                    throw new NoNullAllowedException();
                }
                var extension = Path.GetExtension(file.FileName);  //verilen dosyanın gelen uzantısını belirler 
                var guid = Guid.NewGuid().ToString();  //new guid ---> birbirinden farklı anahtar kelimeler olusturulmasını saglar 
                var newPath = Path.Combine(root, (guid + extension));  // dosya ismi ve uzantısnı verdik 
                 var fstream =  File.Create(path); //path içinde bir dosya olusturulsun 
                await file.CopyToAsync(fstream);
                fstream.Flush(true);  // ön belleği temizlesin 
                fstream.Close();
                File.Copy(fstream.Name, newPath); //
                File.Delete(fstream.Name);
                return new SuccessResult(newPath);
            }
            /*
             sanırım  update de kalmıstık evet 
             */
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
