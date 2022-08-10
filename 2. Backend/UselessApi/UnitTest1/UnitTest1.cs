using UselessApi.Model;
using UselessApi.Controllers;
using NSubstitute;

namespace UnitTest1
{
    public class Tests
    {
        IMemoryRepository realRepository;
        IMemoryRepository substituteRepository = Substitute.For<IMemoryRepository>();
        IQuoteController substituteController = Substitute.For<IQuoteController>();

        [SetUp]
        public void Setup()
        {
            substituteRepository.Get().Returns(new Memory { Thought = "DEFAULT THOUGHT" });
            substituteController.GetQuote().Returns("WOOO YEAH BABY NOW THAT'S WHAT I'M TAKING ABOUT");
            realRepository = new MemoryRepository();
        }

        /// <summary>
        /// Tests that the memory repository is initialized properly, 
        /// with the initial thought: "I think, therefore I am"
        /// </summary>
        [Test]
        public void TestInitialThought()
        {
            String initialThought = realRepository.Get().Thought;
            Assert.That(initialThought, Is.EqualTo("I think, therefore I am"));
        }

        /// <summary>
        /// Tests that a thought can be stored without a loss of data.
        /// </summary>
        [Test]
        public void TestGetMethod()
        {
            realRepository.Add(new Memory { Thought = "test thought 123" });
            String latestThought = realRepository.Get().Thought;

            Assert.That(latestThought, Is.EqualTo("test thought 123"));
        }

        /// <summary>
        /// Tests that the substitute repository provides the default thought 
        /// when the Add method is executed. (Test that substitutes work effectively).
        /// </summary>
        [Test]
        public void TestSubstitute()
        {
            Memory latestMemory = substituteRepository.Get();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string latestThought = latestMemory.Thought;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            Assert.That(latestThought, Is.EqualTo("DEFAULT THOUGHT"));
        }

        /// <summary>
        /// Tests that the memory repository can store a quote generated from an API call.
        /// </summary>
        [Test]
        public void TestQuote()
        {
            string quote = substituteController.GetQuote();

            realRepository.Add(new Memory { Thought = quote });
            String latestThought = realRepository.Get().Thought;

            Assert.That(latestThought, Is.EqualTo(quote));
        }
    }
}