# PayMart.Login

**Atenção:** Este projeto faz parte de uma arquitetura de microserviços e depende de outras APIs para funcionar corretamente. Certifique-se de que o `PayMart.BFF` está rodando, assim como as outras APIs mencionadas.

## Descrição do Projeto

O `PayMart.Login` é responsável pelo gerenciamento da autenticação e autorização de usuários no sistema PayMart. Este projeto foi desenvolvido em .NET Core 8 e utiliza o JWT (JSON Web Token) para autenticação.

## Funcionalidades

- **Registro de Usuários**: Criação de novas contas de usuários no sistema.
- **Login**: Autenticação de usuários utilizando e-mail e senha.
- **Geração de Tokens JWT**: Geração de tokens JWT para autenticação segura em outras APIs do sistema.
- **Recuperação de Senha**: Envio de e-mail para recuperação de senha.

## Estrutura do Projeto

O projeto segue uma estrutura modular, organizada em camadas:

- **API Layer**
- **Application Layer**
- **Domain Layer**
- **Infrastructure Layer**

## Tecnologias Utilizadas

- **.NET Core 8**
- **SQL Server**
- **Entity Framework Core**
- **JWT (JSON Web Tokens)**
- **Docker**

## Pré-requisitos

Antes de iniciar o projeto, certifique-se de ter as seguintes ferramentas instaladas:

- [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Docker](https://www.docker.com/)
- [Git](https://git-scm.com/)

## Configuração do Projeto

### 1. Clonar o Repositório

```bash
git clone https://github.com/seuusuario/PayMart.Login.git
