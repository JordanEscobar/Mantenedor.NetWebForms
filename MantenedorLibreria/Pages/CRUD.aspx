
<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="MantenedorLibreria.Pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtnombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Cantidad</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtcantidad"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Precio</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtprecio"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de registro</label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="txtfecha"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btncreate" Text="Create" Visible="false" OnClick="btncreate_Click"/>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnupdate" Text="Update" Visible="false"  OnClick="btnupdate_Click"/>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btndelete" Text="Delete" Visible="false" OnClick="btndelete_Click"/>
            <asp:Button  runat="server" CssClass="btn btn-primary btn-dark" ID="btnvolver" Text="volver" Visible="true" OnClick="btnvolver_Click"/>
        </div>
        
    </form>
</asp:Content>
