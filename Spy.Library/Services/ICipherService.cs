namespace Spy.Library.Services
{
    public interface ICipherService
    {
        Response Decode(string message, string spyName);
    }
}