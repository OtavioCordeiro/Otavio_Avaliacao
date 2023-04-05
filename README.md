# Api de Produtos utilizando a arquitetura Clean
O objetivo dessa api é para o teste de avaliação, escolhi usar a arquitetura clean por algumas de suas vantagens como: separação de responsabilidades, organização do código, flexibilidade, facilidade de manutenção entre outras.

## Tecnologias utilizadas
- ASP.NET Core 6.0
- Microsoft.EntityFrameworkCore.InMemory 7.0.4
- Microsoft.EntityFrameworkCore.SqlServer 7.0.4
- Microsoft.EntityFrameworkCore.Design 7.0.4
- Swagger
- SQL Server 

## Pré-requisitos
Visual Studio 2019 ou superior
.NET 6.0 SDK
SQL Server 

## Executando a API
1. Clone o repositório:
```bash
git clone https://github.com/OtavioCordeiro/Otavio_Avaliacao.git
```

2. Abra o projeto no Visual Studio

3. Configurando o banco de dados com 2 opções

### 3.1 Usando o banco em memória: 
basta descomentar o código 
```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("SistemaDb"));
```

e comentar o código
```csharp
//builder.Services.AddDbContext<ApplicationDbContext>(options => 
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### 3.2 Usando o banco do sql Server

Abra o arquivo appsettings.json e configure a string de conexão com o banco de dados. Exemplo:

```swift
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;"
  }
```  

4. O ApplicationDbContext já esta criando o banco de dados e as tabelas automaticamente caso não exista, 
se desejar pode utilizar os scripts na pasta scripts que esta na solução do projeto e criar manualmente. 
 
5. Compile e execute o projeto.

6. Use alguma ferramenta como o Postman ou o Swagger para testar os endpoints.

Alguns dos Endpoints disponíveis
GET /api/categories - Retorna todas as categorias.
POST /api/categories - Cria uma nova categoria.
GET /api/products - Retorna todos os produtos com a categoria correspondente.
POST /api/products - Cria um novo produto com a categoria correspondente.
