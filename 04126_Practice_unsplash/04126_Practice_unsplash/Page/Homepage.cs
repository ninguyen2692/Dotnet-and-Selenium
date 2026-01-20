using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V142.Profiler;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _04126_Practice_unsplash.page

{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string profileName = "Ni Nguyen";

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private By featuredTab = By.XPath("//a[contains(text(),'Featured') and (@aria-current='page')]");
        private By profileIcon => By.XPath($"//img[@alt='Avatar of user {profileName}']");

        //Profile
        private By profile => By.XPath("//button[@aria-label='Profile']");
        private By Viewprofile => By.XPath("//span[text()='View profile']");


        public bool IsFeaturedTabActive()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(featuredTab)).Displayed;
        }
        public bool IsFeaturedTabEnabled() {
            return wait.Until(ExpectedConditions.ElementToBeClickable(featuredTab)).Enabled;
        }

        public  bool IsProfileIconDisplayed()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(profileIcon)).Displayed;
        }
        public void Gotoprofilepage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(profile)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(Viewprofile)).Click();
        }

        internal bool GetProfileName()
        {
            throw new NotImplementedException();
        }
    }
}