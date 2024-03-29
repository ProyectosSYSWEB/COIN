﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
using System.Data;
#region Hecho por
//Nombre:      Lisseth Gutiérrez Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion
namespace Recibos_Electronicos.Form
{
    public partial class frmFichaRef_Eventos : System.Web.UI.Page
    {
        #region <Variables>
        Factura ObjFactura = new Factura();
        Alumno ObjAlumno = new Alumno();
        Comun ObjComun = new Comun();
        Evento ObjEvento = new Evento();
        CN_Factura CNFactura = new CN_Factura();
        CN_Comun CNComun = new CN_Comun();
        Usuario Usur = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Evento CNEvento = new CN_Evento();
        String Verificador = string.Empty;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                CargarCombos();


            ScriptManager.RegisterStartupScript(this, GetType(), "Grid", "Eventos();", true);

        }
        #region <Funciones>
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                imgBttnBuscar_Click(null, null);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 40) + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridEventos()
        {
            Int32[] Celdas = { 6 };
            try
            {
                DataTable dt = new DataTable();
                grdEventos.DataSource = dt;
                grdEventos.DataSource = GetListEventos();
                grdEventos.DataBind();
                CNComun.HideColumns(grdEventos, Celdas);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 40) + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private List<Evento> GetListEventos()
        {
            try
            {
                List<Evento> ListEvento = new List<Evento>();
                ObjEvento.Dependencia = ddlDependencia.SelectedValue;
                ObjEvento.Tipo = ddlDirigido.SelectedValue;
                CNEvento.ConsultarEventosRef(ObjEvento, SesionUsu.Usu_Nombre, "A", "N", ref ListEvento);
                return ListEvento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion

        protected void ddlDirigido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGridEventos();
        }

        protected void grdEventos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdEventos.PageIndex = 0;
                grdEventos.PageIndex = e.NewPageIndex;
                CargarGridEventos();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 40) + "');", true);  //lblMsj.Text = ex.Message;
            }

        }

        protected void imgBttnEvento_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdEventos.SelectedIndex = row.RowIndex;
            string WXI=string.Empty;
            try
            {
                Usuario objUsuario = new Usuario();
                objUsuario.Usu_Nombre = SesionUsu.Usu_Nombre;
                CNUsuario.EncriptarUsuario(objUsuario, ref WXI, ref Verificador);
                string Ruta = "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes.aspx?Evento=" + grdEventos.SelectedRow.Cells[0].Text + "&WXIEvento="+WXI;
                ////Response.Redirect(Ruta, false);
                //string ruta2 = "<script>window.open('" + Ruta + "','_blank');</script>";

                ScriptManager.RegisterStartupScript(this, GetType(), "IrEvento", "RedirectEvento('"+Ruta+"');", true);

               
                

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;

            }
        }
    }
}