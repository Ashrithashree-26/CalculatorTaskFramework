
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using UnitTestProject1.appl;
using NLog;//A logging library to log messages
using System;


namespace UnitTestProject1.Elements
{
    public class AppBaseItem
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        static SearchCriteria _searchCriteria;
        private string _friendlyname;
        public AppBaseItem(SearchCriteria searchCriteria, string friendlyname)
        {
            _searchCriteria = searchCriteria;
            _friendlyname = friendlyname;

        }

        public  IUIItem UIGetElement(   )
        {

            //return AppManager.AppGetWindow().appWindow.Get(_searchCriteria);
            try
            {
                return AppManager.AppGetWindow().appWindow.Get(_searchCriteria);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error retrieving UI element {_friendlyname}: {ex.Message}");
                return null;
            }

        }
        public void Click()
        {
            //var clickButton = UIGetElement();
            //clickButton.Click();
            try
            {
                Logger.Info($"Clicked {_friendlyname} button successfully.");
                var clickButton = UIGetElement();
                clickButton.Click();

            }
            catch (Exception ex)
            {
                Logger.Error($"Error clicking {_friendlyname} button: {ex.Message}");
            }
        }

        public void doubleclick()
        {
            //var ClickMenu = UIGetElement();
            //ClickMenu.DoubleClick();
            try
            {
                Logger.Info($"Double-clicked {_friendlyname} element successfully.");
                var ClickMenu = UIGetElement();
                ClickMenu.DoubleClick();

            }
            catch (Exception ex)
            {
                Logger.Error($"Error double-clicking {_friendlyname} element: {ex.Message}");
            }
        }
    }

}



    
