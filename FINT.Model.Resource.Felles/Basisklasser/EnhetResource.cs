// Built from tag v3.1.0-rc-1

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FINT.Model.Resource;

using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Felles.Basisklasser;

namespace FINT.Model.Felles.Basisklasser
{

	public abstract class EnhetResource : AktorResource 
	{

        
		public AdresseResource Forretningsadresse { get; set; }
		public string Organisasjonsnavn { get; set; }
		public Identifikator Organisasjonsnummer { get; set; }
		
        
        public EnhetResource()
        {
            Links = new Dictionary<string, List<Link>>();
        }

        [JsonProperty(PropertyName = "_links")]
        public new Dictionary<string, List<Link>> Links { get; private set; }
        
        private void AddLink(string key, Link link)
        {
            if (!Links.ContainsKey(key))
            {
                Links.Add(key, new List<Link>());
            }
            Links[key].Add(link);
        }
    }
}
