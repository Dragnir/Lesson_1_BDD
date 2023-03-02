using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Lesson_11_BDD.APITests
{
    public class HTTPTest
    {
        public HttpWebResponse responce;

        [SetUp]
        public void SetUpTest()
        {
            responce = MakeRequest();
        }
        
        [Test]
        public void StatusCodeTest()
        {
            Assert.AreEqual("OK", responce.StatusCode.ToString());
        }

        [Test]
        public void HeaderTest()
        {
            Assert.AreEqual("application/json; charset=utf-8", responce.Headers["content-type"]);
        }

        [Test]
        public void BodyTest()
        {
            string responceBody = String.Empty;

            using (Stream s = responce.GetResponseStream())
            {
                using (StreamReader r = new StreamReader(s))
                {
                    responceBody = r.ReadToEnd();
                }
            }
            var users = JsonConvert.DeserializeObject<List<User>>(responceBody);
            Assert.AreEqual(10, users.Count);
        }

        public static HttpWebResponse MakeRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://jsonplaceholder.typicode.com/users");
            request.Method = "GET";

            return (HttpWebResponse)request.GetResponse();
        }
    }
}
