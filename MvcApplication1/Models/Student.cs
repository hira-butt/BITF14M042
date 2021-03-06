//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Student
    {
        [Required(ErrorMessage = "This ID field is required")]
        public int Sid { get; set; }
        [Required]
        [Display(Name = "Student's name")]
        public string Name { get; set; }
          [Required]
        [DataType(DataType.EmailAddress,ErrorMessage="This must be a valid email address")]
        public string Email { get; set; }
          [Required]
          [DataType(DataType.Password)]
          [Display(Name = "Password")]
     //     [StringLength(15, ErrorMessage = "Max 8 digits", MinimumLength = 6)]
        public string Password { get; set; }
          [Required]
          [Range(8, 12, ErrorMessage = "Can only be between 8 ... 12")]
        public string Grade { get; set; }
    }
}
