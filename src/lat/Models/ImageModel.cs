
using System.Collections.Generic;
namespace lat.Models.Completed
{
    public class ImageModel
    {
        public string url { get; set; }

        public ImageModel() { }

        

    }


    public class SchoolImages
    {
        public IList<ImageModel> images { get; set; }
    }
    
}