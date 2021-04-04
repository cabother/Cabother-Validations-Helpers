using System;
using Cabother.Validations.Helpers;

namespace Cabother.Validations.Samples
{
    public interface IValidation : IDisposable
    {
        bool ValidateStringParamNull(string param);
    }

    public class Validation : IValidation
    {
        public Validation()
        {

        }

        public bool ValidateStringParamNull(string paramName)
        {
            paramName.ThrowIfNull(nameof(paramName));
            //... other method information

            return true;
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
