using System;
using Xunit;

namespace Cabother.Validations.Helpers.Test
{
    public class ValidationTest : IClassFixture<Fixture>
    {
        private Fixture _fixture;

        public ValidationTest(Fixture fixture)
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
            Assert.Equal("Value cannot be null. (Parameter 'paramName')", exception.Message);
        }

        [Fact]
        public void ValidateStringParamNull_ValidParameter_ReturnsSuccess()
        {
            //Given
            _fixture.Reset();

            //When
            var response = _fixture.Validation.ValidateStringParamNull("Cabother Validations");

            //Then
            Assert.True(response);
        }
    }
}
