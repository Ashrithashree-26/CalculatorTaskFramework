using TechTalk.SpecFlow;
using Test.Form;
using System.Drawing.Text;
using Test.Hooks;
namespace UnitTestProject1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly ProcessesHelpers processes = new ProcessesHelpers();

        [BeforeScenario("@closeAllInstances")]
        public void BeforeScenarioWithTag()
        {

            //CalculatorForm.CloseInstanceOfApplication("calc1");
            string appname = "calc1";
            processes.KillMultipleInstancesOfProcess(appname);
        }

       /* [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {
            
        }*/
    }
}