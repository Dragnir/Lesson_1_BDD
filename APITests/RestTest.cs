using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Lesson_11_BDD.APITests
{
    public class RestTest
    {
        public RestResponse responce;

        [SetUp]
        public void SetUpTest()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("users", Method.Get);
            responce = client.Execute(request);
        }

        [Test]
        public void StatusCodeTest()
        {
            Assert.That(responce.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void HeaderTest()
        {
            Assert.AreEqual("application/json", responce.ContentType.ToString());
        }

        [Test]
        public void BodyTest()
        {
            var users = JsonConvert.DeserializeObject<List<User>>(responce.Content);
            Assert.AreEqual(10, users.Count);
        }
    }
}
