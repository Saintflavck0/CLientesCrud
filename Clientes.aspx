<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="CLientesCrud.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container mt-4">
        <h2>Gestión de Clientes</h2>

        <asp:HiddenField ID="hfClienteId" runat="server" />
        
        <div class="mb-3">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label>Apellidos:</label>
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>
        
        <div class="mb-3">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary ms-2" OnClick="btnCancelar_Click" />
        </div>

        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            DataKeyNames="ClienteId"
            OnRowEditing="gvClientes_RowEditing"
            OnRowUpdating="gvClientes_RowUpdating"
            OnRowCancelingEdit="gvClientes_RowCancelingEdit"
            OnRowDeleting="gvClientes_RowDeleting">
            <Columns>
                <asp:BoundField DataField="ClienteId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Correo" HeaderText="Email" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
