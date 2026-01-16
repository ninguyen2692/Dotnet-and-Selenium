using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace csharp_basic_id_name_section1
{
    public class LoginTests
    {
        IWebDriver driver;
        HomePage homePage;
        LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            // 1. Launch browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // 2. Navigate to URL
            driver.Navigate().GoToUrl("http://automationexercise.com");

            // Khởi tạo Page Object
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void Login_With_Incorrect_Email_And_Password()
        {
            // 3. Verify home page visible
            Assert.That(homePage.IsHomePageVisible(), Is.True);

            // 4. Click Signup / Login
            homePage.ClickSignupLogin();

            // 5. Verify Login title visible
            Assert.That(loginPage.IsLoginTitleVisible(),Is.True);

            // 6 + 7. Enter wrong email & click login
            loginPage.Login("wrongemail@test.com", "123456");

            // 8. Verify show error message
            Assert.That (loginPage.IsErrorMessageVisible(),Is.True);
        }

        [Test]
        public void Login_With_correct_Email_And_Password()
        {
            // 3. Verify home page visible
            Assert.That(homePage.IsHomePageVisible(), Is.True);

            // 4. Click Signup / Login
            homePage.ClickSignupLogin();

            // 5. Verify Login title visible
            Assert.That(loginPage.IsLoginTitleVisible(), Is.True);

            // 6 + 7. Enter correct email & click login
            loginPage.Login("nini@abc.com", "password");

            //8 . Verify login thành công
            Assert.That(homePage.IsLoggedInAsVisible(), Is.True);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}