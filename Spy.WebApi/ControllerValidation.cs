namespace Spy.WebApi
{
    public static class ControllerValidation
    {
        public static bool Parse(string message, string spyName)
        {
            return !string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(spyName);
        }
    }
}