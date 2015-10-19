using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjectsLayer
{

    public class Url_TableValidation
    {
        [Required]
        public string UrlTitle { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        public string UrlDesc { get; set; }

        [Required]
        public string Coupon { get; set; }
    }

    [MetadataType(typeof(Url_TableValidation))]
    public partial class Url_Table
    {
    }
}
