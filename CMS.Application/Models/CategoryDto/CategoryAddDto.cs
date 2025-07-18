using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Models
{
    public class CategoryAddDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
    }
}
