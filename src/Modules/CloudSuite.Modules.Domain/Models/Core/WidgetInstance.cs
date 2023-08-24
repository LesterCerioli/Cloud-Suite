using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class WidgetInstance : Entity, IAggregateRoot
    {
        private readonly List<WidgetZone> _widgetZones;

        public IReadOnlyCollection<WidgetZone> WidgetZones => _widgetZones.AsReadOnly();

        public WidgetInstance(string name)
        {
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
            _widgetZones = new List<WidgetZone>();
            Name = name;
        }

        [StringLength(450)]
        public string? Name { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset LatestUpdatedOn { get; private set; }
         

        public DateTimeOffset? PublishStart { get; private set; }

        public DateTimeOffset? PublishEnd { get; private set; }

        [StringLength(450)]
        public string? WidgetId { get; private set; }

        public Widget Widget { get; private set; }

        
        public WidgetZone WidgetZone { get; private set; }

        public int? DisplayOrder { get; set; }

        public string? Data { get; set; }

        public string? HtmlData { get; set; }

        /// <summary>
        /// This property cannot be used to filter again DB because it don't exist in database
        /// </summary>
        public bool IsPublished
        {
            get
            {
                return PublishStart.HasValue && PublishStart.Value < DateTimeOffset.Now && (!PublishEnd.HasValue || PublishEnd.Value > DateTimeOffset.Now);
            }
        }
    }
}
