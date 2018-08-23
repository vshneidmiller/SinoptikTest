using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinoptik.Pages
{
    class HomePage
    {

        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "search_city")]
        public IWebElement searchCity { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#form-search > p.clearfix > input.search_city-submit")]
        public IWebElement searchCitySubmitButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Понедельник")]
        public IWebElement MondayTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "# bd5c > div.wMain.clearfix > div.rSide > table > tbody > tr:nth-child(5) > td.p1.bR")]
        public IWebElement pressureNight { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#bd5c > div.wMain.clearfix > div.rSide > table > tbody > tr:nth-child(5) > td.p2.bR")]
        public IWebElement pressureMorning { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#bd5c > div.wMain.clearfix > div.rSide > table > tbody > tr:nth-child(5) > td.p3.bR")]
        public IWebElement pressureDay { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#bd5c > div.wMain.clearfix > div.rSide > table > tbody > tr:nth-child(5) > td.p4")]
        public IWebElement pressureEvening { get; set; }

        


        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Goto()
        {
            driver.Navigate().GoToUrl("https://sinoptik.ua/");
        }

        public void CheckPressure(int from, int to)
        {
            Console.WriteLine(from.ToString() + to.ToString());
        }

        public IWebElement DayTab (string day)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement tab = wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(day)));
            return tab;
        }

        public bool CheckIfTabSelected(string day)
        {

            string xpath = $"\"//a[text()='{day}']/parent::*/parent::*\"";
            Console.WriteLine(xpath);
            string parentClassName = driver.FindElement(By.XPath("//a[text()='Воскресенье']/parent::*/parent::*")).GetAttribute("class");
            Console.WriteLine(parentClassName);
            return true;
        }

        
    }
}
