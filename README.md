# apresentacaodevfrontback
Apresentação de desenvolvimento frontend e backend.


-----Backend
VS 2017 e Vs Code
C#, SQL SERVER, .net framewor 4.6, .net standard, .net core
DDD, TDD
API em .net core Swagger
	Tokenização JWT (Json Web Token)
	Identity Claims (Add Role)
	Endpoints com Authorization por role	
Camadas .net standerd
EF, Fluent
Injection
Automapper


1º Abrir projeto no VS2017
2º Efetuar Retore

3º Experimente o comando "Update-Database" no Package Manager Console
	Senão criar a base tente os passos a seguir
	
	3.1º Add-Migration "Apresentacao"
	3.2º Update-Database

4º Inicie a API caso não iniciar mas no terminla indique que a porta 501 esta sendo escultada, abra seu navegador 
e digite o seguinte "http://localhost:501/swagger"
      Obs: API deve ser apresentada com o Open Documentation API "Swagger".

5º Set o projeto de api como inicial e de o start,
	Caso não carregue a index do swagger basta digitar no seu navegado : http://localhost:501/swagge


--Frontend
Angular CLI: 7.3.8
Node: 11.0.0
OS: win32 x64
Angular: 7.2.12
Html 5
Booststrap 4
Integrações com API.
Site responsivo com imagens fluid, Aplicado tecnicas para comportar em outros divice.
Autenticação

Comandos para rodar o projeto.
1º npm install ---para adicionar as dependencias necessarias.
2º ng build
3º ng serve
4º digite em seu navegador --- http://localhost:4200

5º Logar com 
	Username: "romy.moura23@gmail.com" ou "romy.moura"
	Password: teste123
