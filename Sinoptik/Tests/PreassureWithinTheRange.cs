using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sinoptik.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinoptik;

namespace Tests
{
    public class PreassureWithinTheRange
    {
        [Test]
        [Description("Verifies if the preassure is in the specified range")]

        [TestCase("Воскресенье", "Драгобрат", 600, 700)]
        [TestCase("Суббота", "Яремче", 600, 750)]
        [TestCase("Среда", "Ворохта", 600, 750)]

        public void CheckPreassure(string day, string city, int preassureFrom, int preassureTo)
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);

            home.Goto();
            home.SearchCity(city);
            home.GetDayLinkByDayName(day).Click();

            Assert.AreEqual(home.GetSelectedTabId(), home.GetIdByDayName(day));
            Assert.IsTrue(home.IsInRange(preassureFrom, preassureTo, home.GetPreassureValues(day)));

            driver.Quit();

        }
    }
}