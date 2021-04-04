using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Cabother.Validations.Helpers
{
    public static class Validations
    {
        /// <summary>
        /// Valida se o método Dispose() foi invocado
        /// </summary>
        /// <exception cref="ObjectDisposedException">Ocorre quando o método Dispose() do objeto já foi invocado</exception>
        public static void ThrowIfDisposed(this bool disposed, string name)
        {
            if (disposed)
                throw new ObjectDisposedException(name);
        }

        /// <summary>
        /// Valida se o parâmetro informado não está nulo
        /// </summary>
        /// <param name="parameter">Parâmetro a ser validado</param>
        /// <param name="name">Nome do Parâmetro</param>
        /// <exception cref="ArgumentNullException">Ocorre quando o parâmetro está nulo</exception>
        public static void ThrowIfNull(this string parameter, string name)
        {
            if (parameter == null)
                throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Valida se o parâmetro informado não está nulo
        /// </summary>
        /// <param name="parameter">Parâmetro a ser validado</param>
        /// <param name="name">Nome do Parâmetro</param>
        /// <exception cref="ArgumentNullException">Ocorre quando o parâmetro está nulo</exception>
        public static void ThrowIfNull(this object parameter, string name)
        {
            if (parameter == null)
                throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Valida se o parâmetro foi informado
        /// </summary>
        /// <param name="parameter">parâmetro validado</param>
        /// <param name="allowWhiteSpace">Se permite espaços vazios</param>
        /// <exception cref="ArgumentNullException">Ocorre quando o parâmetro esta nulo ou vazio</exception>
        public static void ThrowIfNull(this string parameter, bool allowWhiteSpace = false)
        {
            if ((!allowWhiteSpace && string.IsNullOrWhiteSpace(parameter)) ||
                (allowWhiteSpace && string.IsNullOrEmpty(parameter)))
                throw new ArgumentNullException(nameof(parameter));
        }

        /// <summary>
        /// Valida se o valor do parâmetro é menor que o valor minimo permitido
        /// </summary>
        /// <param name="actualValue">Valor validado</param>
        /// <param name="minValue">Valor mínimo permitido</param>
        /// <param name="name">Nome do parâmetro</param>
        /// <exception cref="ArgumentOutOfRangeException">Ocorre quando o valor atual é menor que o mínimo permitido</exception>
        public static void ThrowIfOutOfRange(this int actualValue, int minValue, string name)
        {
            if (actualValue < minValue)
                throw new ArgumentOutOfRangeException(name, actualValue,
                    $"Parameter value must be at least {minValue}.");
        }

        /// <summary>
        /// Valida se o valor do parâmetro é menor que o valor minimo permitido
        /// </summary>
        /// <param name="actualValue">Valor validado</param>
        /// <param name="minValue">Valor mínimo permitido</param>
        /// <param name="name">Nome do parâmetro</param>
        /// <exception cref="ArgumentOutOfRangeException">Ocorre quando o valor atual é menor que o mínimo permitido</exception>
        public static void ThrowIfOutOfRange(double? actualValue, double minValue, string name)
        {
            if (actualValue < minValue || actualValue == null)
                throw new ArgumentOutOfRangeException(name, actualValue, $"Parameter {name} should be greater or equal the {minValue}");
        }

        /// <summary>
        /// Valida se o valor do parâmetro é menor que o valor minimo permitido
        /// </summary>
        /// <param name="actualValue">Valor validado</param>
        /// <param name="minValue">Valor mínimo permitido</param>
        /// <param name="name">Nome do parâmetro</param>
        /// <exception cref="ArgumentOutOfRangeException">Ocorre quando o valor atual é menor que o mínimo permitido</exception>
        public static void ThrowIfOutOfRange(this decimal actualValue, int minValue, string name)
        {
            if (actualValue < minValue)
                throw new ArgumentOutOfRangeException(name, actualValue,
                    $"Parameter value must be at least {minValue}.");
        }

        /// <summary>
        /// Valida se o valor do parâmetro é menor que o valor minimo permitido
        /// </summary>
        /// <param name="actualValue">Valor validado</param>
        /// <param name="minValue">Valor mínimo permitido</param>
        /// <param name="name">Nome do parâmetro</param>
        /// <exception cref="ArgumentOutOfRangeException">Ocorre quando o valor atual é menor que o mínimo permitido</exception>
        public static void ThrowIfOutOfRange(this long actualValue, int minValue, string name)
        {
            if (actualValue < minValue)
                throw new ArgumentOutOfRangeException(name, actualValue,
                    $"Parameter value must be at least {minValue}.");
        }

        /// <summary>
        /// Valida se o parâmetro do tipo Guid é valido
        /// </summary>
        /// <param name="guid">Valor Guid que deve ser validado</param>
        /// <param name="name">Nome do parâmetro</param>
        /// <param name="acceptEmpty">Indica se deve ser considerado o valor Guid.Empty</param>
        /// <exception cref="ArgumentException">Ocorre quando o Guid informado está inválido</exception>
        public static void ThrowIfInvalid(this Guid guid, string name, bool acceptEmpty = false)
        {
            if (Guid.Empty == guid && !acceptEmpty)
                throw new ArgumentException("Parameter Invalid", name);
        }

        /// <summary>
        /// Utiliza o FluentValidation para validar o objeto e monta uma mensagem de erro quando inválido
        /// </summary>
        /// <param name="parameter">Parâmetro a ser validado</param>
        /// <param name="validator">Classe de validação do objeto</param>
        /// <param name="name">Nome do Parâmetro</param>
        /// <exception cref="ArgumentException">Ocorre quando o objeto é inválido</exception>
        public static void ThrowIfInvalid<T>(this T parameter, AbstractValidator<T> validator, string name)
            where T : class
        {
            var results = validator.Validate(parameter);

            if (!results.IsValid)
            {
                var errorMessages = results.Errors
                    .Select(x => x.ErrorMessage)
                    .Aggregate((i, j) => $"{i} {j}");
                throw new ArgumentException(errorMessages, name);
            }
        }

        /// <summary>
        /// Valida se o parâmetro Enum é válido
        /// </summary>
        /// <param name="actualValue">Valor Enum a ser validado</param>
        /// <param name="name">Nome do Parâmetro</param>
        /// <typeparam name="TEnum">Tipo do Enum para utilizar na validação</typeparam>
        /// <exception cref="ArgumentException">Ocorre quando o Enum é inválido</exception>
        public static void ThrowIfInvalid<TEnum>(this Enum actualValue, string name)
            where TEnum : Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), actualValue))
            {
                throw new ArgumentException("Parameter Invalid", name);
            }
        }

        /// Valida se uma lista é nula ou vazia.
        /// </summary>
        /// <param name="parameter">Lista a ser validada.</param>
        /// <param name="name">Nome do parâmetro.</param>
        /// <exception cref="ArgumentNullException">Lista validada é nula.</exception>
        /// <exception cref="ArgumentException">Lista validada é vazia.</exception>
        public static void ThrowIfNullOrEmpty<T>(this IEnumerable<T> parameter, string name)
        {
            parameter.ThrowIfNull(name);

            if (!parameter.Any())
                throw new ArgumentException("Parameter can not be empty", name);
        }

        /// <summary>
        /// Valida se o parâmetro de data é nulo ou é igual ao menor valor
        /// </summary>
        /// <param name="parameter">Parametro a ser validado</param>
        /// <param name="name">Nome do Parâmetro</param>
        /// <exception cref="ArgumentNullException">Ocorre quando o parâmetro esta nulo ou é igual ao menor valor</exception>
        public static void ThrowIfMinDateValue(this DateTimeOffset? parameter, string name)
        {
            if (parameter == null || parameter == DateTimeOffset.MinValue)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Valida se o valor do parâmetro é menor que o valor minimo permitido
        /// </summary>
        /// <param name="actualValue">Valor validado</param>
        /// <param name="minValue">Valor mínimo permitido</param>
        /// <param name="name">Nome do parâmetro</param>
        /// <exception cref="ArgumentOutOfRangeException">Ocorre quando o valor atual é menor que o mínimo permitido</exception>
        public static void ThrowIfListOutOfRange(List<long> actualValue, string name)
        {
            if (actualValue == null || actualValue.Count < 1)
                throw new ArgumentOutOfRangeException(name, actualValue, $"List size {name} must be greater than or equal to 1");
        }

        /// <summary>
        /// Valida se o valor do parâmetro é menor que o valor minimo permitido
        /// </summary>
        /// <param name="actualValue">Valor validado</param>
        /// <param name="minValue">Valor mínimo permitido</param>
        /// <param name="name">Nome do parâmetro</param>
        /// <exception cref="ArgumentOutOfRangeException">Ocorre quando o valor atual é menor que o mínimo permitido</exception>
        public static void ThrowIfOutOfRange(double? actualValue, double minValue, double maxValue, string name)
        {
            ThrowIfOutOfRange(actualValue, minValue, name);

            if (actualValue > maxValue || actualValue == null)
                throw new ArgumentOutOfRangeException(name, actualValue, $"Parameter {name} should be less or equal the {maxValue}");
        }
    }
}