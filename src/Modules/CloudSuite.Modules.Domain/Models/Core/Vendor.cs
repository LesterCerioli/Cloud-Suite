﻿using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Vendor : Entity, IAggregateRoot
    {
        public Vendor()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Slug { get; set; }

        public string? Description { get; set; }

        public Cnpj Cnpj { get; set; }

        public Email Email { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public DateTimeOffset? LatestUpdatedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public IList<User> Users { get; set; } = new List<User>();
    }
}
