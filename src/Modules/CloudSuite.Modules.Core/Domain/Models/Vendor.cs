using CloudSuite.Modules.Core.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Core.Domain.Models
{
    public class Vendor : Entity, IAggregateRoot
    {
        public Vendor(Guid id, string? name, string? slug, string? description, Cnpj cnpj, Email email, DateTimeOffset? createdOn, DateTimeOffset? latestUpdatedOn, bool? isActive, bool? isDeleted)
        {
            Id = id;
            Name = name;
            Slug = slug;
            Description = description;
            Cnpj = cnpj;
            Email = email;
            CreatedOn = createdOn;
            LatestUpdatedOn = latestUpdatedOn;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }

        public Vendor() { }
        
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Slug { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Description { get; private set; }

        public Cnpj Cnpj { get; private set; }

        public Guid CnpjId { get; private set; }

        public Email Email { get; private set; }

        public Guid EmailId { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        public bool? IsActive { get; private set; }

        public bool? IsDeleted { get; private set; }

        public IList<User> Users { get; set; } = new List<User>();

        public User User { get; private set; }

        public Guid UserId { get; private set; }
    }
}