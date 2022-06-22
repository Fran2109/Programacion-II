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
Objeto del tipo SqlDataReader
```csharp
SqlDataReader lector;
lector = new SqlDataReader();
```
#### Select
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
commandBuilder = new SqlCommandBuilder(dataAdapter);
dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
```
* Select
```csharp
dataAdapter.Fill(dataSet);
dataGridView1.DataSource = null;dataGridView1.DataSource = dataSet.Tables[0];
```
* Insert
```csharp
string legajo = Interaction.InputBox("Legajo: ");
string nombre = Interaction.InputBox("Nombre: ");
string apellido = Interaction.InputBox("Apellido: ");
DataRow dataRow = dataSet.Table[0].NewRow();
dataRow.ItemArray = new object[] { int.Parse(legajo), nombre, apellido };
dataSet.Table[0].Rows.Add(dataRow);
dataAdapter.Update(dataSet); //No se usa el fill porque primero se actualiza en memoria y luego en la base lo que ace innecesario el fill.
dataGridView1.DataSource = null;dataGridView1.DataSource = dataSet.Tables[0];
```
* Update
```csharp

```
* Delete
```csharp

```
