﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class Contact
    {
        
        public Guid Id { get; set; }


       
        public string FirstName { get; set; }


       
        public string LastName { get; set; }


        
        public string EmailAddress { get; set; }
    }
}