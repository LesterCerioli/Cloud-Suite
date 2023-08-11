using CloudSuite.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Media : EntityBase
    {
        [StringLength(450)]
        public string? Caption { get; set; }

        public int? FileSize { get; set; }

        [StringLength(450)]
        public string? FileName { get; set; }

        public MediaType MediaType { get; set; }
    }
}
