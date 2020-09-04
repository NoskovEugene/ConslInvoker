namespace UI.Request
{
    public interface IRequester
    {
        string Request(string message);

        T Request<T>(string message);
    }
}