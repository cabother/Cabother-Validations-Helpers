# Cabother Validation Helper

Biblioteca de apoio ao uso de validações de parâmetros de métodos

## Nuget
```
https://www.nuget.org/packages/Cabother.Validations.Helpers/
```
## Lista de validações disponíveis
| Nome da Validação     | Descrição                                                                   | Tipo da exception           |
| --------------------- | --------------------------------------------------------------------------- | --------------------------- |
| ThrowIfDisposed       | Valida se a classe já efetuou dispose                                       | ObjectDisposedException     |
| ThrowIfNull           | Valida se o parâmetro possui valor nulo                                   | ArgumentNullException       |
| ThrowIfOutOfRange     | Valida se o valor do parâmetro está fora do range permitido                 | ArgumentOutOfRangeException |
| ThrowIfInvalid        | Valida se o valor do parâmetro é inválido para a condição esperada          | ArgumentException           |
| ThrowIfNullOrEmpty    | Valida se o valor do parâmetro é nulo ou inválido                           | ArgumentException           |
| ThrowIfMinDateValue   | Valida se o valor do parâmetro no formato de data é inválido                | ArgumentNullException       |
| ThrowIfListOutOfRange | Valida se o a quantidade de registros da lista está fora do range permitido | ArgumentOutOfRangeException |

## Como usar as validações ?
- Todo uso está implícito em validar um parâmetro de entrada de métodos, sendo assim para validarmos por exemplo uma string nula podemos fazer da seguinte maneira
    ```
        public bool YourMethodName(string param)
        {
            param.ThrowIfNull(nameof(param));
            //... other method information

            return true;
        }
    ```
- Note que será executado um `throw new ArgumentNullException(name)` caso o valor do parâmetro seja nulo.
  
- Para mais exemplos de como utilizar, poderão analisar na classe `Validation.cs` que encontra-se no projeto de exemplo (`src/Cabother.Validations.Samples/Validation.cs`)
 
<a href="https://www.buymeacoffee.com/cabother" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a> 