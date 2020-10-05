using System.Collections.Generic;

namespace CarStore.POCO
{
    public class HealthResponse
    {
        public string status { get; set; }
        public List<Check> checks { get; set; }
    }

    public class Check
    {
        public string name { get; set; }
        public string status { get; set; }
    }

}
