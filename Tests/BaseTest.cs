﻿using Lesson_11_BDD.Utils;
using Lesson_11_BDD.WebDriver;
using NUnit.Framework;

namespace Lesson_11_BDD.Tests
{
    public class BaseTest
    {
        protected static Browser Browser;

        [SetUp]
        public virtual void InitTest()
        {
            Logger.InitLogger();

            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TearDown]
        public virtual void CleanTest()
        {
            if (TestContext.CurrentContext.Result.PassCount == 0)
            {
                ScreenshotMaker.TakeBrowserScreenshot();
                Logger.Log.Error("Test failed. Please see snapshot");
            }
            Browser.Quit();
        }
    }
}
