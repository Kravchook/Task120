using OpenQA.Selenium;

namespace Task120
{
    [TestFixture]
    public class CrossBrowserTesting
    {
        private const string ExpectedConfirmText = "Press a button!";
        
        [Test]
        [TestCase("Edge", "latest", "Windows 10")]
        [TestCase("Firefox", "latest", "Windows 8.1")]
        [TestCase("Chrome", "latest", "macOS 12")]
        [Parallelizable(ParallelScope.All)]
        public void ConfirmBoxTest(string browser, string version, string os)
        {
            var driver = Browser.SelectBrowser(browser, version, os);
            driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
            driver.Manage().Window.Maximize();

            var confirmBoxButton = driver.FindElement(By.XPath("//button[contains(@onclick, 'Confirm')]"));

            //Cancel click scenario
            confirmBoxButton.Click();
            var confirmBox = driver.SwitchTo().Alert();
            Assert.That(confirmBox.Text, Is.EqualTo(ExpectedConfirmText), "Confirm box text is not correct!");
            Thread.Sleep(3000);
            confirmBox.Dismiss();

            //OK click scenario
            confirmBoxButton.Click();
            confirmBox = driver.SwitchTo().Alert();
            Assert.That(confirmBox.Text, Is.EqualTo(ExpectedConfirmText), "Confirm box text is not correct!");
            Thread.Sleep(3000);
            confirmBox.Accept();
            
            driver.Quit();
        }
    }
}