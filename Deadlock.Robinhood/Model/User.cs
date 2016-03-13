using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        //{
        //    "username": "xxxxxx",
        //    "first_name": "xxxxxx",
        //    "last_name": "xxxxxx",
        //    "id_info": "https:\/\/api.robinhood.com\/user\/id\/",
        //    "url": "https:\/\/api.robinhood.com\/user\/",
        //    "basic_info": "https:\/\/api.robinhood.com\/user\/basic_info\/",
        //    "email": "xxxxxx",
        //    "investment_profile": "https:\/\/api.robinhood.com\/user\/investment_profile\/",
        //    "id": "xxxxxx",
        //    "international_info": "https:\/\/api.robinhood.com\/user\/international_info\/",
        //    "employment": "https:\/\/api.robinhood.com\/user\/employment\/",
        //    "additional_info": "https:\/\/api.robinhood.com\/user\/additional_info\/"
        //}
    }
}
