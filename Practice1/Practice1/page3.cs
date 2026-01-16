using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.Chrome;

namespace Practice1
{
    public class Tests3
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test3()
        {
            var service = ChromeDriverService.CreateDefaultService();
            IWebDriver driver = new ChromeDriver(service);
            driver.Manage().Window.Maximize();
        
            driver.Navigate().GoToUrl("https://tiki.vn/noi-chien-khong-dau-philips-6-2-lit-na230-00-hang-chinh-hang-p275494225.html?spid=275494228");

            /*Page 3: Tiki Page (https://tiki.vn/noi-chien-khong-dau-philips-6-2-lit-na230-00-hang-chinh-hang-p275494225.html?spid=275494228)
                1. The price locator of an item for sale.
                Eg: The price of “Điện thoại Samsung Galaxy Note 10 Plus” */
            {
                driver.FindElement(By.XPath("//div[contains(@class,'price-discount')]"));

        }

    }
    }
}
