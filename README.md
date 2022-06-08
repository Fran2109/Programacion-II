# Programacion-II
## Clase 08/06/2022
### ADO.Net(Access Data Object)
Usamos SQL Server 2019 Version de desarrollador
#### Estados
+ Ado Conectado
+ Ado Desconenctado
##### Ado Conectado
Variable del Tipo SqlConnection
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

