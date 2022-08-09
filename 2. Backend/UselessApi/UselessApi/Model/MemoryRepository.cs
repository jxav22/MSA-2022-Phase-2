namespace UselessApi.Model
{
    public class MemoryRepository : IMemoryRepository
    {
        private List<Memory> memories = new List<Memory>();
        private int _length = 0;

        public MemoryRepository()
        {
            Add(new Memory { Thought = "I think, therefore I am" });
            _length++;
        }

        public Memory Get()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return memories.Last()
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void Add(Memory memory)
        {
            if (memory == null)
            {
                throw new ArgumentNullException("Did not pass a memory");
            }
            
            memories.Add(memory);
            _length++;
        }

        public void Remove()
        {
            if (_length > 1)
            {
                memories.Remove(memories.Last());
                _length--;
            }
        }

        public bool Update(Memory memory)
        {
            if (memory == null)
            {
                throw new ArgumentNullException("memory");
            }
            if (_length == 1)
            {
                return false;
            }
            this.Remove();
            this.Add(memory);
            return true;
        }
    }
}
