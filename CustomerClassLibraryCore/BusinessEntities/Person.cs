using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CustomerClassLibraryCore.BusinessEntities
{
    public abstract class Person
    {
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters"), Column("first_name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The field is required"), Column("last_name")]
        public string LastName { get; set; }
    }
}
