using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Back_Office_Automation
{
    public class Shared
    {
        private Dictionary<string, string> config;     

        public Dictionary<string, string> GetConfig()
        {
            config = new Dictionary<string, string>();

            StreamReader s = new StreamReader(@"H:\PMO\Test Services\Automation\Selenium Test Suites\Evolution Back Office Automation\RunSettings.txt");

            string line;

            while ((line = s.ReadLine()) != null)
            {
                string[] splitString = line.Split('=');
                config.Add(splitString[0], splitString[1]);
            }

            return config;
        }

        public void WriteToErrorFile(string testname, StringBuilder str)
        {
            string path = @"H:\PMO\Test Services\Automation\Selenium Test Suites\Results\errors.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }            

            File.AppendText(path).Write(testname + ": " + str.ToString());
        }

        public void WaitForElementNotAppear(IWebDriver driver, IWebElement element)
        {
            var seleniumWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(30000));
            seleniumWait.Until(b => !element.Displayed);
        }

        public void WaitForElementAppear(IWebDriver driver, IWebElement element) 
        {
            var seleniumWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(30000));
            seleniumWait.Until(b => element.Displayed);
        }    

        public void WaitForElementAppearAndDisappear(IWebDriver driver, IWebElement element)
        {
            var seleniumWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(30000));
            seleniumWait.Until(b => element.Displayed);
            seleniumWait.Until(b => !element.Displayed);
        }

        private By SetBy(string recstring){

            string[] property = recstring.Split('=');
            switch (property[0].ToUpper())
            {
                case "ID":
                    return By.Id(property[1]);
                case "NAME":
                    return By.Name(property[1]);
                case "XPATH":
                    return By.XPath(property[1]);
                case "CLASS":
                    return By.ClassName(property[1]);
                case "CSS":
                    return By.CssSelector(property[1]);
                case "LINK":
                case "LINKTEXT":
                    return By.LinkText(property[1]);
                case "PARTIAL":
                    return By.PartialLinkText(property[1]);
                case "TAG":
                    return By.TagName(property[1]);
                default:
                    return By.XPath(property[1]);
            }
        }

        public void TakeScreenShot(IWebDriver driver, string filename) {
            string path = Path.Combine(File.ReadAllText(@"H:\PMO\Test Services\Automation\Selenium Test Suites\Suite.txt"), "ScreenShots");
            Directory.CreateDirectory(path);
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(Path.Combine(path,filename)+".png", ImageFormat.Png);            
        }
    }
}