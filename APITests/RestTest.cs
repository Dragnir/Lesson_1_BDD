using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Lesson_11_BDD.APITests
{
    public class RestTest
    {
        [Test]
        public void StatusCodeTest()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/users");

            RestRequest request = new RestRequest("1", Method.Get);

            RestResponse responce = client.Execute(request);

            Assert.That(responce.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void HeaderTest()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/users");

            RestRequest request = new RestRequest("1", Method.Get);

            RestResponse responce = client.Execute(request);

            Assert.That(responce.Headers.Count, Is.EqualTo(1));
        }

        [Test]
        public void BodyTest()
        {
            //RestClient client = new RestClient("https://jsonplaceholder.typicode.com/users");

            //RestRequest request = new RestRequest("1", Method.Get);

            //RestResponse responce = client.Execute(request);

            //JsonDeserializer deserialize = new JsonDeserializer();

            //var output = deserialize.Deserialize<Dictionary<string, string>>(responce);

            //var result = output["name"];

            //Assert.That(result, Is.EqualTo("john"), "name not correct");

            //Assert.That(responce.Headers.Count, Is.EqualTo(1));
        }
    }
}
