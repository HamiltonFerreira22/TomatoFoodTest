#language: pt-br

Funcionalidade: Restaurante

@API_Restaurant

Esquema do Cenário: Cadastro de restaurante

 Dado que tenho perfil de gerente

 Quando  envio o cadastro com restaurante, descricao, tipo e refeicao '<nome_restaurante>' '<descricao_restaurante>' '<tipo_restaurante>' '<refeicao>' '<DescRefe>' '<preco>'

 Entao deve cadastrar com sucesso o restaurante

Exemplos: 

 | nome_restaurante | tipo_restaurante | descricao_restaurante |   refeicao | DescRefe | preco |
 | Rokaido          | Japonês          | Sushi Select          |   Peixe    | Salmao   | 22.25 |
 | Rokaido          | Japonês          | Sushi Select          |   Peixe    | Salmao   | 22.25 |
 | Rokaido          | Japonês          | Sushi Select          |   Peixe    | Salmao   | 22.25 |
 | Rokaido          | Japonês          | Sushi Select          |   Peixe    | Salmao   | 22.25 |
 | Rokaido          | Japonês          | Sushi Select          |   Peixe    | Salmao   | 22.25 |
