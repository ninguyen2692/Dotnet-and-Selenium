using _04126_Practice_unsplash.Base;
using _04126_Practice_unsplash.page;
using _04126_Practice_unsplash.Page;
using NUnit.Framework;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _04126_Practice_unsplash.Test
{
    public class Tests
    {
        public class FollowPhotographerTest : BaseTest
        {
            [Test]
            public void Follow_Photographer_Successfully()
            {
                // Given I log in with account
                //LoginPage loginPage = new LoginPage(driver);
                // loginPage.Login("your_email@gmail.com", "your_password");

                Loginpage loginpage = new Loginpage(driver);
                loginpage.login("ni.nguyenhuynhquynh@nashtechglobal.com", "password");

                //Homepage verify login successfully
                HomePage homePage = new HomePage(driver);
                Assert.That(homePage.IsFeaturedTabEnabled(), Is.True);
                Assert.That(homePage.IsProfileIconDisplayed(), Is.True);

                // When I go to profile page
                ProfilePage profilePage = new ProfilePage(driver);
                EditProfile editProfile = new EditProfile(driver);
                string newUsername = "NewUsername123";

                homePage.Gotoprofilepage();

                // And I click Edit Profile button
                profilePage.ClickEditProfileButton();

                // And I edit username
                editProfile.Updateusername(newUsername);
                editProfile.ClickUpdatebutton();

                // And I go to new profile URL

                driver.Navigate().GoToUrl($"https://unsplash.com/@{newUsername}");

                // Then I observe profile page

                Assert.That(driver.Url, Is.EqualTo($"https://unsplash.com/@{newUsername}"));

                // Verify the username has been updated successfully
                string fullname = "Ni nguyen";
                Assert.That(profilePage.GetFullName(), Is.EqualTo(fullname));

            }
        }
    }
}
