using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sinoptik.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sinoptik
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);


            home.Goto();
            home.searchCity.SendKeys("Драгобрат");
            home.searchCitySubmitButton.Click();
            home.DayTab("Воскресенье").Click();
            Thread.Sleep(3000);

            //check if "Воскресенье" tab is selected
            string parentClassName = driver.FindElement(By.XPath("//a[text()='Воскресенье']/parent::*/parent::*")).GetAttribute("class");
            Assert.AreEqual(parentClassName, "main  loaded");

            IList<IWebElement> Tabs = driver.FindElements(By.XPath("//*[@class='Tab'][position()<8]"));
            
            foreach (var item in Tabs)
            {
                Console.WriteLine(item.GetAttribute("id"));
            }



            //Console.WriteLine(driver.FindElement(By.XPath("//a[text()='Воскресенье']/parent::*/parent::*")).GetAttribute("id"));
            //Console.WriteLine(driver.FindElement(By.XPath("//a[text()='Воскресенье']/parent::*/parent::*")).GetAttribute("class"));

            //Console.WriteLine(home.DayTab("Воскресенье").FindElement(By.XPath("//span/parent::*")).GetAttribute("id")); 




            home.CheckPressure(2,3);
            //IWebElement elem = driver.FindElement(By.Id("blockDays"));
            //string elem2 = elem.GetAttribute("class");
            //Console.WriteLine(elem2);

        }
    }
}
