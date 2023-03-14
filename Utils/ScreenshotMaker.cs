using System;
using System.Drawing.Imaging;
using System.IO;
using Lesson_11_BDD.WebDriver;
using OpenQA.Selenium.Support.Extensions;

namespace Lesson_11_BDD.Utils
{
    public class ScreenshotMaker
    {
        private static string NewScreenshotName
        {
            get { return "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + "." + ScreenshotImageFormat; }
        }
        private static ImageFormat ScreenshotImageFormat
        {
            get { return ImageFormat.Jpeg; }
        }
        public static string TakeBrowserScreenshot()
        {
            var screenshotPath = Path.Combine(Environment.CurrentDirectory, "Display" + NewScreenshotName);
            var image = Browser.GetDriver().TakeScreenshot();
            image.SaveAsFile(screenshotPath);
            return screenshotPath;
        }
    }
}
