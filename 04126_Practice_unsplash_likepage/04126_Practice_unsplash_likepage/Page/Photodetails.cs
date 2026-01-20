using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _04126_Practice_unsplash_likepage.Page
{
    public class Photodetails
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public Photodetails(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //find locators
        private By DownloadButton = By.XPath("//a[contains(text(),'Download')]");
     

        public void isclickDownloadButton()
        {
            
            wait.Until(ExpectedConditions.ElementToBeClickable(DownloadButton)).Click();
        }
    }
}