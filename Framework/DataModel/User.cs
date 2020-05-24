using Newtonsoft.Json;

namespace GTIO.Framework.DataModel
{

    public class User
    {
        [JsonProperty(PropertyName = "Key")]
        public string Key { get; set; }
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "Role")]
        public string Role { get; set; }
    }
}
