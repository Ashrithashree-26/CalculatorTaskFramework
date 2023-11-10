using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.Utility;
using UnitTestProject1.appl;
using UnitTestProject1.Elements;
using TestStack.White;
using NLog;

namespace Test.Form
{

    public class CalculatorForm : AppBaseItem
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        // private string one1=Getautoids("1");
        private AppButtons button1 = new AppButtons(SearchCriteria.ByAutomationId("131"), "Number1");
        private AppButtons ButtonPlus => new AppButtons(SearchCriteria.ByAutomationId("93"), "Number");
        private AppButtons ButtonMPlus => new AppButtons(SearchCriteria.ByAutomationId("125"), "Number");
        private AppButtons ButtonEqual => new AppButtons(SearchCriteria.ByAutomationId("121"), "Number");
        private AppButtons ButtonSquare => new AppButtons(SearchCriteria.ByAutomationId("111"), "Number");


        public CalculatorForm(SearchCriteria searchCriteria, string friendlyname) : base(searchCriteria, friendlyname)
        {
        }
        public AppButtons getButton(string number)
        {
            return new AppButtons(SearchCriteria.ByAutomationId($"13{number}"), "number");
        }
  
        public void EnterNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                string value = Char.ToString(number[i]);
                AppButtons button = getButton(value);
                button.Click();
            }
        }

        public void EnterPlus() {
            ButtonPlus.Click();
        }
        public void EnterMPlus()
        {
            ButtonMPlus.Click();
        }
        public void EnterEqual()
        {
            ButtonEqual.Click();
        }
        public void EnterSquare()
        {
            ButtonSquare.Click();
        }

        public void EnterMode(string Mode)
        {
            AppMenu ClickView = new AppMenu(SearchCriteria.ByText("View"), "Option");
            ClickView.doubleclick();

            AppMenu clickscientific = new AppMenu(SearchCriteria.ByText(Mode), "Mode");
            clickscientific.Click();
        }

        public static string GetResult()
        {
            Label resultTextBox = AppManager.AppGetWindow().appWindow.Get<Label>(SearchCriteria.ByAutomationId("158"));
            string result = resultTextBox.Text;
            return result;
        }

        public static bool CompareResult(string expectedValue)
        {
            bool result = false;
            string obtainedResult = GetResult();
            if (obtainedResult != null)
            {
                if(obtainedResult == expectedValue)
                result=true;
                return result;
            }
            return result; // or handle accordingly
        }


        public static void CloseInstanceOfApplication(string processName)
        {
            var processes = System.Diagnostics.Process.GetProcesses().Where(p => p.ProcessName.Contains(processName));
            if (processes.Any())
            {
                foreach (var process in processes)
                {
                    try
                    {
                        using (var app = Application.Attach(process))
                        {
                            app.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error while closing the process: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No running processes found for the given application name.");
            }

        }

    }

}
    


    






            

        