namespace Callboard.App.General.Loggers
{
    public interface ILoggerWrapper
    {
        void DebugFormat(string message, params object[] values);

        void InfoFormat(string message, params object[] values);

        void WarnFormat(string message, params object[] values);

        void ErrorFormat(string message, params object[] values);

        void FatalFormat(string message, params object[] values);
    }
}
