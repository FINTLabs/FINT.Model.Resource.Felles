// Built from tag v2.7.0

using System.Collections.Generic;
using FINT.Model.Resource;
using Newtonsoft.Json;

namespace FINT.Model.Felles.Kompleksedatatyper
{
    public class AdresseResource
    {
        public AdresseResource()
        {
            Links = new Dictionary<string, List<Link>>();
        }

        [JsonProperty(PropertyName = "_links")]
        public Dictionary<string, List<Link>> Links { get; private set; }


        public List<string> Adresselinje { get; set; }
        public string Postnummer { get; set; }
        public string Poststed { get; set; }

        private void AddLink(string key, Link link)
        {
            if (Links.ContainsKey(key)) return;

            Links.Add(key, new List<Link>());
            Links[key].Add(link);
        }

        public void AddLand(Link link)
        {
            AddLink("land", link);
        }
    }
}