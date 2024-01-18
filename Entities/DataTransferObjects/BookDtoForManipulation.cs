using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record BookDtoForManipulation
    {
        [Required(ErrorMessage = "Title is a required  field.")]
        [MinLength(2, ErrorMessage = "Title must contain of least 2 character")]
        [MaxLength(50, ErrorMessage = "Title must contain of maximum 50 character")]

        public String Title { get; init; }
        [Required(ErrorMessage = "Price is required field")]
        [Range(10, 100)]

        public decimal Price { get; init; }
    }
}