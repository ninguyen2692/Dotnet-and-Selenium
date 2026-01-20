using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace _04126_Practice_unsplash_likepage.Base
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string downloadPath;

        [SetUp]
        public void Setup()
        {
            //Tạo đường dẫn Download, Tạo folder con tên Downloads
            downloadPath = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "Downloads");

            //Tạo folder nếu chưa tồn tại
            Directory.CreateDirectory(downloadPath);

            //Dùng để cấu hình Chrome trước khi mở
            ChromeOptions options = new ChromeOptions();

            //Cấu hình để tự động download file về thư mục đã tạo
            options.AddUserProfilePreference("download.default_directory", downloadPath);//Thư mục download
            options.AddUserProfilePreference("download.prompt_for_download", false);//Tắt popup hỏi download
            options.AddUserProfilePreference("safebrowsing.enabled", true);//Tắt cảnh báo file nguy hiểm
            options.AddUserProfilePreference( "profile.default_content_setting_values.automatic_downloads", 1);

            driver = new ChromeDriver(options);//Khởi tạo trình duyệt với cấu hình đã tạo
            driver.Navigate().GoToUrl("https://unsplash.com/");
            driver.Manage().Window.Maximize();//Phóng to cửa sổ
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}