using System;

namespace de_institutions_api_core.Entities
{
    public class ConsumingApplication
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationDescription { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public DateTime DateEntered { get; set; }
        public bool IsDisabled { get; set; }
    }
}