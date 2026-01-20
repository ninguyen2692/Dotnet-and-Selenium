using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V142.Profiler;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _04126_Practice_unsplash_likepage.page
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

        public bool IsFeaturedTabActive()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(featuredTab)).Displayed;
        }
        public bool isprofileiconvisible ()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(profileIcon)).Enabled;
        }

        public void OpenRandomPhoto()
        {
            // 1️⃣ Chờ trang load ảnh
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.XPath("//figure")).Count > 0);

          Thread.Sleep(2000); // chờ thêm 2s để ảnh load đầy đủ

            // 2️⃣ Lấy danh sách link ảnh (KHÔNG lấy img)
            var photos = driver.FindElements(By.XPath("//figure//a"));

            Console.WriteLine("PHOTO COUNT: " + photos.Count);

            // 3️⃣ Random 1 ảnh
            int randomIndex = new Random().Next(photos.Count);

            // 4️⃣ Click ảnh
            photos[randomIndex].Click();
        }

    }
}