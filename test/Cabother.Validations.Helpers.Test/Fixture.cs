using Cabother.Validations.Samples;

namespace Cabother.Validations.Helpers.Test
{
    public class Fixture
    {
        public IValidation Validation { get; private set; }

        public void Reset()
        {
            Validation = new Validation();
        }
    }
}