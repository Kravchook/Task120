using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Task120
{
    public class Browser
    {
        public static RemoteWebDriver SelectBrowser(string browser, string version, string os)
        {
            string username = "oauth-testerautomation601-64704";
            string accesskey = "f6670ea3-96df-44bd-af38-cdbae4355c13";
            string gridURL = "@ondemand.eu-central-1.saucelabs.com/wd/hub";

            RemoteWebDriver driver;
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
                    sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);
                    browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                    var uri = new Uri("https://" + username + ":" + accesskey + gridURL);
                    driver = new RemoteWebDriver(uri, browserOptions);
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
                    sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);
                    browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                    var uri = new Uri("https://" + username + ":" + accesskey + gridURL);
                    driver = new RemoteWebDriver(uri, browserOptions);
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
                    sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);
                    browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                    var uri = new Uri("https://" + username + ":" + accesskey + gridURL);
                    driver = new RemoteWebDriver(uri, browserOptions);
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
                    sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);
                    browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                    var uri = new Uri("https://" + username + ":" + accesskey + gridURL);
                    driver = new RemoteWebDriver(uri, browserOptions);
                    break;
                }
            }

            return driver;
        }
    }
}
