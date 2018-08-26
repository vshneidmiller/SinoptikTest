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
    public class PressureWithinTheRange
    {
        [Test]
        [Description("Verifies if the pressure is in the specified range")]

        [TestCase("Воскресенье", "Драгобрат", 600, 700)]
        [TestCase("Суббота", "Яремче", 600, 750)]
        [TestCase("Среда", "Ворохта", 600, 750)]

        public void CheckPressure(string day, string city, int pressureMin, int pressureMax)
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);

            home.Goto();
            home.SearchCity(city);
            home.GetDayLinkByDayName(day).Click();

            //verifies if the ID of the currently selected Tab is the same as the ID retrieved using day name 
            Assert.AreEqual(home.GetSelectedTabId(), home.GetIdByDayName(day));

            Assert.IsTrue(home.IsInRange(pressureMin, pressureMax, home.GetPressureValues(day)));

            driver.Quit();

        }
    }
}