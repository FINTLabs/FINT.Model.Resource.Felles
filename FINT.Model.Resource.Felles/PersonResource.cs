// Built from tag v3.1.0-rc-1

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FINT.Model.Resource;

using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Felles.Basisklasser;

namespace FINT.Model.Felles
{

	public class PersonResource : AktorResource 
	{

        
		public string Bilde { get; set; }
		public AdresseResource Bostedsadresse { get; set; }
		public DateTime? Fodselsdato { get; set; }
		public Identifikator Fodselsnummer { get; set; }
		public Personnavn Navn { get; set; }
		
        
        public PersonResource()
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
            

        public void AddStatsborgerskap(Link link)
        {
            AddLink("statsborgerskap", link);
        }

        public void AddKjonn(Link link)
        {
            AddLink("kjonn", link);
        }

        public void AddMalform(Link link)
        {
            AddLink("malform", link);
        }

        public void AddPersonalressurs(Link link)
        {
            AddLink("personalressurs", link);
        }

        public void AddMorsmal(Link link)
        {
            AddLink("morsmal", link);
        }

        public void AddParorende(Link link)
        {
            AddLink("parorende", link);
        }

        public void AddElev(Link link)
        {
            AddLink("elev", link);
        }
    }
}
