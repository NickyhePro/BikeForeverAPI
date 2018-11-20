using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeForeverApi.Models
{
    public class PostImageItem
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string Tags { get; set; }
        public string Author { get; set; }
        public string Subscribers { get; set; }
    }
}
