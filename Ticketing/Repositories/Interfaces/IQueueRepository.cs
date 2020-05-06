using System.Threading.Tasks;

namespace Ticketing.Repositories.Interfaces
{
    public interface IQueueRepository
    {
        Task Add(string content);
    }
}
