## Game Store API


## setting the connection string to secret manager
````powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id=sa Password=$sa_password; TrustServerCertificate=True"
````

## Data Source=DESKTOP-QLC1JI2\\SQLEXPRESS;Initial Catalog=GameStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False