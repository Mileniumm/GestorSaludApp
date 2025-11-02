<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="GestorSaludApp.Pacientes" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>Pacientes</title>
</head>
<body>
 <form id="form1" runat="server">
 <asp:ObjectDataSource ID="odsPacientes" runat="server"
 TypeName="GestorSalud.C2_BLL.Services.PacienteService"
 SelectMethod="GetPaged" SelectCountMethod="GetCount" EnablePaging="true"
 SortParameterName="sortExpression"
 StartRowIndexParameterName="startRowIndex" MaximumRowsParameterName="maximumRows"
 InsertMethod="Create" UpdateMethod="Update" DeleteMethod="Delete">
 </asp:ObjectDataSource>

 <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="false" DataSourceID="odsPacientes"
 DataKeyNames="Id" AllowPaging="true" AllowSorting="true" PageSize="10" >
 <Columns>
 <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="true" />
 <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
 <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
 <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
 <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nac." SortExpression="FechaNacimiento" DataFormatString="{0:yyyy-MM-dd}" />
 <asp:BoundField DataField="Genero" HeaderText="Género" SortExpression="Genero" />
 <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
 </Columns>
 </asp:GridView>

 <h3>Nuevo paciente</h3>
 <asp:DetailsView ID="dvPaciente" runat="server" DataSourceID="odsPacientes" DefaultMode="Insert" AutoGenerateRows="false">
 <Fields>
 <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
 <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
 <asp:BoundField DataField="Email" HeaderText="Email" />
 <asp:TemplateField HeaderText="Fecha Nac.">
 <ItemTemplate>
 <asp:TextBox ID="txtFecha" runat="server" Text='<%# Bind("FechaNacimiento", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
 </ItemTemplate>
 </asp:TemplateField>
 <asp:BoundField DataField="Genero" HeaderText="Género" />
 <asp:CommandField ShowInsertButton="true" />
 </Fields>
 </asp:DetailsView>
 </form>
</body>
</html>