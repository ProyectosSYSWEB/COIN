using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json.Linq;
using RestSharp;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion
namespace Recibos_Electronicos
{
    public partial class Acceso : System.Web.UI.Page
    {
        //pruebas

        #region <Variables>
        string Verificador = string.Empty;
        string NombreUsu = string.Empty;
        CN_Usuario CN_Usuario = new CN_Usuario();
        CN_Comun CNComun = new CN_Comun();
        //Usuario Usuario = new Usuario();
        Sesion Sesion = new Sesion();
        Usuario ObjUsuario = new Usuario();
        protected string Token = null;
        protected string Origen = null;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["RGN"] != null)
                {
                    DDLTipoUsuario.SelectedValue = "1";
                    txtCve.Visible = true;
                    txtCve.Text = Convert.ToString(Request.QueryString["RGN"]);
                }
                //if (Request.QueryString["Token"] != null)
                //{
                //    string TokenUsu = Convert.ToString(Request.QueryString["Token"]);
                //    ObjUsuario.Token = Convert.ToString(TokenUsu);
                //    CN_Usuario.ValidarToken(ref ObjUsuario, ref Verificador);
                //    if (Verificador == "0")
                //    {
                //        DDLTipoUsuario.SelectedValue = "3";
                //        txtCve.Text = ObjUsuario.Usu_Nombre;
                //        txtPassword.Text = ObjUsuario.Password;
                //        btnIngresar_Click(null, null);
                //    }
                //    else
                //    {
                //        pnlMsj.Visible = true;
                //        lblMensaje.Text = "El Token no es válido";
                //    }

