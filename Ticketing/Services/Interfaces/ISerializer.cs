namespace Ticketing.Services.Interfaces
{
    public interface ISerializer
    {
        string Serialize(object toSerialize);
        T Deserialize<T>(string serialized);
    }
}
