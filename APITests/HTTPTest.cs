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
        [Test]
        public void StatusCodeTest()
        {
            HttpWebResponse responce = MakeRequest();
            Assert.AreEqual("OK", responce.StatusCode.ToString());
        }

        [Test]
        public void HeaderTest()
        {
            HttpWebResponse responce = MakeRequest();
            Assert.AreEqual("application/json; charset=utf-8", responce.Headers["content-type"]);
        }

        [Test]
        public void BodyTest()
        {
            string responceBody = String.Empty;
            HttpWebResponse responce = MakeRequest();

            using (Stream s = responce.GetResponseStream())
            {
                using (StreamReader r = new StreamReader(s))
                {
                    responceBody = r.ReadToEnd();
                }
            }
            Root jsonResult = JsonConvert.DeserializeObject<Root>(responceBody);
            Assert.AreEqual(10, jsonResult.MyArray.Count);
        }

        public static HttpWebResponse MakeRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://jsonplaceholder.typicode.com/users");
            request.Method = "GET";

            return (HttpWebResponse)request.GetResponse();
        }
    }
}
