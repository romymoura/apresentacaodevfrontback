# Apresentação de trabalho Analista Programador e Desenvolvedor Fullstack

	Backend
	•	VS 2017 e Vs Code
	•	C#, SQL SERVER, .net framewor 4.6, .net standard, .net core
	•	DDD, TDD
	•	API em .net core Swagger
	•	Tokenização JWT (Json Web Token)
	•	Identity Claims (Add Role)
	•	Endpoints com Authorization por role	
	•	Camadas .net standerd
	•	EF, Fluent
	•	Injection
	•	Automapper

## Obs: Passos para rodar API

	1.	Abrir projeto no VS2017
	2.	Efetuar Restore
		2.1 Ir em propriedade da API e apontar o xml corrente do projeto.
	3.	Experimente o comando "Update-Database" no Package Manager Console
		a.	Obs: Senão criar a base tente os passos a seguir
		b.	3.1º Add-Migration "Apresentacao"
		c.	3.2º Update-Database
        4. Inicie a API caso não iniciar mas no terminla indique que a porta 501 esta sendo escultada, abra seu navegador e digite o seguinte http://localhost:501/swagger.
		d.	Obs: API deve ser apresentada com o Open Documentation API "Swagger".
        5. Set o projeto de api como inicial e de o start,
	       a. Caso não carregue a index do swagger basta digitar no seu navegado : http://localhost:501/swagge

## Frontend Com Angular e Integrando API

	Frontend
	•	Angular CLI: 7.3.8
	•	ESC5
	•	Node: 11.0.0
	•	OS: win32 x64
	•	Angular: 7.2.12
	•	Html 5
	•	Booststrap 4
	•	Integrações com API.
	•	Site responsivo com imagens fluid, Aplicado tecnicas para comportar em outros divice.
	•	Autenticação

## Obs: Passos para rodar Aplicação

	Comandos para rodar o projeto.
	1. npm install ---para adicionar as dependencias necessarias.
	2. ng build
	3. ng serve
	4. digite em seu navegador --- http://localhost:4200
	5. Logar com 
		a. Username: "romy.moura23@gmail.com" ou "romy.moura"
		b. Password: teste123
