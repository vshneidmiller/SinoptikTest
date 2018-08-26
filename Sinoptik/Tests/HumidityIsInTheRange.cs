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
    public static class HumidityIsInTheRange
    {

        public static void CheckHumidity()
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);

            home.Goto();


            for (int i = 1; i < 7; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(home.GetDayLinkByClassName($"bd{i}").Text);
                IList<IWebElement> Humidity = home.GetHumidityElements($"bd{i}");

                foreach (var item in Humidity)
                {
                    Console.WriteLine(item.Text);
                    Console.WriteLine("I am here");
                }
            }

        }



    }
}
