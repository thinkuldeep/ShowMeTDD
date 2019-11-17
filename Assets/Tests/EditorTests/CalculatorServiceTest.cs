using NUnit.Framework;
using Services;

namespace Tests.EditorTests
{
    public class CalculatorServiceTest
    {
        private IService _service;

        [OneTimeSetUp]
        public void Setup()
        {
            _service = new CalculatorService();
        }
        
        [Test]
        public void ShouldReturn0For0And0()
        {
            Assert.AreEqual(0,  _service.Sum(0,0));
        }
        
        [Test]
        public void ShouldReturn3For1And2()
        {
            Assert.AreEqual(3,  _service.Sum(1,2));
        }
        
        [Test]
        public void ShouldReturnSameWhenOneValueIsZero()
        {
            Assert.AreEqual(2,  _service.Sum(0,2));
            Assert.AreEqual(1,  _service.Sum(1,0));
        }
    }
}
