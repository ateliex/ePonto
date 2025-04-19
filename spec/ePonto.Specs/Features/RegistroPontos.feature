# language: pt-br

Funcionalidade: Registro Pontos

O sistema deverá fornecer para o trabalhador a capacidade de marcar um ponto

Regra: Um ponto pode ser marcado

@main
Cenário: [Marcar Ponto] Trabalhador 'Marcelo' marca um ponto às '27/11/2022 09:14'
	Dado que o trabalhador 'Marcelo' está autenticado
	Quando o trabalhador 'Marcelo' marcar o ponto às '27/11/2022 09:14'
	#Quando ele marcar o ponto às '27/11/2022 09:14'
	Então um ponto deverá ser registrado para o trabalhador 'Marcelo' às '27/11/2022 09:14'
	#Então um ponto deverá ser registrado para ele como esperado