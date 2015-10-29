using DNIT.ProjetoEstag.Exercicio2.Dados;
using DNIT.ProjetoEstag.Exercicio2.Negocio.BO;
using DNIT.ProjetoEstag.Exercicio2.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNIT.ProjetoEstag.Exercicio2
{
    public partial class _Default : Page
    {
        EstadoCivilBO estadocivilBO = new EstadoCivilBO();

        SexoBO sexoBO = new SexoBO();

        UsuarioBO usuarioBO = new UsuarioBO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                //Chamando método Carregar Campos Sexo
                this.CarregarSexo();

                //Chamando método Carregar Campos Estado Civil 
                this.CarregarEstadoCivil();


            }

        }

        private void CarregarSexo()
        {
            //Carregar o DropDownList de Sexo
            //List<string> sexos = new List<string>();
            //sexos.Add("Selecione");
            //sexos.Add("Masculino");
            //sexos.Add("Feminino");
            //sexos.Add("Outros");

            //ddlSexo.DataSource = sexos;
            //ddlSexo.DataBind();


            List<SEXO> sexos = sexoBO.CarregarSexo();
            List<string> listaSexo = new List<string>();

            if (sexos != null && sexos.Count > 0)
            {
                foreach (var sexo in sexos)
                {
                    switch (sexo.DS_SEXO)
                    {
                        case "F":
                            listaSexo.Add("FEMININO");
                            break;
                        case "M":
                            listaSexo.Add("MASCULINO");
                            break;
                        case "O":
                            listaSexo.Add("OUTROS");
                            break;
                        default:
                            break;
                    }

                }
            }

            ddlSexo.DataSource = listaSexo;
            ddlSexo.DataBind();
            ddlSexo.Items.Insert(0, "Selecione Sexo");



        }

        private void CarregarEstadoCivil()
        {

            System.Collections.Generic.List<ESTADO_CIVIL> estados = estadocivilBO.Carregar();
            //Carregar o CheckBoxList Estado Civil
            //rbtEstado.Items.Add(new ListItem("Solteiro", "Solteiro"));
            //rbtEstado.Items.Add(new ListItem("Casado", "Casado"));
            rbtEstado.SelectedIndex = 0;
            rbtEstado.DataTextField = "DS_ESTADO_CIVIL";
            rbtEstado.DataValueField = "ID_ESTADO_CIVIL";
            rbtEstado.DataSource = estados;
            rbtEstado.DataBind();



        }

        private string VerificarSexo(string sexo)
        {
            switch (sexo)
            {
                case "MASCULINO":
                    sexo = "M";
                    break;
                case "FEMININO":
                    sexo = "F";
                    break;
                case "OUTROS":
                    sexo = "O";
                    break;
                default:
                    break;
            }


            return sexo;
        }




        private void SalvarCampos()
        {
            sexoBO = new SexoBO();
            USUARIO usuario = new USUARIO();
            usuario.DS_USUARIO = txtNome.Text;
            usuario.ID_SEXO = sexoBO.BuscarIdSexo(VerificarSexo(ddlSexo.SelectedItem.Text));
            usuario.ID_ESTADO_CIVIL = estadocivilBO.BuscaIdEstado(rbtEstado.SelectedItem.Text);

            usuarioBO.Salvar(usuario);




            //DataTable dt = new DataTable();
            //dt.Columns.Add("Nome");
            //dt.Columns.Add("Sexo");
            //dt.Columns.Add("Estado Civil");

            //dt.Rows.Add(txtNome.Text, ddlSexo.SelectedItem.Text, rbtEstado.SelectedItem.Text);

            //gdvResultado.DataSource = dt;
            //gdvResultado.DataBind();
        }


        private void LimparCampos()
        {
            //Limpar campo nome
            txtNome.Text = string.Empty;
            //Limpar campo sexo
            ddlSexo.SelectedIndex = 0;
            ddlSexo.DataSource = null;
            ddlSexo.DataBind();
            //rbtEstado.Text = string.Empty;
            rbtEstado.SelectedIndex = 0;

            //Limpar GridView
            gdvResultado.DataSource = null;
            gdvResultado.DataBind();
        }

        private bool ValidarCampos()
        {
            //Campo TextBox Nome
            if (!string.IsNullOrEmpty(txtNome.Text.Trim()) && Regex.IsMatch(txtNome.Text, @"^[ a-zA-Z á]*$"))
            {
                lblNome.Text = "";
                txtNome.Style.Add(HtmlTextWriterStyle.BorderColor, "");

            }
            else if (!Regex.IsMatch(txtNome.Text, @"^[ a-zA-Z á]*$"))
            {
                lblNome.Text = "Utilize somente letras";
                txtNome.Style.Add(HtmlTextWriterStyle.BorderColor, "red");
                return false;
            }
            else
            {
                //StringBuilder cstext2 = new StringBuilder();
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('Campo Nome esta vazio')", true);
                lblNome.Text = "Por favor preencha o campo";
                txtNome.Style.Add(HtmlTextWriterStyle.BorderColor, "red");
                return false;
            }
            if (ddlSexo.SelectedItem.Text.Trim() == "Selecione Sexo")
            {

                lblSexo.Text = "Por favor selecione o Sexo";
                ddlSexo.Focus();
                return false;
            }
            else
            {

                lblSexo.Text = "";


            }
            return true;
        }



        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                this.SalvarCampos();
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {

            this.LimparCampos();
        }



        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            UsuarioParse uParse = new UsuarioParse();
            var result = usuarioBO.Pesquisar(txtNome.Text);
            List<UsuarioDTO> usuarioEncontrado = uParse.Parse(result);
            gdvResultado.DataSource = usuarioEncontrado;
            gdvResultado.DataBind();


        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            usuarioBO.Deletar(txtNome.Text);
        }
    }
}