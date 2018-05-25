using System.Collections.Generic;

using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Resource;
using Newtonsoft.Json;

namespace FINT.Model.Felles
{
    public class KontaktpersonResource
    {

        public bool Foreldreansvar { get; set; }
        public Identifikator SystemId { get; set; }
        public string Type { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public Dictionary<string, List<Link>> Links { get; private set; }

        private void AddLink(string key, Link link)
        {
            if (Links.ContainsKey(key)) return;

            Links.Add(key, new List<Link>());
            Links[key].Add(link);
        }

        public void AddKontaktperson(Link link)
        {
            AddLink("kontaktperson", link);
        }

        public void AddPerson(Link link)
        {
            AddLink("person", link);
        }
    }
}
