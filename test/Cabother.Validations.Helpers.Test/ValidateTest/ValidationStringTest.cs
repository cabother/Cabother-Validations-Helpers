using System;
using Xunit;

namespace Cabother.Validations.Helpers.Test.ValidateTest
{
    public class ValidationStringTest : IClassFixture<Fixture>
    {
        private Fixture _fixture;

        public ValidationStringTest(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ValidateStringParamNull_ParameterNull_ThrowsArgumentNullException()
        {
            //Given
            _fixture.Reset();

            //When
            var exception = Assert.Throws<ArgumentNullException>(() => _fixture.Validation.ValidateStringParamNull(null));

            //Then
            Assert.Equal("Value cannot be null. (Parameter 'param')", exception.Message);
        }

        [Fact]
        public void ValidateStringParamNull_ValidParameter_ReturnsSuccess()
        {
            //Given
            _fixture.Reset();

            //When
            var response = _fixture.Validation.ValidateStringParamNull("Cabother Validations String");

            //Then
            Assert.True(response);
        }
    }
}
