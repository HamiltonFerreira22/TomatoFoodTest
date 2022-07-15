#language: pt-br

Funcionalidade: cadastro

A short sumary of the feature

@API_Register

Esquema do Cenário: Cadastro de gerente

	Dado que preciso gerar um usuario gerente

	Quando requisito a API de Registro com nome, email, senha, confirmacao da senha e funcao

	Entao deve cadastrar com sucesso