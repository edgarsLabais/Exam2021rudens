using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        IWebDriver driver;


        public Form1()
        {
            InitializeComponent();

            //inicalize draiverus
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-logging");
            driver = new ChromeDriver(@"C:\eksamens\chromedriver_win32", options);

            //atver chrome ar ebay lapu 
            driver.Url = "https://ebay.com";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ietaksta tekstu chrome teksta lauka 
            driver.FindElement(By.Id("gh-ac")).SendKeys(textBox1.Text);
            //apstiprina, palai meklejumu ebay 
            driver.FindElement(By.Id("gh-btn")).Click();

            // nolasa atgriezto adresi no ebay 
            String ReadUrl = driver.Url;

            //atgriezto adresi ieraksta teksta lauka.
            textBox2.Text = ReadUrl;

            // pievieno meklesanas sarakstam  mekleto linku
            List<string> myList = richTextBox1.Lines.ToList();
            myList.Add(ReadUrl);
            richTextBox1.Lines = myList.ToArray();
            richTextBox1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // atgriezas uz ebay adresi 
            driver.Url = "https://ebay.com";

            //nodzes meklesansas lauku 
            textBox2.Text = "";

            // nodzes no meklesanas saraksta pēdējo mekleto ierakstu 
            List<string> myList = richTextBox1.Lines.ToList();
            if (myList.Count > 0)
            {
                myList.RemoveAt(myList.Count - 1);
                richTextBox1.Lines = myList.ToArray();
                richTextBox1.Refresh();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // aizver parluku
            driver.Quit();
        }
    }
}
