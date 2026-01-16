
using NUnit.Framework.Internal;
using OpenQA.Selenium;


namespace csharp_basic_id_name_section1;

public class HomePage
{
    private IWebDriver driver;
 

    public HomePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement HomeSlider =>driver.FindElement(By.Id("slider"));

    // Text "Logged in as username" (chỉ xuất hiện khi login thành công)
    private IWebElement LoggedInAsText => driver.FindElement(By.XPath("//a[contains(text(),'Logged in as')]"));


    public bool IsHomePageVisible()
    {
        return HomeSlider.Displayed;
    }

    public void ClickSignupLogin()
    {
        driver.FindElement(By.LinkText("Signup / Login")).Click();
    }

    //  Verify login thành công
    public bool IsLoggedInAsVisible()
    {
        return LoggedInAsText.Displayed;
    }

}
