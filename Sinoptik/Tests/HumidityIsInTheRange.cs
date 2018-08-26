using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sinoptik.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sinoptik.Tests
{
    public class HumidityIsInTheRange
    {

        [Test]
        [Description("Verifies if the humidity is in the specified range")]

        [TestCase(0, 100)]

        public void CheckHumidity(int humidityMin, int humidityMax)
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);

            home.Goto();

            IList<IWebElement> Humidity;

            //click all day links on by one, get humidities for each day and check if humidity values are in the specified range
            for (int i = 1; i <= 7; i++)
            {
                home.GetDayLinkByClassName($"bd{i}").Click();
                Humidity = home.GetHumidityElements($"bd{i}");

                foreach (var item in Humidity)
                {
                    Assert.GreaterOrEqual(Convert.ToInt32(item.Text), humidityMin);
                    Assert.LessOrEqual(Convert.ToInt32(item.Text), humidityMax);
                }
            }
            driver.Quit();


        }

    }
}
