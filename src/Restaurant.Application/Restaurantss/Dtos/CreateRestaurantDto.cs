﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Restaurantss.Dtos
{
    public class CreateRestaurantDto
    {

        #region Commenting this class b/c we now use CQRS Mediatr pattern
        ////[StringLength(100, MinimumLength = 3)]
        //public string Name { get; set; } = default!;
        //public string Description { get; set; } = default!;

        //// [Required(ErrorMessage = "Insert a valid category")]
        //public string Category { get; set; } = default!;
        //public bool HasDelivery { get; set; }
        ////[EmailAddress(ErrorMessage = "Please provide a valid email address")]
        //public string? ContactEmail { get; set; }
        //// [Phone(ErrorMessage = "Please provide a valid phone number")]
        //public string? ContactNumber { get; set; }
        //public string? City { get; set; }
        //public string? Steet { get; set; }
        ////[RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Please provide a valid postal code (XX-XXX).")]
        //public string? PostalCode { get; set; }  
        #endregion
    }
}
