using Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPS45.Cadastros
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var row = gvClientes.Rows[int.Parse(e.CommandArgument.ToString())];
            switch (e.CommandName)
            {
                case "Selecionar":
                    tbidCliente.Text = Server.HtmlDecode(row.Cells[0].Text);
                    tbCliente.Text = Server.HtmlDecode(row.Cells[1].Text);
                    tbEndereco.Text = Server.HtmlDecode(row.Cells[2].Text);
                    tbResponsavel.Text = Server.HtmlDecode(row.Cells[3].Text);
                    tbTelefone.Text = Server.HtmlDecode(row.Cells[4].Text);
                    tbEmail.Text = Server.HtmlDecode(row.Cells[5].Text);

                    break;
                case "Desativar":
                    Cliente c = new Cliente(Session["connString"].ToString());
                    c.IdCliente = int.Parse(row.Cells[0].Text.ToString());
                    c.Desativar();
                    break;
                default:
                    break;
            }
            gvClientes.DataBind();
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbidCliente.Text))
            {
                Cliente c = new Cliente(int.Parse(tbidCliente.Text), tbCliente.Text, tbEndereco.Text, tbResponsavel.Text, tbTelefone.Text, tbEmail.Text);
                c.ConnString = Session["connString"].ToString();

                if (c.Salvar())
                {
                    gvClientes.DataBind();
                    LimparCampos();
                }
            }
        }

        protected void btLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            tbidCliente.Text = "";
            tbCliente.Text = "";
            tbEndereco.Text = "";
            tbResponsavel.Text = "";
            tbTelefone.Text = "";
            tbEmail.Text = "";
        }

        protected void btAdicionar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente(Session["connString"].ToString());
            c.NomeCliente = Server.HtmlEncode(tbCliente.Text);
            c.Endereco = Server.HtmlEncode(tbEndereco.Text);
            c.Responsavel = Server.HtmlEncode(tbResponsavel.Text);
            c.Telefone = Server.HtmlEncode(tbTelefone.Text);
            c.Email = Server.HtmlEncode(tbEmail.Text);
            if (c.Adicionar())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Cliente adicionado com sucesso!')", true);
                LimparCampos();
                gvClientes.DataBind();
            }
        }
    }
}