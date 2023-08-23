using NetDevPack.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.JobsContext
{
    public class JobManagerSettings 
    {
        [JsonProperty(PropertyName ="db_connection-string")]
        public string DbConnectinString { get; set; }

        [JsonProperty(PropertyName ="enabled")]
        public bool Enabled { get; set; }
    } 
}
