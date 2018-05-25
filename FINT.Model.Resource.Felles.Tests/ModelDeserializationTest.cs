using System.IO;
using FINT.Model.Felles;
using Newtonsoft.Json;
using Xunit;

namespace FINT.Model.Resource.Felles.Tests
{
    public class ModelDeserializationTest
    {
        [Fact(DisplayName = "Read Person from person.json")]
        public void Read_Person_from_person_json()
        {
            var result = JsonConvert.DeserializeObject<Person>(File.ReadAllText(@"./TestData/person.json"));

            Assert.NotNull(result);
            Assert.NotNull(result.Bostedsadresse);
            Assert.NotNull(result.Postadresse);
        }


        [Fact(DisplayName = "Read Person from personresource.json")]
        public void Read_Person_from_personresource_json()
        {
            var result = JsonConvert.DeserializeObject<Person>(File.ReadAllText(@"./TestData/personresource.json"));

            Assert.NotNull(result);
            Assert.NotNull(result.Bostedsadresse);
            Assert.NotNull(result.Postadresse);
        }

        [Fact(DisplayName = "Read Person from personresource.json with MissingMemberHandling set to Error")]
        public void Read_Person_from_personresource_json_with_MissingMemberHandling_set_to_Error()
        {
            var settings =
                new JsonSerializerSettings {MissingMemberHandling = MissingMemberHandling.Error};


            Assert.Throws<JsonSerializationException>(() =>
                JsonConvert.DeserializeObject<Person>(File.ReadAllText(@"./TestData/personresource.json"),
                    settings));
        }

        [Fact(DisplayName = "Read Person from personresourcelinks.json")]
        public void Read_Person_from_personresourcelinks_json()
        {
            var result =
                JsonConvert.DeserializeObject<Person>(File.ReadAllText(@"./TestData/personresourcelinks.json"));

            Assert.NotNull(result);
            Assert.NotNull(result.Bostedsadresse);
            Assert.NotNull(result.Postadresse);
        }

        [Fact(DisplayName = "Read Person from personresourcelinks.json with MissingMemberHandling set to Error")]
        public void Read_Person_from_personresourcelinks_json_with_MissingMemberHandling_set_to_Error()
        {
            var settings =
                new JsonSerializerSettings {MissingMemberHandling = MissingMemberHandling.Error};


            Assert.Throws<JsonSerializationException>(() =>
                JsonConvert.DeserializeObject<Person>(File.ReadAllText(@"./TestData/personresourcelinks.json"),
                    settings));
        }

        [Fact(DisplayName = "Read PersonResource from person.json")]
        public void Read_PersonResource_from_person_json()
        {
            var result = JsonConvert.DeserializeObject<PersonResource>(File.ReadAllText(@"./TestData/person.json"));

            Assert.NotNull(result);
            Assert.NotNull(result.Bostedsadresse);
            Assert.NotNull(result.Postadresse);
        }

        [Fact(DisplayName = "Read PersonResource from personresource.json")]
        public void Read_PersonResource_from_personresource_json()
        {
            var result =
                JsonConvert.DeserializeObject<PersonResource>(File.ReadAllText(@"./TestData/personresource.json"));

            Assert.NotNull(result);
            Assert.NotNull(result.Bostedsadresse);
            Assert.NotNull(result.Postadresse);
            Assert.Equal(3, result.Links.Count);
            Assert.Single(result.Links["kjonn"]);
        }

        [Fact(DisplayName = "Read PersonResource from personresourcelinks.json")]
        public void Read_PersonResource_from_personresourcelinks_json()
        {
            var result =
                JsonConvert.DeserializeObject<PersonResource>(File.ReadAllText(@"./TestData/personresourcelinks.json"));

            Assert.NotNull(result);
            Assert.NotNull(result.Bostedsadresse);
            Assert.NotNull(result.Postadresse);
            Assert.Single(result.Links["kjonn"]);
            Assert.Single(result.Bostedsadresse.Links["land"]);
            Assert.Single(result.Postadresse.Links["land"]);
        }

        [Fact(DisplayName = "Read PersonResources from personresourceslinks.json")]
        public void Read_PersonResources_from_personresourceslinks_json()
        {
            var result =
                JsonConvert.DeserializeObject<PersonResources>(
                    File.ReadAllText(@"./TestData/personresourceslinks.json"));

            Assert.NotNull(result);
            Assert.Equal(1, result.TotalItems);
            Assert.Single(result.GetSelfLinks());
            Assert.NotNull(result.GetContent()[0].Bostedsadresse);
            Assert.NotNull(result.GetContent()[0].Postadresse);
        }

        [Fact(DisplayName = "Read KontaktpersonResource from kontaktpersonresource.json")]
        public void Read_KontaktpersonResource_from_kontaktpersonresource_json()
        {
            var result =
                JsonConvert.DeserializeObject<KontaktpersonResource>(
                    File.ReadAllText(@"./TestData/kontaktpersonresource.json"));

            Assert.NotNull(result);
            Assert.True(result.Foreldreansvar);
            Assert.Equal("forelder", result.Type);
            Assert.Equal(2, result.Links.Count);
        }
    }
}