using System;
using Xunit;

namespace Cabother.Validations.Helpers.Test.ValidateTest
{
    public class ValidationIntegerTest : IClassFixture<Fixture>
    {
        private Fixture _fixture;

        public ValidationIntegerTest(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ValidateIntegerParamOutOfRange_InvalidParameter_ThrowsArgumentOutOfRangeException()
        {
            //Given
            _fixture.Reset();

            //When
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _fixture.Validation.ValidateIntegerParamOutOfRange(0));

            //Then
            Assert.Equal("Parameter value must be at least 1. (Parameter 'param')\nActual value was 0.", exception.Message);
        }

        [Fact]
        public void ValidateIntegerParamOutOfRange_ValidParameter_ReturnsSuccess()
        {
            //Given
            _fixture.Reset();

            //When
            var response = _fixture.Validation.ValidateIntegerParamOutOfRange(10);

            //Then
            Assert.True(response);
        }
    }
}
