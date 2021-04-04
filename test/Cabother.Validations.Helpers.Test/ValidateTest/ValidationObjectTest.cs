using System;
using Xunit;

namespace Cabother.Validations.Helpers.Test.ValidateTest
{
    public class ValidationObjectTest : IClassFixture<Fixture>
    {
        private Fixture _fixture;

        public ValidationObjectTest(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ValidateObjectParamNull_ParameterNull_ThrowsArgumentNullException()
        {
            //Given
            _fixture.Reset();

            //When
            var exception = Assert.Throws<ArgumentNullException>(() => _fixture.Validation.ValidateObjectParamNull(null));

            //Then
            Assert.Equal("Value cannot be null. (Parameter 'param')", exception.Message);
        }

        [Fact]
        public void ValidateObjectParamNull_ValidParameter_ReturnsSuccess()
        {
            //Given
            _fixture.Reset();

            //When
            var response = _fixture.Validation.ValidateObjectParamNull("Cabother Validations Object");

            //Then
            Assert.True(response);
        }
    }
}
