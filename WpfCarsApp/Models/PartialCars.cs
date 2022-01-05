using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCarsApp.Models
{
    public partial class Cars
    {
        public string GetPhoto
        {
           get
            {
                return Environment.CurrentDirectory + "\\" + Photos;
            }
            set
            {
                Photos = value;
            }
        }
    }
}
