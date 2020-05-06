using Microsoft.WindowsAzure.Storage;

namespace Ticketing.Services
{
    public sealed class StorageAccountProvider
    {
        private static readonly StorageAccountProvider instance = new StorageAccountProvider();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static StorageAccountProvider()
        {
        }

        private CloudStorageAccount StorageAccount { get; set; }

        public StorageAccountProvider()
        {
            StorageAccount = new CloudStorageAccount(
                  new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
              "ticketsystemstorage", "bvJiQvDFONxW6egScN6CqeFtzUJupvyICjM4jPzfaUpn7+3bd1FteGdWRwYKjOZDD6xFmtIYawLYyIw7N8Em4w=="), true);
        }

        public static CloudStorageAccount Instance => instance.StorageAccount;
    }
}
