# User API

## Descrição

API RESTful para gerenciamento de usuários, desenvolvida com .NET 6, utilizando Entity Framework Core e seguindo os princípios de Clean Code e SOLID.

## Configuração

### Requisitos

- .NET 6 SDK
- Docker
- Docker Compose

### Executando a Aplicação

1. Clone o repositório:
    ```bash
    git clone https://github.com/ricardosnatos1975/UserApi.git
    cd UserApi
    ```

2. Execute os contêineres Docker:
    ```bash
    docker-compose up
    ```

3. Acesse a API em `http://localhost:7257` e a documentação do Swagger em `http://localhost:7257/swagger`.

## Testes

Para executar os testes unitários:
```bash
dotnet test
