using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeForeverApi.Models
{
    public class PostItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Tags { get; set; }
        public string UploadTime { get; set; }
        public string Author { get; set; }
        public string Subscribers { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }
}
