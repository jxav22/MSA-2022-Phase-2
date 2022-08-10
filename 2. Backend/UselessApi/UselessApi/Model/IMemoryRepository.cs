namespace UselessApi.Model
{
    public interface IMemoryRepository
    {
        Memory Get();
        void Add(Memory memory);
        void Remove();
        bool Update(Memory memory);
    }
}
