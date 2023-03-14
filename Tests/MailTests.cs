using Lesson_11_BDD.PageObjects;
using Lesson_11_BDD.BusinesObject;
using NUnit.Framework;
using Lesson_11_BDD.Utils;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "App.config")]

namespace Lesson_11_BDD.Tests
{
    public class MailTests : BaseTest
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private MailPage mailPage;
        private readonly User user = new User("vadim.kuryan.vka", "Vka_6463296");
        private readonly Mail mail = new Mail("dragnir@tut.by", "TestSubject", "TestBody");

        [Test]
        public void SendDraftedMailTest()
        {
            Logger.Log.Info("This is SendDraftedMailTest Test");
            homePage = new HomePage();
            homePage.GoToLogin();
            loginPage = new LoginPage();
            loginPage.LogInAsUser(user);
            loginPage.SignIn();
            mailPage = new MailPage();
            mailPage.WriteNewMail(mail);
            mailPage.SaveMailAsDraft();
            mailPage.GoToDraftFolder();
            Assert.IsTrue(mailPage.dratedMail.WebElementExist());
            mailPage.dratedMail.Click();
            Assert.IsTrue(mailPage.savedMail.WebElementExist());
            mailPage.sendMail.Click();
            Logger.Log.Debug("Send email");
            mailPage.sendFolder.Click();
            Assert.IsTrue(mailPage.savedMail.WebElementExist());
        }

        [Test]
        public void WrongPasswordTest()
        {
            Logger.Log.Info("This is WrongPasswordTest Test");
            homePage = new HomePage();
            homePage.GoToLogin();
            loginPage = new LoginPage();
            loginPage.SetLogin(user.DataUser[0]);
            loginPage.SetPassword(PasswordGenerator.CreatePassword(15));
            loginPage.SignIn();
            Assert.IsTrue(loginPage.errorMesage.WebElementExist());
        }

        [Test]
        public void SendMailTest()
        {
            Logger.Log.Info("This is SendMailTest Test");
            homePage = new HomePage();
            homePage.GoToLogin();
            loginPage = new LoginPage();
            loginPage.LogInAsUser(user);
            loginPage.SignIn();
            mailPage = new MailPage();
            mailPage.WriteNewMail(mail);
            mailPage.sendMail.ActionClick();
            Logger.Log.Debug("Send email");
            mailPage.sendFolder.ActionClick();
            Assert.IsTrue(mailPage.savedMail.WebElementExist());
        }
    }
}
