#language: pt-br

Funcionalidade: Pedido

A short summary of the feature

@API_Order

Esquema do Cenário: Cadastro de pedido
 Dado que tenho acesso para realizar pedido
 Quando envio a ordem com valor restaurante e refeicao
 Entao deve cadastrar o pedido com o desconto '<desc>'

Exemplos: 

 | desc | 
 | 0,05 |


 #inclusão de mais cenarios
 @API_Order
Esquema do Cenário: Cadastro de pedidos
 Dado que tenho acesso para realizar pedido
 Quando envio a ordem com valor restaurante e refeicao '<valor>'
 Entao deve cadastrar os pedidos com os descontos '<desc>'

Exemplos: 
 |  valor    | desc |
 |  140      | 0,0  |
 |  251      | 0,05 |
 |  502      | 0,08 |
 |  1092     | 0,1  |