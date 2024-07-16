### Migrar o Banco de Dados

Para aplicar as migrações com o SQLite, siga estes passos:

1. Adicione uma migração:
    ```bash
    dotnet ef migrations add InitialCreate
    ```

2. Atualize o banco de dados:
    ```bash
    dotnet ef database update
    ```