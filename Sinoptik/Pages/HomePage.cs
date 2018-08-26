using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sinoptik.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "search_city")]
        public IWebElement searchCity { get; set; }

        [FindsBy(How = How.ClassName, Using = "search_city-submit")]
        public IWebElement searchCitySubmitButton { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Goto()
        {
            driver.Navigate().GoToUrl("https://sinoptik.ua/");
        }

        public bool IsInRange(int from, int to, int[] values)
        {
            foreach (var item in values)
            {

                if (item<from || item>to)
                {
                    return false;
                }
            }
            return true;
        }

        public void SearchCity(string city)
        {
            this.searchCity.SendKeys(city);
            this.searchCitySubmitButton.Click();
        }
    
        public IWebElement GetDayLinkByDayName (string day)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement link = wait.Until(ExpectedConditions.ElementIsVisible(By.
                XPath($"//*[@class='day-link' and text()='{day}']")));
            return link;
        }

        public IWebElement GetDayLinkByClassName(string className)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement link = wait.Until(ExpectedConditions.ElementIsVisible(By.
                XPath($"//div[@id='{className}']//*[@class='day-link']")));
            return link;
        }

        public string GetIdByDayName(string day)
        {
            string id = driver.FindElement(By.
                XPath($"//*[text()='{day}']//ancestor::div[contains(@class, 'bd')]")).GetAttribute("class");
            return id;
        }

        public IList<IWebElement> GetPreassureElements(string day)
        {
            string id = GetIdByDayName(day);
            IList<IWebElement> Preassures = driver.FindElements(By.XPath($"//*[@id='{id}c']//tr[@class='gray'][1]//child::*"));
            return Preassures;
        }

        public int[] GetPressureValues(string day)
        {
            IList<IWebElement> Preassures = GetPreassureElements(day);

            int[] preassuresValues = new int[Preassures.Count];

            for (int i = 0; i < Preassures.Count; i++)
            {
                preassuresValues[i] = Convert.ToInt32(Preassures[i].Text);
            }
            return preassuresValues;
        }

        public string GetSelectedTabId()
        {
            Thread.Sleep(1000);
            string selectedTabId = driver.FindElement(By.XPath("//div[@id='blockDays']")).GetAttribute("class");
            return selectedTabId;
        }

        public IList<IWebElement> GetDayLinks()
        {
            IList<IWebElement> Links = driver.FindElements(By.XPath("//*[@class='day-link']"));
            return Links;

        }

        public IList<IWebElement> GetHumidityElements(string dayClassName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IList<IWebElement> Humidities = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath($"//*[@id='{dayClassName}c']/descendant::tr[7]/td")));
            return Humidities;
        }
    }
}

