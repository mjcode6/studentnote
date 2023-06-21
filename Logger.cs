using System;

namespace studentnote
{
     class Logger
    {
        private string logFilePath;

        public Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void LogAction(string action)
        {
            string logMessage = $"[{DateTime.Now}] Action: {action}";

            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite lors de l'enregistrement du journal des actions.");
                Console.WriteLine(ex.Message);
            }
        }

        public void LogError(string error, Exception ex)
        {
            string logMessage = $"[{DateTime.Now}] Error: {error}{Environment.NewLine}{ex}";

            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception)
            {
                Console.WriteLine("Une erreur s'est produite lors de l'enregistrement du journal des erreurs.");
            }
        }
    }
}
