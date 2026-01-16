using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.Chrome;

namespace Practice1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            /*Page 1: Student Registration (https://demoqa.com/automation-practice-form)
           1. FirstName, Email textbox
           2. Get radio option (Male, Female, Other) in Gender radio in which option is param and can be one of value (Male, Female, Other)
           3. Subjects textbox and one of Subject options (Ex: Maths, Arts, Accounting)
           4. One of checkboxes (Sports, Reading, Music) in Hobbies checkbox in which option is param and can be one of value (Sports, Reading, Music)
           5. Current Address textarea
           6. State dropdown and one of State options (Ex: NCR, Haryana)
           7. City dropdown and one of City options (Ex: NCR, Haryana)*/


            var service = ChromeDriverService.CreateDefaultService();
            IWebDriver driver = new ChromeDriver(service);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            //1. FirstName, Last Name, email find by ID

            IWebElement inputfirstname = driver.FindElement(By.Id("firstName"));
            inputfirstname.SendKeys("Ni");

            IWebElement inputlastname = driver.FindElement(By.Id("lastName"));
            inputlastname.SendKeys("Nguyen");

            IWebElement inputemail = driver.FindElement(By.Id("userEmail"));
            inputemail.SendKeys("ninguyen@gmail.com");

            //2.Get radio option(Male, Female, Other) in Gender radio in which option is param and can be one of value(Male, Female, Other)
            // phải dung xpath vì ko thể find by ID
            // gender dung By.XPATH vì ko có Chữ để click By.XPath(text()), Checkbox / Radio By.XPath(label), Dropdown React By.XPath(contains())

            Selectgender("Female");
            void Selectgender(string text)
            {
                driver.FindElement(By.XPath($"//label[text() ='{text}']")).Click();
            }

            //3. Mobile phone

            IWebElement inputphonenumber = driver.FindElement(By.XPath("//input[@id ='userNumber']"));
            inputphonenumber.SendKeys("01231313131");

            //4. Select Subject

            SelectSubject("Maths");
            SelectSubject("Arts");
            void SelectSubject(string subject)
            {
                IWebElement subjectInput = driver.FindElement(By.Id("subjectsInput"));
                subjectInput.SendKeys(subject);
                subjectInput.SendKeys(Keys.Enter);
            }
            //5. One of checkboxes (Sports, Reading, Music) in Hobbies checkbox in which option is param and can be one of value (Sports, Reading, Music)

            Selecthobbies("Sports");
            Selecthobbies("Reading");
            void Selecthobbies(string hobbies)
            {
                driver.FindElement(By.XPath($"//label[text()= '{hobbies}']")).Click();

            }

            //6.Current Address textarea

            IWebElement inputaddress = driver.FindElement(By.XPath("//textarea[@Id='currentAddress']"));
            inputaddress.SendKeys("364 Cong Hoa");

            IWebElement elementstate = driver.FindElement(By.Id("state"));
            ScrollToElement(elementstate);



            void ScrollToElement(IWebElement element)
            {
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }

            //7.State dropdown and one of State options (Ex: NCR, Delhi)
            SelectDropdown("state", "NCR");
            SelectDropdown("city", "Delhi");

            void SelectDropdown(string dropdownId, string value)
            {
                driver.FindElement(By.Id(dropdownId)).Click();
                driver.FindElement(By.XPath($"//div[text()='{value}']")).Click();
            }

        }
    }
}

