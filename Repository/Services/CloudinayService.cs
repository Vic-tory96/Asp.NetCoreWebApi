using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPIRepository.Services
{
    public class CloudinayService
    {

        private readonly Cloudinary _cloudinary;
        public CloudinayService(IConfiguration configuration)

        {

            var cloudinaryAccount = new Account(

            configuration["Cloudinary:CloudName"],

            configuration["Cloudinary:ApiKey"],

            configuration["Cloudinary:ApiSecret"]);



            _cloudinary = new Cloudinary(cloudinaryAccount);

        }


        public async Task<UploadResult> UploadAsync(IFormFile file)

        {

            using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams

            {

                File = new FileDescription(file.FileName, stream),

                Transformation = new Transformation().Crop("limit").Width(1000).Height(1000)

            };



            return await _cloudinary.UploadAsync(uploadParams);

        }







    }
}
