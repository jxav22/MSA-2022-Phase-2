namespace UselessApi.Model
{
    public class MemoryRepository : IMemoryRepository
    {
        private List<Memory> memories = new List<Memory>();
        private int _length = 0;

        public MemoryRepository()
        {
            Stack(new Memory {Thought = "I think, therefore I am" });
            _length++;
        }

        public Memory Peak()
        {
            return memories.Last();
        }

        public void Stack(Memory memory)
        {
            if (memory == null)
            {
                throw new ArgumentNullException("memory");
            }
            _length++;
            memories.Add(memory);
        }

        public void Dequeue()
        {
            if (_length > 1)
            {
                memories.Remove(memories.Last());
                _length--;
            }
        }
    }
}
