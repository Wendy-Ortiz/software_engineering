using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Selenium
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void PruebaIngresoCrearPaises()
        {
            string URL = "https://localhost:7093/";
            driver.Manage().Window.Maximize();
            driver.Url = URL;
            Assert.IsNotNull(driver);

            IWebElement countrieButton = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/a"));
            countrieButton.Click();
            Assert.IsNotNull(countrieButton);
            
            IWebElement createLink = driver.FindElement(By.XPath("/html/body/div/main/div/a"));
            createLink.Click();
            Assert.IsNotNull(createLink);


            IWebElement nameTextBox1 = driver.FindElement(By.CssSelector("#Nombre"));
            nameTextBox1.SendKeys("Canada");

            IWebElement continentDropdown = driver.FindElement(By.CssSelector("#Continente"));
            IWebElement elementFromDropdown = driver.FindElement(By.CssSelector("#Continente > option:nth-child(2)"));
            elementFromDropdown.Click();

            IWebElement lenguageTextBox1 = driver.FindElement(By.CssSelector("#Idioma"));
            lenguageTextBox1.SendKeys("Ingles");

            IWebElement createCountrieButton1 = driver.FindElement(By.CssSelector("body > div > main > form > div > input"));
            createCountrieButton1.Click();

            String expectedtitle = "El pais Canada fue Creado con éxito";
            String actualtitle = driver.FindElement(By.XPath("/html/body/div/main/div/h3")).Text.ToString();
            Assert.AreEqual(expectedtitle, actualtitle);
        }

    }
}