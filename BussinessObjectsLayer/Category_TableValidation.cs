using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjectsLayer
{
    public class Category_TableValidation
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDesc { get; set; }
    }

    [MetadataType(typeof(Category_TableValidation))]
    public partial class Category_Table
    {
    }
}
