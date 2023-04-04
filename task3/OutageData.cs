using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace wpfForms
{
    public class OutageData
    {
        [JsonProperty("outage_id")]
        public string OutageId { get; set; }

        [JsonProperty("outage_start")]
        public DateTime OutageStart { get; set; }

        [JsonProperty("outage_end")]
        public DateTime OutageEnd { get; set; }

        [JsonProperty("affected_areas")]
        public List<AffectedArea> AffectedAreas { get; set; }

        [JsonProperty("outage_status")]
        public string OutageStatus { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
