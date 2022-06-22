# Programacion-II
## Clase 08/06/2022
### ADO.Net(Access Data Object)
Usamos SQL Server 2019 Version de desarrollador
#### Estados
+ Ado Conectado
+ Ado Desconenctado
##### Ado Conectado
Objeto del Tipo SqlConnection
```csharp
SqlConnection conexion;
conexion = new.SqlConnection("StringDeConexion");
conexion.Open;
conexion.State; //Para saber el estado
conexion.Close;
```
Evento de Cambio de estado
```csharp
conexion.StateChange += CambioEstado;
private void CambioEstado(object sender, StateChangeEventArgs e)
{
    if(e.CurrentState == ConnectionState.Open) { MessageBox.Show("Conectado"); }
    else { MessageBox.Show("Desconectado"); } 
}
```
Objeto del Tipo SqlDataReader
```csharp
SqlDataReader lector;
lector = new SqlDataReader();
```
Objeto del Tipo SqlCommand
```csharp
SqlCommand comando;
comando = new SqlCommand("select * from personas", cx);
```
```csharp
SqlDataReader lector;
lector = new SqlDataReader();
lector = comando.ExecuteReader();
while(lector.Read())
{
    Cliente cliente = new Cliente() {
            Legajo = int.Parse(lector.GetValues(0).toString()), 
            Nombre = lector.GetValues(1).toString(),
            Apellido = lector.GetValues(2).toString()
        };
    listaClientes.Add(cliente);
}
```
## Clase 15/06/2022
## Clase 22/06/2022
