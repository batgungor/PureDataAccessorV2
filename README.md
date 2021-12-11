# Pure Data Accessor V2

.Net 5 üzerinde, farklı DB sistemleri için erişim katmanını hazır olarak sunan bir kütüphane.

## Desteklemeler
#### EntityFrameworkCore
EFCore için desteklenen DB'ler:
 1. SQL Server
 2. PostgreSQL
 3. MySQL
 4. Oracle
 5. SQLite
 6. InMemory
### NoSQL
NoSQL DBler için sadece MongoDB desteği mevcut.

## Kullanım
DI eklemesi için öncelikle Konfigurasyon parametreleri hazırlanmalı

    private PDAEFContextOptions GetSqlServerPDA()
    {
        var connectionString = Configuration.GetConnectionString("ConnStrSqlServer");
        var contextOptions = new PDAEFContextOptions()
        {
            DBType = new SqlServerDBType(connectionString, typeof(Startup).Assembly),
            EntityAssembly = typeof(ProductEntity).Assembly,
            EnableAdminDeveloperMode = true,
            EnableLazyLoading = true
        };
        return contextOptions;
    }
    
Daha Sonra Bu konfigurasyon parametreleri ile birlikte PDA kütüphanesi ServiceCollection içerisine eklenmeli.

    public void ConfigureServices(IServiceCollection services)
    {
        var contextOptions = GetSqlServerPDA();
        services.AddPDA(contextOptions);
        services.AddControllers();
    }
Örnek kullanım **PureDataAccessor.Examples.EntityFrameworkCore** projesinden incelenebilir.