                    //}
            }
            catch (Exception ex)
            {
                pnlMsj.Visible = true;
                lblMensaje.Text = ex.Message;

            }
            //Sesion = (Sesion)Session["Usuario"];

            //Origen = Convert.ToString(Request.QueryString["RGN"]);
            //if (!IsPostBack)
            //{
            //    if (Origen != null)
            //    {
            //        if (Origen == "ASP")
            //        {
            //            DDLTipoUsuario.SelectedValue = "1";
            //            DDLTipoUsuario_SelectedIndexChanged(null, null);
            //            pnlMsj.Visible = true;
            //            lblMensaje.Text = "Para obtener el recibo oficial ingresar al siguiente día hábil de haber realizado el pago, si se realizo el día sábado estará disponible hasta el día martes.";
            //        }
            //    }
            //}
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            pnlMsj.Visible = false;
            lblMensaje.Text = string.Empty;// Verificador;
            try
            {
                string Validado = ValidarInfUsuario();
                if (Validado == "0")
                    IniciarSesion();
                else
                {
                    txtCve.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtCve.Focus();
                    pnlMsj.Visible = true;
                    if (DDLTipoUsuario.SelectedValue == "1")
                        lblMensaje.Text = "Alumno/aspirante no encontrado, favor de verificar.";
                    else if (DDLTipoUsuario.SelectedValue == "4")
                        lblMensaje.Text = "Referencia no encontrada, favor de verificar.";
                    else
                    {
                        pnlMsj.Visible = true;
                        lblMensaje.Text = Validado;
                    }
                }
            }
            catch (Exception ex)
            {
                pnlMsj.Visible = true;
                lblMensaje.Text = ex.Message;

            }
        }

        //protected void DDLTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DDLTipoUsuario.SelectedValue.ToString() == "1")
        //        txtPassword.Visible = false;
        //}        
        public string ValidarInfUsuario()
        {
            Verificador = string.Empty;
            NombreUsu = string.Empty;
            try
            {
                if (DDLTipoUsuario.SelectedValue == "1")
                {
                    Sesion.Usu_Nombre = txtCve.Text;
                    Sesion.Usu_NoControl = string.Empty; // DDLEscuelas.SelectedValue;                    
                }
                else if (DDLTipoUsuario.SelectedValue == "2")
                {
                    Sesion.Usu_Nombre = txtCve.Text;
                    Sesion.Usu_NoControl = string.Empty;
                }
                else if (DDLTipoUsuario.SelectedValue == "3")
                {
                    Sesion.Correo_UNACH = txtCve.Text;
                    Sesion.Usu_NoControl = txtPassword.Text;
                }
                else if (DDLTipoUsuario.SelectedValue == "6")
                {
                    Sesion.Usu_Nombre = txtCve.Text;
                    Sesion.Usu_NoControl = string.Empty;
                }
                else
                {
                    Sesion.Usu_Nombre = txtCve.Text; //txtPassword.Text;
                    Sesion.Usu_NoControl = string.Empty; //txtReferencia.Text;
                }
                Sesion.Usu_TipoUsu = Convert.ToInt32(DDLTipoUsuario.SelectedValue);

                if (Sesion.Usu_TipoUsu == 3)
                {
                    bool Valido = ValidaCorreoUNACH(ref NombreUsu);
                    //if (txtPassword.Text == "F1N4NZ4S")
                    if (Valido == true)
                    {
                        //Sesion.Correo_UNACH = txtCve.Text;
                        CN_Usuario.UsuarioPermisos(ref Sesion, txtCve.Text, ref Verificador);
                        if (Verificador == "0")
                        {
                            //Usuario.Usu_Nombre = Sesion.Usu_Nombre;
                            //Usuario.Usu_TipoUsu = Convert.ToInt32("3");
                            Sesion.Usu_Nombre = Sesion.Usuario;
                            Sesion.Nombre_Completo = NombreUsu;
                            Sesion.Usu_TipoUsu = Convert.ToInt32("3");
                            Sesion.Correo_UNACH = txtCve.Text;
                            
                        }
                    }
                    else
                        Verificador = "No fue posible realizar la autenticación, correo o contraseña no validos.";

                    
                }
                else if (Sesion.Usu_TipoUsu == 6)
                {
                    CN_Usuario.ValidarCliente(ref Sesion, ref Verificador);
                    if (Verificador == "0")
                    {
                        Sesion.Usu_Nombre = txtCve.Text;
                        //CN_Usuario.UsuarioCentral(ref Sesion, ref Verificador);
                    }

                }

                else
                    CN_Usuario.ValidarUsuario(ref Sesion, ref Verificador);


                return Verificador;
            }
            catch (Exception ex)
            {
                string Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                //pnlMsj.Visible = true;
                //lblMensaje.Text = ex.Message;
                return Verificador;
            }
        }

        public bool ValidaCorreoUNACH(ref string Nombre)
        {
            try
            {
                var client = new RestClient("http://ldapm.unach.mx/authldap.php");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Username", "ldapru");
                request.AddHeader("Password", "01#lDhyr983wry");
                request.AddHeader("Authorization", "Basic bGRhcHJ1OjAxI2xEaHlyOTgzd3J5");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("ldapuser", txtCve.Text);
                request.AddParameter("ldappasswd", txtPassword.Text);
                IRestResponse response = client.Execute(request);
                //lblError.Text = response.Content;
                var jObject = JObject.Parse(response.Content);

                //Extracting Node element using Getvalue method
                string Autorizado = jObject.GetValue("valido").ToString();
                if (jObject.GetValue("gecos").ToString() == string.Empty)
                    Nombre = ""; 
                else
                    Nombre = jObject.GetValue("gecos").ToString();

                if (Autorizado == "0")
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public void IniciarSesion()
        {
            try
            {
                //Sesion.Usu_TipoUsu = Usuario.Usu_TipoUsu;
                //Sesion.Usu_NoControl = Usuario.Usu_NoControl.ToUpper();
                //Sesion.Usu_Nombre = Usuario.Usu_Nombre.ToUpper();

                Session["Usuario"] = Sesion;
                Session.Timeout = 120;

                //Verifica que el usuario tenga correo unach
                if (Sesion.Usu_TipoUsu == 3)
                {   
                    if(Sesion.Usu_Central=="S")
                        Response.Redirect("frmInicio.aspx", false);
                    else
                        Response.Redirect("Inicio.aspx", false);
                }
                else if (Sesion.Usu_TipoUsu == 6)
                    Response.Redirect("Form/frmRefVenta_Pat.aspx", false);
                else
                {
                    Sesion.Correo_UNACH = txtCve.Text.ToUpper();
                    Sesion.Nombre_Completo = txtCve.Text.ToUpper();
                    Sesion.Usuario = "ALUMNO";
                    Response.Redirect("Inicio.aspx", false);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Write("Button Clicked");

        }

    }
}