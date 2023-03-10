using Lesson_11_BDD.WebDriver;
using log4net.Config;
using NUnit.Framework;
using System.IO;

namespace Lesson_11_BDD.Tests
{
    public class BaseTest
    {
        protected static Browser Browser;

        [SetUp]
        public virtual void InitTest()
        {
            XmlConfigurator.Configure(new FileInfo("Log.config"));

            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TearDown]
        public virtual void CleanTest()
        {
            Browser.Quit();
        }
    }
}
