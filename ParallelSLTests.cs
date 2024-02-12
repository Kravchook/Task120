using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Task120
{
    [TestFixture("Chrome", "latest", "Windows 10")]
    [TestFixture("Edge", "latest", "Windows 10")]
    [TestFixture("Firefox", "latest", "macOS 12")]
    [Parallelizable(ParallelScope.All)]
    public class ParallelSLTests
    {
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        private string browser;
        private string version;
        private string os;

        public ParallelSLTests(string browser, string version, string os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
        }

        [SetUp]
        public void Init()
        {
            string username = "oauth-testerautomation601-64704";
            string accesskey = "f6670ea3-96df-44bd-af38-cdbae4355c13";
            string gridURL = "@ondemand.eu-central-1.saucelabs.com/wd/hub";

            RemoteWebDriver remoteWebDriver;
            switch (browser)
            {
                case "Chrome":
                    {
                        var browserOptions = new ChromeOptions();
                        browserOptions.PlatformName = os;
                        browserOptions.BrowserVersion = version;

                        var sauceOptions = new Dictionary<string, object>();
                        sauceOptions.Add("username", username);
                        sauceOptions.Add("accessKey", accesskey);
                        sauceOptions.Add("name", browser);
                        browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                        var uri = new Uri("https://" + username + ":" + accesskey + gridURL);
                        remoteWebDriver = new RemoteWebDriver(uri, browserOptions);
                        break;
                    }
                case "Firefox":
                    {
                        var browserOptions = new FirefoxOptions();
                        browserOptions.PlatformName = os;
                        browserOptions.BrowserVersion = version;

                        var sauceOptions = new Dictionary<string, object>();
                        sauceOptions.Add("username", username);
                        sauceOptions.Add("accessKey", accesskey);
                        sauceOptions.Add("name", browser);
                        browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                        var uri = new Uri("https://" + username + ":" + accesskey + gridURL);
                        remoteWebDriver = new RemoteWebDriver(uri, browserOptions);
                        break;
                    }
                case "Edge":
                    {
                        var browserOptions = new EdgeOptions();
                        browserOptions.PlatformName = os;
                        browserOptions.BrowserVersion = version;

                        var sauceOptions = new Dictionary<string, object>();
                        sauceOptions.Add("username", username);
                        sauceOptions.Add("accessKey", accesskey);
                        sauceOptions.Add("name", browser);
                        browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                        var uri = new Uri("https://" + username + ":" + accesskey + gridURL);
                        remoteWebDriver = new RemoteWebDriver(uri, browserOptions);
                        break;
                    }
                default:
                    {
                        var browserOptions = new ChromeOptions();
                        browserOptions.PlatformName = os;
                        browserOptions.BrowserVersion = version;

                        var sauceOptions = new Dictionary<string, object>();
                        sauceOptions.Add("username", username);
                        sauceOptions.Add("accessKey", accesskey);
                        sauceOptions.Add("name", browser);
                        browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                        var uri = new Uri("https://" + username + ":" + accesskey + gridURL);
                        remoteWebDriver = new RemoteWebDriver(uri, browserOptions);
                        break;
                    }
            }

            driver.Value = remoteWebDriver;

            Thread.Sleep(2000);
        }

        [Test]
        public void SeleniumEasy_ConfirmBox_Test()
        {
            driver.Value.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";

            var confirmBoxButton = driver.Value.FindElement(By.XPath("//button[contains(@onclick, 'Confirm')]"));

            //Cancel click scenario
            confirmBoxButton.Click();
            var confirmBox = driver.Value.SwitchTo().Alert();
            Assert.That(confirmBox.Text, Is.EqualTo("Press a button!"), "Confirm box text is not correct!");
            Thread.Sleep(3000);
            confirmBox.Dismiss();

            //OK click scenario
            confirmBoxButton.Click();
            confirmBox = driver.Value.SwitchTo().Alert();
            Assert.That(confirmBox.Text, Is.EqualTo("Press a button!"), "Confirm box text is not correct!");
            Thread.Sleep(3000);
            confirmBox.Accept();
        }

        [TearDown]
        public void Cleanup()
        {
            var isPassed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            var script = "sauce:job-result=" + (isPassed ? "passed" : "failed");
            ((IJavaScriptExecutor)driver.Value).ExecuteScript(script);

            driver.Value?.Quit();
        }
    }
}