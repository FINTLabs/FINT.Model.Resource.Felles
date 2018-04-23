// Built from tag v2.7.0

using System.Collections.Generic;
using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Resource;
using Newtonsoft.Json;

namespace FINT.Model.Felles.Basisklasser
{
    public abstract class AktorResource
    {
        protected AktorResource()
        {
            Links = new Dictionary<string, List<Link>>();
        }

        [JsonProperty(PropertyName = "_links")]
        public Dictionary<string, List<Link>> Links { get; private set; }

        public Kontaktinformasjon Kontaktinformasjon { get; set; }
        public KommuneResource Postadresse { get; set; }

        private void AddLink(string key, Link link)
        {
            if (Links.ContainsKey(key)) return;

            Links.Add(key, new List<Link>());
            Links[key].Add(link);
        }
    }
}