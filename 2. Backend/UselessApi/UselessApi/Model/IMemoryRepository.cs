namespace UselessApi.Model
{
    public interface IMemoryRepository
    {
        Memory Peak();
        void Stack(Memory memory);
        void Dequeue();
    }
}
