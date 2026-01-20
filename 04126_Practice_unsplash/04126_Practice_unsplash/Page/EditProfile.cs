using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V142.Network;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Globalization;

namespace _04126_Practice_unsplash.page;

public class EditProfile
{
    private IWebDriver driver;
    private WebDriverWait wait;

    [SetUp]
    public void Setup()
    {
    }

    public EditProfile(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private By usernameinput = By.Id("user_username");
    private By updateaccountbutton = By.XPath("//input[@type='submit' and @value ='Update account']");

    public void Updateusername(String newusername)
    {
        IWebElement username = wait.Until(ExpectedConditions.ElementIsVisible(usernameinput));
        username.Clear();
        username.SendKeys(newusername);
    }

    public void ClickUpdatebutton()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(updateaccountbutton)).Click();
    }
}
