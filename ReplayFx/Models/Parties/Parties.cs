using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplayFx.Models
{
    public class Parties
    {
        public string leaderId { get; set; }
        public string[] memberIds { get; set; }

        public Parties(JObject rawData)
        {
            Console.WriteLine("Model: [Parties]");
            leaderId = rawData["leaderId.id"].ToString();
            JArray memberIdArray = JArray.FromObject(rawData["members"]);
            memberIds = GetMemberIds(memberIdArray);
           
        }

        public static string[] GetMemberIds(JArray memberIdArray)
        {
            List<string> members = new List<string>();
            foreach (var item in memberIdArray)
            {
                JObject obj = item.ToObject<JObject>();
                string id = obj["id"].ToString();
                members.Add(id);
            }
            return members.ToArray();
        }
    }
}
