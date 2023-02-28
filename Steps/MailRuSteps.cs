using Lesson_11_BDD.PageObjects;
using Lesson_11_BDD.WebDriver;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Lesson_11_BDD.Steps
{
    [Binding]
    public sealed class MailRuSteps
    {
        private readonly ScenarioContext context;
        private HomePage homePage;
        private LoginPage loginPage;
        protected static Browser Browser;

        public MailRuSteps(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
        }

        [BeforeScenario("smoke") ]
        public static void BeforeTestRun()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [Given(@"I open official mail ru site")]
        public void OpenOfficialMailRuSite()
        {
            homePage = new HomePage();
        }

        [Given(@"Click on Login button")]
        public void ClickOnLoginButton()
        {
            homePage.GoToLogin();
            loginPage = new LoginPage();
        }

        [When(@"I set User Navme '(.*)' start add password")]
        public void SetStartAddPassword(string userName)
        {
            loginPage.SetLogin(userName);
        }

        [When(@"Type '(.*)' and click on login")]
        public void TypeAndClickOnLogin(string incorrectPassword)
        {
            loginPage.SetPassword(incorrectPassword);
            loginPage.SignIn();
        }

        [Then(@"Page shows error message that '(.*)'")]
        public void PageShowsErrorMessage(string errorMessage)
        {
            Assert.IsTrue(loginPage.errorMesage.WebElementExist(), $"Error message {errorMessage} is not appear");
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            Browser.Quit();
        }

    }
}
