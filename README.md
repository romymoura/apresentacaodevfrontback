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

## Obs: Passo para rodar API

	1.	Abrir projeto no VS2017
	2.	Efetuar Retore
	3.	Experimente o comando "Update-Database" no Package Manager Console
		a.	Obs: Senão criar a base tente os passos a seguir
		b.	3.1º Add-Migration "Apresentacao"
		c.	3.2º Update-Database
        4. Inicie a API caso não iniciar mas no terminla indique que a porta 501 esta sendo escultada, abra seu navegador e digite o seguinte http://localhost:501/swagger.
		d.	Obs: API deve ser apresentada com o Open Documentation API "Swagger".
        5. Set o projeto de api como inicial e de o start,
	       a. Caso não carregue a index do swagger basta digitar no seu navegado : http://localhost:501/swagge

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
