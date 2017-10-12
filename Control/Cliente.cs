using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class Cliente : IObjetos<Cliente>
    {
        #region Campos

        private int _idCliente;
        private string _nomeCliente;
        private string _endereco;
        private string _responsavel;
        private string _telefone;
        private string _email;
        private DateTime _dtCriacao;
        private bool _status;

        private string _connString;

        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public string NomeCliente { get => _nomeCliente; set => _nomeCliente = value; }
        public string Endereco { get => _endereco; set => _endereco = value; }
        public string Responsavel { get => _responsavel; set => _responsavel = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime DtCriacao { get => _dtCriacao; set => _dtCriacao = value; }
        public bool Status { get => _status; set => _status = value; }
        public string ConnString { get => _connString; set => _connString = value; }

        #endregion

        public Cliente()
        {

        }
        public Cliente(string connString)
        {
            this.ConnString = connString;
        }

        public Cliente(int ID, string Nome, string endereço, string responsavel, string telefone, string email)
        {
            this.IdCliente = ID;
            this.NomeCliente = Nome;
            this.Endereco = endereço;
            this.Responsavel = responsavel;
            this.Telefone = telefone;
            this.Email = email;
        }

        public bool Adicionar()
        {
            string tsqlInsert = "insert into clientes(cliente, endereco, responsavel, telefone, email) values(@cliente, @endereco, @responsavel, @telefone, @email);";
            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@cliente", this.NomeCliente});
            parametros.Add(new object[] { "@endereco", this.Endereco });
            parametros.Add(new object[] { "@responsavel", this.Responsavel});
            parametros.Add(new object[] { "@telefone", this.Telefone});
            parametros.Add(new object[] { "@email",this.Email });

            var result = new DAO().ExecuteNonQuery(this.ConnString, tsqlInsert, parametros);
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Desativar()
        {
            string tsqlUpdate = "update clientes set status = 0 where idCliente = @idCliente;";
            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@idCliente", this.IdCliente });

            var result = new DAO().ExecuteNonQuery(this.ConnString, tsqlUpdate, parametros);
            if (result > 0)
                return true;
            else
                return false;
        }

        public List<Cliente> Listar(string connString)
        {
            this.ConnString = connString;
            List<Cliente> Lista = new List<Cliente>();

            DataTable dtClientes = new DAO().ReturnDt(this.ConnString, "select idCliente, cliente, endereco, responsavel, telefone, email from clientes where status = 1;");
            foreach (DataRow cliente in dtClientes.Rows)
            {
                Lista.Add(new Cliente(int.Parse(cliente["idCliente"].ToString()), 
                    cliente["cliente"].ToString(),
                    cliente["endereco"].ToString(),
                    cliente["responsavel"].ToString(),
                    cliente["telefone"].ToString(),
                    cliente["email"].ToString()
                    ));
            }


            return Lista;
        }

        public bool Salvar()
        {
            string tsqlUpdate = "UPDATE clientes set endereco = @endereco, responsavel = @responsavel, telefone = @telefone, email = @email where idCliente = @idCliente";
            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@endereco", this.Endereco });
            parametros.Add(new object[] { "@responsavel", this.Responsavel });
            parametros.Add(new object[] { "@telefone", this.Telefone });
            parametros.Add(new object[] { "@email", this.Email });
            parametros.Add(new object[] { "@idCliente", this.IdCliente });

            var result = new DAO().ExecuteNonQuery(this.ConnString, tsqlUpdate, parametros);
            if (result > 0)
                return true;
            else
                return false;
        }

    }
}
