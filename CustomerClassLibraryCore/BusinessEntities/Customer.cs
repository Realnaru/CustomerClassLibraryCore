using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerClassLibraryCore.Common;

namespace CustomerClassLibraryCore
{
    [Table("customer")]
    public class Customer : Person
    {
        [Key, Column("customer_id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The field is required"),
            EnsureOneItemAttribute(ErrorMessage = "The field is required")]
        public List<Address> AdressesList { get; set; } = new List<Address>();

        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Phone Number should have E164 standart"),
                            Column("customer_phone_number")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      ErrorMessage = "Email adress should be valid"), Column("customer_email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field is required"),
            EnsureOneItemAttribute(ErrorMessage = "The field is required")]
        public List<CustomerNote> Note { get; set; } = new List<CustomerNote>();
        [Column("total_purchase_amount")]
        public decimal? TotalPurshasesAmount { get; set; }

        public void AddAddress(Address address)
        {
            //var addressValidator = new AddressValidator();
            //List<Tuple<string, string>> results = addressValidator.ValidateAdress(address);

            //if (results.Count != 0)
            //{
            //    throw new WrongDataException($"Address data is invalid. {string.Join(" ", results)}");
            //}

            if (CustomerId == address.CustomerId)
            {
                AdressesList.Add(address);
            }
            else
            {
                throw new WrongIdException("Wrong customer ID");
            }

        }

        public void AddNote(CustomerNote note)
        {
            if (note.CustomerId == CustomerId)
            {
                if (note != null && note.Note != "")
                {
                    Note.Add(note);
                }
                //else
                //{
                //    throw new WrongDataException("Note should not be empty");
                //}

            }
            else
            {
                throw new WrongIdException("Wrong customer Id");
            }

        }

    }
}
