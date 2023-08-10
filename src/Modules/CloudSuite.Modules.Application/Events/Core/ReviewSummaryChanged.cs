using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Events.Core
{
    internal class ReviewSummaryChanged : INotification
    {
        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }

        public int ReviewsCount { get; set; }

        public double? RatingAverage { get; set; }
    }
}
