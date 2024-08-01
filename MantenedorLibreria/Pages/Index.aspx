<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MantenedorLibreria.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server"> 
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado de registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success" OnClick="BtnCreate_Click" Text="Create"/>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="table small">
                <asp:GridView  runat="server" ID="gvproductos" CssClass="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="read" CssClass="btn btn-info form-control-sm" ID="Btnread" OnClick="Btnread_Click"/>
                                <asp:Button runat="server" Text="Update" CssClass="btn btn-secondary form-control-sm" ID="Btnupdate" OnClick="Btnupdate_Click"/>
                                <asp:Button runat="server" Text="delete" CssClass="btn btn-danger form-control-sm" ID="Btndelete" OnClick="Btndelete_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>

</asp:Content>
