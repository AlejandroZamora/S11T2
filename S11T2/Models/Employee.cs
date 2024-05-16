﻿using System.ComponentModel.DataAnnotations;

namespace S11T2.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
