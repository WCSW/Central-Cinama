using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperMovie.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Customer's Name !")]
        [StringLength(200)]
        public string Name { get; set; }


        public bool Subscribe { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birthdate")]
        [Min18_Member]
        public DateTime? Birthdate { get; set; }

    }
}