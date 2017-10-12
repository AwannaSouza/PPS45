
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="PPS45.Cadastros.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
	<div class="row">
		<div class="col-md-12">
            <h2>Cadastro de Clientes</h2>
		</div>
	</div>
    <div class="row">
		<div class="col-md-3">
            <asp:TextBox ID="tbidCliente" runat="server" Visible="false"></asp:TextBox>
            <label>Cliente</label><asp:RequiredFieldValidator runat="server" ID="rfCliente" ErrorMessage="*" ControlToValidate="tbCliente" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbCliente" runat="server" CssClass="form-control"></asp:TextBox>
		</div>
            
		<div class="col-md-3">
            <label>Endereço</label><asp:RequiredFieldValidator runat="server" ID="rfEndereco" ErrorMessage="*" ControlToValidate="tbEndereco" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbEndereco" runat="server" CssClass="form-control"></asp:TextBox>
            
		</div>
        <div class="col-md-3">
            <label>Responsável</label><asp:RequiredFieldValidator runat="server" ID="rfResponsavel" ErrorMessage="*" ControlToValidate="tbResponsavel" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbResponsavel" runat="server" CssClass="form-control"></asp:TextBox>
		</div>
       
	</div>

    <div class="row">
         <div class="col-md-3">
            <label>Telefone</label><asp:RequiredFieldValidator runat="server" ID="rfTelefone" ErrorMessage="*" ControlToValidate="tbTelefone" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbTelefone" runat="server" CssClass="form-control"></asp:TextBox>
		</div>

        <div class="col-md-3">
            <label>Email</label><asp:RequiredFieldValidator runat="server" ID="rfEmail" ErrorMessage="*" ControlToValidate="tbEmail" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>
       
    </div>
    <br />
    <div class="row">
        <div class="col-md-3">
            <asp:Button ID="btAdicionar" runat="server" Text="Adicionar" CssClass="btn btn-default" OnClick="btAdicionar_Click" />
            <asp:Button ID="btSalvar" runat="server" Text="Salvar" CssClass="btn btn-default" OnClick="btSalvar_Click" />
            <asp:Button ID="btLimpar" runat="server" Text="Limpar" CssClass="btn btn-default" OnClick="btLimpar_Click" CausesValidation="false" />

        </div>
    </div>
        <br />
	<div class="row">
		<div class="col-md-12">
            <asp:GridView runat="server" ID="gvClientes" CssClass="table table-hover table-condensed" DataSourceID="dsClientes" AutoGenerateColumns="False" OnRowCommand="gvClientes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="IdCliente" HeaderText="ID" SortExpression="IdCliente" />
                    <asp:BoundField DataField="NomeCliente" HeaderText="Cliente" SortExpression="NomeCliente" />
                    <asp:BoundField DataField="Endereco" HeaderText="Endereço" SortExpression="Endereco" />
                    <asp:BoundField DataField="Responsavel" HeaderText="Responsável" SortExpression="Responsavel" />
                    <asp:BoundField DataField="Telefone" HeaderText="Telefone" SortExpression="Telefone" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CssClass="glyphicon glyphicon-pencil" CommandName="Selecionar"  CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" CausesValidation="false" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CssClass="glyphicon glyphicon-remove"  CommandName="Desativar"  CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"  CausesValidation="false" OnClientClick="return Confirmar('Deseja excluir este cliente?');" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
		</div>
	</div>
</div>
    <asp:ObjectDataSource ID="dsClientes" runat="server" SelectMethod="Listar" TypeName="Control.Cliente">
         <SelectParameters>
                <asp:SessionParameter Name="connString" SessionField="connString" Type="String" />
         </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
