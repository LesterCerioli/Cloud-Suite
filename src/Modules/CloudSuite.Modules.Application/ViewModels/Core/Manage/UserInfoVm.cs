﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels.Core.Manage
{
    public class UserInfoVm
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "The {0} field is required.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string? Email { get; set; }
    }
}
