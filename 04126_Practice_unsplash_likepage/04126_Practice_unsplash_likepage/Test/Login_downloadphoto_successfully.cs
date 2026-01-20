

using _04126_Practice_unsplash_likepage.Base;
using _04126_Practice_unsplash_likepage.page;
using _04126_Practice_unsplash_likepage.Page;
using NUnit.Framework;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _04126_Practice_unsplash_likepage.Test
{
    public class Tests
    {
        public class Login_downloadphoto_successfully : BaseTest
        {
            [Test]
            public void Logindownloadphotosuccessfully()
            {
                // Given I log in with account  
                //LoginPage loginPage = new LoginPage(driver);
                // loginPage.Login("your_email@gmail.com", "your_password");
                Loginpage loginpage = new Loginpage(driver);
                loginpage.login("ni.nguyenhuynhquynh@nashtechglobal.com", "password");

                //Homepage verify login successfully
                HomePage homePage = new HomePage(driver);
                Assert.That(homePage.isprofileiconvisible(), Is.True);
                Assert.That(homePage.IsFeaturedTabActive(), Is.True);

                // When I open a random photo
                Photodetails photoPage = new Photodetails(driver);
                homePage.OpenRandomPhoto();
                // Use the instance 'photoPage' to call the method
                photoPage.isclickDownloadButton(); 
                FileInfo file = WaitForDownload();

                Assert.That(file.Exists, Is.True);
                Assert.That(
                    file.Extension.Contains("jpg")
                    || file.Extension.Contains("png"));
                Assert.That(file.Length, Is.GreaterThan(0));

            }

            private FileInfo WaitForDownload()
            {
                DirectoryInfo dir = new DirectoryInfo(downloadPath);

                for (int i = 0; i < 10; i++)
                {
                    var files = dir.GetFiles()
                        .OrderByDescending(f => f.LastWriteTime)
                        .ToList();

                    if (files.Any())
                        return files.First();

                    Thread.Sleep(1000);
                }

                throw new Exception("Download failed");
            }

        }
    }
}