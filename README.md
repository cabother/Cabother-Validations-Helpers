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
| ThrowIfNull           | Valida se o parâmetro é possui valor nulo                                   | ArgumentNullException       |
| ThrowIfOutOfRange     | Valida se o valor do parâmetro está fora do range permitido                 | ArgumentOutOfRangeException |
| ThrowIfInvalid        | Valida se o valor do parâmetro é inválido para a condição esperada          | ArgumentException           |
| ThrowIfNullOrEmpty    | Valida se o valor do parâmetro é nulo ou inválido                           | ArgumentException           |
| ThrowIfMinDateValue   | Valida se o valor do parâmetro no formato de data é inválido                | ArgumentNullException       |
| ThrowIfListOutOfRange | Valida se o a quantidade de registros da lista está fora do range permitido | ArgumentOutOfRangeException |