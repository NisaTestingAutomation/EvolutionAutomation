using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Evolution_Back_Office_Automation
{
    class UsersPageModel
    {
        private IWebDriver driver{ get; set; }

        public UsersPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Id, Using ="tab-41")]
        public IWebElement UserFrame { get; set; }

        [FindsBy(How = How.Id, Using ="lnkAdd")]
        public IWebElement AddUser { get; set; }

        [FindsBy(How = How.Id,Using ="UserFirstName")]
        public IWebElement UserFirstName { get; set; }
                   
        [FindsBy(How = How.Id,Using ="UserMiddleName")]
        public IWebElement UserMiddleName { get; set; }

        [FindsBy(How = How.Id,Using ="UserLastName")]
        public IWebElement UserLastName { get; set; }

        [FindsBy(How = How.Id,Using ="RoleID")]
        public IWebElement UserRoleID { get; set; }

        [FindsBy(How = How.Id,Using ="UserDOB")]
        public IWebElement UserDateOfBirth { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div/div/select[1]")]
        public IWebElement UserDateOfBirthMonth { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div/div/select[2]")]
        public IWebElement UserDateOfBirthYear { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/table/tbody/tr[1]/td[3]/a")]
        public IWebElement UserDateOfBirthFirstDay { get; set; }

        [FindsBy(How = How.Id, Using = "UserAddress")]
        public IWebElement UserAddress { get; set; }

        [FindsBy(How = How.Id, Using = "UserPostcode")]
        public IWebElement UserPostcode { get; set; }

        [FindsBy(How = How.Id, Using = "UserImage")]
        public IWebElement UserImage { get; set; }

        [FindsBy(How = How.Id, Using = "UserPhone1")]
        public IWebElement UserPhone1 { get; set; }

        [FindsBy(How = How.Id, Using = "UserPhone2")]
        public IWebElement UserPhone2 { get; set; }

        [FindsBy(How = How.Id, Using = "UserPhone3")]
        public IWebElement UserPhone3 { get; set; }

        [FindsBy(How = How.Id, Using = "UserEmail")]
        public IWebElement UserEmail { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "DisplayName")]
        public IWebElement UserDisplayName { get; set; }

        [FindsBy(How = How.Id, Using = "txtUserPassword")]
        public IWebElement UserPassword { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement UserConfirmPassword { get; set; }

        [FindsBy(How = How.Id, Using = "lnkSave")]
        public IWebElement SaveUser { get; set; }

        [FindsBy(How = How.Id, Using = "txtSearchUserName")]
        public IWebElement SearchUserName { get; set; }

        [FindsBy(How = How.Id, Using = "btnSearch")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "lnkDelete")]
        public IWebElement DeleteUser { get; set; }
    }
}
