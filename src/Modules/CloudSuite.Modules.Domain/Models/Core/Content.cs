using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public abstract class Content
    {
        private bool isDeleted;

        

        public Content(long? createdById, User createdBy, DateTimeOffset? createdOn, 
            DateTimeOffset? latestUpdatedOn, long? latestUpdatedById, 
            User latestUpdatedBy, string name, string slug)
        {
            CreatedById = createdById;
            CreatedBy = createdBy;
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
            LatestUpdatedById = latestUpdatedById;
            LatestUpdatedBy = latestUpdatedBy;
            Name = name;
            Slug = slug;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Slug { get; private set; }

        [StringLength(450)]
        public string? MetaTitle { get; private set; }

        [StringLength(450)]
        public string? MetaKeywords { get; private set; }

        public string? MetaDescription { get; private set; }

        public bool? IsPublished { get; private set; }

        public DateTimeOffset? PublishedOn { get; private set; }

        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
                if (value)
                {
                    IsPublished = false;
                }
            }
        }

        public long? CreatedById { get; private set; }

        public User CreatedBy { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        public long? LatestUpdatedById { get; private set; }

        public User LatestUpdatedBy { get; private set; }
    }
}
