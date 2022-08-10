using UselessApi.Model;

namespace UnitTest1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test's that the memory repository is initialized properly, with the thought: "I think, therefore I am"
        /// </summary>
        [Test]
        public void TestInitialThought()
        {
            IMemoryRepository repository = new MemoryRepository();

            Memory memory = repository.Get();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            String thought = memory.Thought;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            Assert.That(thought, Is.EqualTo("I think, therefore I am"));
        }

        /// <summary>
        /// Test's that the add method works, that a thought that's recently stored through it can be safely retrieved. 
        /// </summary>
        [Test]
        public void TestAddMethod()
        {
            IMemoryRepository repository = new MemoryRepository();

            repository.Add(new Memory { Thought = "test thought" });
            Memory memory = repository.Get();
            String thought = memory.Thought;

            Assert.That(thought, Is.EqualTo("test thought"));
        }
    }
}