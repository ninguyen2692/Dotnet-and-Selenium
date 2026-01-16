using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace csharp_basic_id_name_section1;

public class LoginPage
{
    private IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    // Text "Login to your account"
    private IWebElement LoginTitle =>
        driver.FindElement(By.XPath("//h2[text()='Login to your account']"));

    private IWebElement EmailInput => driver.FindElement(By.Name("email"));

    private IWebElement PasswordInput => driver.FindElement(By.Name("password"));

    private IWebElement LoginButton => driver.FindElement(By.XPath("//button[text()='Login']"));

    private IWebElement IncorrectEmailPasswordError =>
        driver.FindElement(By.XPath("//p[text()='Your email or password is incorrect!']"));

    private By test = By.XPath("//p[text()='Your email or password is incorrect!']");


    // Verify Login title visible
    public bool IsLoginTitleVisible()
    {
        return LoginTitle.Displayed;
    }

    // Login action
    public void Login(string email, string password)
    {
        EmailInput.SendKeys(email);
        PasswordInput.SendKeys(password);
        LoginButton.Click();
    }

    
    // Verify error message
    public bool IsErrorMessageVisible()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

        try
        {
            IWebElement error = wait.Until(
                ExpectedConditions.ElementIsVisible(test)
            );

            return error.Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}     

