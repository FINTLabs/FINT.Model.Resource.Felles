// Built from tag v2.8.0

using System.Collections.Generic;
using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Resource;
using Newtonsoft.Json;

namespace FINT.Model.Felles.Basisklasser
{
    public abstract class EnhetResource : AktorResource
    {
        protected EnhetResource()
        {
            Links = new Dictionary<string, List<Link>>();
        }

        [JsonProperty(PropertyName = "_links")]
        public new Dictionary<string, List<Link>> Links { get; private set; }

        public AdresseResource Forretningsadresse { get; set; }
        public string Organisasjonsnavn { get; set; }
        public Identifikator Organisasjonsnummer { get; set; }

        private void AddLink(string key, Link link)
        {
            if (Links.ContainsKey(key)) return;

            Links.Add(key, new List<Link>());
            Links[key].Add(link);
        }
    }
}