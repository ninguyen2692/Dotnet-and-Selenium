using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.Chrome;

namespace Practice1
{
    public class Tests2
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var service = ChromeDriverService.CreateDefaultService();
            IWebDriver driver = new ChromeDriver(service);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/webtables");

            /*Page2: Table Control (https://demoqa.com/webtables)
            1. The “Delete” button of the person whose name is Cierra Vega */

            DeleteByFullName("Cierra", "Vega");

            void DeleteByFullName(string Firstname, string Lastname)
            {
                driver.FindElement(

                By.XPath($"//div[text()='{Firstname}']/following-sibling::div[text() ='{Lastname}']/ancestor::div[@role = 'row']//span[@title = 'Delete']")).Click();

            }

        }
    }
    }