namespace Amazon.Interfaces
{
    public interface ISecretManagerService
    {
        Task<string> GetSecretAsync(string secretKey);
    }
}
