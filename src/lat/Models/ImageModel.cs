
using System.Collections.Generic;
namespace lat.Models.Completed
{

    public class ImageModel
    {
        public int id { get; set; }
        public string url { get; set; }
        public bool delete { get; set; }

        public ImageModel() { }

        public ImageModel(string s)
        {
            url = s;
        }

    }
    public class SchoolImages
    {
        public IList<ImageModel> images { get; set; }
    }
    
}