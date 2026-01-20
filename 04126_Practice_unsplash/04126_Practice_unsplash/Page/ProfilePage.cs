using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V142.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _04126_Practice_unsplash.Page;

public class ProfilePage
{
    
    private IWebDriver driver;
    private WebDriverWait wait;

    public ProfilePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

    }

    private By Editprofilebutton = By.XPath("//a[contains(text(),'Edit profile')]");

    private By fullname = By.XPath("//div[text()='Ni Nguyen']");

    public void ClickEditProfileButton()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(Editprofilebutton)).Click();
    }

    public string GetFullName()
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(fullname)).Text;
    }

    public bool IsFullNameDisplayed()
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(fullname)).Displayed;
    }

}
