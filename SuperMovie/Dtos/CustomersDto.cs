using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using SuperMovie.Models;

namespace SuperMovie.Dtos
{
    public class CustomersDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }


        public bool Subscribe { get; set; }

        
        
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        
       // [Min18_Member]
        public DateTime? Birthdate { get; set; }
    }
}