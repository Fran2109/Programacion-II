# Programacion-II
## Clase 08/06/2022
### ADO.Net(Access Data Object)
Usamos SQL Server 2019 Version de desarrollador
### Estados
+ Ado Conectado
+ Ado Desconenctado
### Ado Conectado
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
comando = new SqlCommand("select * from cliente order by Legajo", conexion);
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
#### Read
```csharp
comando.CommandText = "select * from cliente order by Legajo";
lector = comando.ExecuteReader();
lista_clientes.Clear();
while (lector.Read())
{

    lista_clientes.Add(new Cliente()
    {
        Legajo = int.Parse(dr.GetValue(0).ToString()),
        Nombre = dr.GetValue(1).ToString(),
        Apellido = dr.GetValue(2).ToString()
    });
}
```
## Clase 15/06/2022
### Ado Desconectado

## Clase 22/06/2022
### DataAdapter
```csharp
DataSet dataSet;
SqlDataAdapter dataAdapter;
dataSet = new SqlDataAdapter("select * from cliente", "Data Source=.;Initial Catalog=Personas;Integrated Security=True");
dataAdapter = new DataSet();
dataAdapter.fills(dataSet);
dataGridView1.DataSource = null;dataGridView1.DataSource = dataSet.Tables[0];
```csharp
* Select
* Insert
* Update
* Delete
