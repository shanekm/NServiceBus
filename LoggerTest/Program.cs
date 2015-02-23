namespace LoggerTest
{
    using log4net;
    using log4net.Config;

    public class Program
    {
        #region Static Fields

        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        #endregion

        #region Methods

        private static void Main(string[] args)
        {

            // Log to console window
            //BasicConfigurator.Configure();

            // Configure logging to xml file
            DOMConfigurator.Configure();

            logger.Debug("Here is a debug log.");
            logger.Info("... and an Info log.");
            logger.Warn("... and a warning.");
            logger.Error("... and an error.");
            logger.Fatal("... and a fatal error.");
        }

        #endregion
    }
}