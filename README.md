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
* Select
```csharp
comando.CommandText = "select * from cliente order by Legajo";
lector = comando.ExecuteReader();
lista_clientes.Clear();
while (lector.Read())//Esta es la funcion cargar lista
{

    lista_clientes.Add(new Cliente()
    {
        Legajo = int.Parse(dr.GetValue(0).ToString()),
        Nombre = dr.GetValue(1).ToString(),
        Apellido = dr.GetValue(2).ToString()
    });
}
lector.Close();
```
* Insert
```csharp
string legajo = Interaction.InputBox("Legajo: ");
if (!Information.IsNumeric(legajo)) throw new Exception("Legajo Inválido");
string nombre = Interaction.InputBox("Nombre: ");
string apellido = Interaction.InputBox("Aoellido: ");
comando.CommandText = $"insert into Cliente (Legajo,Nombre,Apellido) values ({int.Parse(legajo)},'{nombre}','{apellido}')";
comando.ExecuteNonQuery();
CargarLista();
Mostrar(dataGridView1,lista_clientes);
```
* Update
```csharp
string legajo = Interaction.InputBox("Legajo: ");
if (!Information.IsNumeric(legajo)) throw new Exception("Legajo Inválido");
string nombre = Interaction.InputBox("Nombre: ");
string apellido = Interaction.InputBox("Aoellido: ");
comando.CommandText = $"insert into Cliente (Legajo,Nombre,Apellido) values ({int.Parse(legajo)},'{nombre}','{apellido}')";
comando.ExecuteNonQuery();
CargarLista();
Mostrar(dataGridView1,lista_clientes);
```
* Delete
```csharp
comando.CommandText = $"delete from Cliente where Legajo={(dataGridView1.SelectedRows[0].DataBoundItem as Cliente).Legajo}";
comando.ExecuteNonQuery();
CargarLista();
Mostrar(dataGridView1, lista_clientes);
```
## Clase 22/06/2022
### Ado Desconectado
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
ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] }; //Seteo en memoria cual es la primary key para poder usar en el update, delete etc.
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
dataAdapter.Update(dataSet); //No se usa el fill porque primero se actualiza en memoria y luego en la base lo que hace innecesario el fill.
dataGridView1.DataSource = null;dataGridView1.DataSource = dataSet.Tables[0];
```
* Update
```csharp
int legajo = int.Parse(dataGriedView1.SelectedRow[0].Cells[0].Value.ToString());
DataRow dataRow = dataSet.Tables[0].Rows.Find(legajo);
dataRow.SetField<String>(1, Interaction.InputBox("Nombre", "", dataRow.ItemArray[1].ToString());
dataRow.SetField<String>(2, Interaction.InputBox("Apellido", "", dataRow.ItemArray[2].ToString());
dataAdapter.Update(dataSet);
dataGridView1.DataSource = null;dataGridView1.DataSource = dataSet.Tables[0];
```
* Delete
```csharp
int legajo = int.Parse(dataGriedView1.SelectedRow[0].Cells[0].Value.ToString());
(dataSet.Tables[0].Rows.Find(legajo)).Delete();
dataAdapter.Update(dataSet);
dataGridView1.DataSource = null;dataGridView1.DataSource = dataSet.Tables[0];
```
* Pendientes
```csharp
// Suponiendo que no se uso el dataAdapter.Update(dataSet); en ningun lado.
// Es el mismo proceso para Deleted, Added, ModifiedCurrent;
DataView dataView_insertados = new DataView(dataSet.Tables[0]);
dataView_insertados.RowStateFilter = DataViewRowState.Added;
dataGridView2.DataSource = null; dataGridView2.DataSource = dataView_insertados;
```
### Extensiones
```csharp
string codigo = "1234-dgfr-34567/28/04/65";
MessageBox.Show(codigo.ContarPartesCodigo().ToString());
public static class MisExtensiones //Siempre tiene que ser static.
{
    public static int ContarPartesCodigo(this string str)
    {
        return str.Split(new char[] {"-"}).Count();
    }
}
```
## Clase 29/06/2022
Programacion en capas: apunta a dividir el programa en capas independientes del resto de las partes. Al modificar no es necesario modificar todo
BE: Business Entities
V: Vista
Datos: -> DAO: Capa que hace acceso fisico al dato.  ORM: Capa de Mapeadores.
BLL: Business Logical. 
### ADO Desconectado con XML
