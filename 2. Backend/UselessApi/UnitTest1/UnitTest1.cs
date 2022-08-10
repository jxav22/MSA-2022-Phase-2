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
        /// Makes sure the initial thought is "I think therefore I am"
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
    }
}