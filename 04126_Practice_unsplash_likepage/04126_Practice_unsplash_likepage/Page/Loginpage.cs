using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _04126_Practice_unsplash_likepage.Page
{
    public class Loginpage
{
    private IWebDriver driver;
    private WebDriverWait wait;
    public Loginpage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

        //find locators
        private By loginButton = By.XPath("//a[contains(text(),'Log in')]");
        private By emailInput = By.Name("email");
        private By passwordInput = By.Name("password");
        private By submitButton = By.XPath("//button[contains(text(),'Login')]");

    public void login(string email, string password)
    {
        // 1️⃣ Click Log in
        wait.Until(ExpectedConditions.ElementToBeClickable(loginButton)).Click();

        // 2️⃣ Chờ modal login load (email xuất hiện)
        wait.Until(ExpectedConditions.ElementIsVisible(emailInput)).SendKeys(email);

        // 3️⃣ Nhập password
        driver.FindElement(passwordInput).SendKeys(password);

        // 4️⃣ Submit
        driver.FindElement(submitButton).Click();
    }
}
}