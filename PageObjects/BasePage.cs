using Lesson_11_BDD.Utils;
using OpenQA.Selenium;

namespace Lesson_11_BDD.PageObjects
{
    public class BasePage
    {
        protected By titleLocator;
        protected string title;
        public static string titleForm;

        protected BasePage(By TitleLocator, string title)
        {
            titleLocator = TitleLocator;
            this.title = titleForm = title;
            AssertIsOpen();
            Logger.InitLogger();
        }

        public void AssertIsOpen()
        {
            var label = new BaseElement(titleLocator, title);
            label.WaitForIsVisible();
        }

    }
}
