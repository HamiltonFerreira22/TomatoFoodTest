#language: pt-br

Funcionalidade: login

@API_Login

Esquema do Cenário: Login com senha invalida

    Dado que preciso de uma senha invalida

    Quando requisito a API de login com email e senha '<email>' 
    Entao deve ver mostrar mensagem '<mensagem>'

Exemplos: 

 | email                   |  mensagem          |
 | Kleber_Macedo27@live.com| Password incorrect |
 | hfpj18@gmail.com        | Password incorrect |