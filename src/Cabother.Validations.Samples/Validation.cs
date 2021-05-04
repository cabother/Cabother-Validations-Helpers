using System;
using Cabother.Validations.Helpers;

namespace Cabother.Validations.Samples
{
    public interface IValidation : IDisposable
    {
        bool ValidateStringParamNull(string param);
        bool ValidateObjectParamNull(object param);
        bool ValidateIntegerParamOutOfRange(int param);
    }

    public class Validation : IValidation
    {
        public Validation()
        {

        }

        public void ValidadeIfIsEntityNull(object param)
        {
            param.IsEntityNull(nameof(param));
            //... other method information
        }

        public bool ValidateStringParamNull(string param)
        {
            param.ThrowIfNull(nameof(param));
            //... other method information

            return true;
        }

        public bool ValidateObjectParamNull(object param)
        {
            param.ThrowIfNull(nameof(param));
            //... other method information

            return true;
        }

        public bool ValidateIntegerParamOutOfRange(int param)
        {
            param.ThrowIfOutOfRange(1, nameof(param));
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
