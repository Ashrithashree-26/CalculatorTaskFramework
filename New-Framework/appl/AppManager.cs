
using System;
using TestStack.White;
using NLog;
using System.Configuration;
using TestStack.White.UIItems.WindowItems;

namespace UnitTestProject1.appl
{
    public class AppManager
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        static Application application;

        public static void LanuchApp(string appPath)
        {
            //Logger.Info($"Application launched successfully.");
            //application = Application.Launch(appPath);
            try
            {
                Logger.Info($"Application launched successfully.");
                application = Application.Launch(appPath);

            }
            catch (Exception ex)
            {
                Logger.Error($"Error launching application : {ex.Message}");
            }

        }

        public static AppWindow AppGetWindow(string title = "")
        {
            //return new AppWindow(application.GetWindow(title == "" ? "Calculator" : title));

            try
            {
                return new AppWindow(application.GetWindow(title == "" ? "Calculator" : title));
            }
            catch (Exception ex)
            {
                Logger.Error($"Error getting the application window: {ex.Message}");
                return null;
            }
        }

    }
}
