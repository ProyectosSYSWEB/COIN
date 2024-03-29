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
    public partial class frmRecibos_Eventos : System.Web.UI.Page
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
        string MsjError = string.Empty;
        string Reporte = string.Empty;
        double TotalPagos = 0;
        string MesActual = "0";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)           
                Inicializar();
            

            ScriptManager.RegisterStartupScript(this, GetType(), "Grid1", "Eventos();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Grid2", "Pagos();", true);
        }
        #region <Funciones>
        protected void Inicializar()
        {
            //MesActual = System.DateTime.Now.Month.ToString();
            //int Mes = Convert.ToInt32(MesActual);
            //if (Mes > 3)
            //    Mes = Mes - 3;

            //txtFecha_Factura_Ini.Text = "01/" + Mes.ToString().PadLeft(2, '0') + "/" + System.DateTime.Now.Year.ToString();
            //txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            CargarCombos();
        }

        protected void CargarCombos()
        {
            MsjError = string.Empty;
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Ejercicios_Eventos", ref ddlEjercicio, "INGRESOS");
                string anio = DateTime.Now.ToString("yyyy");
                ddlEjercicio.SelectedValue = anio;
                CargarGridEventos();
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridEventos()
        {
            //Int32[] Celdas = { 6 };
            MsjError = string.Empty;
            grdDatosFactura.DataSource = null;
            grdDatosFactura.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdEventos.DataSource = dt;
                grdEventos.DataSource = GetListEventos();
                grdEventos.DataBind();

                if (grdEventos.Rows.Count >= 1)
                {
                    this.grdEventos.SelectedIndex = 0;
                    grdEventos_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private void CargarGridPagos()
        {
            //var usuAdmin = Array.FindAll(UsuariosSuper, s => s.Equals(SesionUsu.Usu_Nombre));
            MsjError = string.Empty;
            Int32[] Celdas = { 0 };

            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetList();
                grdDatosFactura.DataBind();
                if (grdDatosFactura.Rows.Count >= 1)
                {
                    CNComun.HideColumns(grdDatosFactura, Celdas);
                    //Label lblLeyTot = (Label)grdDatosFactura.FooterRow.FindControl("lblLeyTotPagos");
                    //Label lblTot = (Label)grdDatosFactura.FooterRow.FindControl("lblTotPagos");

                    
                    //pnlBuscaRef.Visible = true;
                }
                //else
                //    pnlBuscaRef.Visible = false;

            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }


        private List<Evento> GetListEventos()
        {
            try
            {
                List<Evento> ListEvento = new List<Evento>();
                ObjEvento.Dependencia = ddlDependencia.SelectedValue;
                ObjEvento.Tipo = ddlDirigido.SelectedValue;
                ObjEvento.Anio = Convert.ToInt32(ddlEjercicio.SelectedValue);
                //ObjEvento.Fecha_inicial = txtFecha_Factura_Ini.Text;
                //ObjEvento.Fecha_final = txtFecha_Factura_Fin.Text;
                CNEvento.ConsultarEventosTipoUsu(ObjEvento, SesionUsu.Usu_Nombre, Convert.ToString(SesionUsu.Usu_TipoUsu), "A" , "", ref ListEvento);
                return ListEvento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Factura> GetList()
        {
            TotalPagos = 0;
            try
            {
                List<Factura> List = new List<Factura>();
                Factura ObjFactura = new Factura();
                Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                Usur.Usu_NoControl = SesionUsu.Usu_NoControl;
                Usur.Usu_TipoUsu = SesionUsu.Usu_TipoUsu;
                CNFactura.FacturaEventosConsultaGrid(ref ObjFactura, Usur, grdEventos.SelectedRow.Cells[1].Text , "", ref List);
                TotalPagos = List.Sum(item =>Convert.ToDouble(item.FACT_TOTAL));
                if (SesionUsu.Usu_TipoUsu == 3)                
                    lblTotPagos.Text = TotalPagos.ToString("C");                
                else                
                    lblTotPagos.Visible = false;

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        protected void ddlDirigido_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridEventos();
            grdDatosFactura.DataSource = null;
            grdDatosFactura.DataBind();
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGridPagos();
            grdDatosFactura.DataSource = null;
            grdDatosFactura.DataBind();
        }

        protected void grdEventos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MsjError = string.Empty;
            try
            {
                grdEventos.PageIndex = 0;
                grdEventos.PageIndex = e.NewPageIndex;
                CargarGridEventos();
                CargarGridPagos();
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }

        }

        protected void imgBttnEvento_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdEventos.SelectedIndex = row.RowIndex;
            string Ruta = grdEventos.SelectedRow.Cells[7].Text;
            Response.Redirect(Ruta, false);
        }

        protected void grdEventos_SelectedIndexChanged(object sender, EventArgs e)
        {            
            CargarGridPagos();
        }

        protected void imgBttnCorreo_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            try
            {
                grdDatosFactura.SelectedIndex = row.RowIndex;
                PnlCorreo.Matricula = grdDatosFactura.SelectedRow.Cells[8].Text;
                PnlCorreo.Recibo = grdDatosFactura.SelectedRow.Cells[0].Text;
                PnlCorreo.Muestra();
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {            
            Reporte = "../Reportes/VisualizadorCrystal.aspx?idFact=" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
            string _open = "window.open('" + Reporte + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void grdDatosFactura_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MsjError = string.Empty;
            try
            {
                grdDatosFactura.PageIndex = 0;
                grdDatosFactura.PageIndex = e.NewPageIndex;
                CargarGridPagos();
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }

        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string obs = "";
            string ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP055&Evento=" + grdEventos.SelectedRow.Cells[1].Text + "&Observaciones=" + obs + "&enExcel=N";
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void imgBttnReporteLote_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP063&Evento=" + grdEventos.SelectedRow.Cells[1].Text + "&enExcel=N";
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);
        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ruta1 = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP055&Evento=" + grdEventos.SelectedRow.Cells[1].Text + "&enExcel=S";
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);

        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridEventos();
            grdDatosFactura.DataSource = null;
            grdDatosFactura.DataBind();
        }

        protected void imgBttnBuscarEvento_Click(object sender, ImageClickEventArgs e)
        {
            CargarGridEventos();
        }

        protected void grdEventos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //txtReferencia.Text = string.Empty;
        }

        protected void linkBttnBuscar_Click(object sender, EventArgs e)
        {
            CargarGridEventos();
        }

        protected void linkBttnBuscar_Click1(object sender, EventArgs e)
        {
            CargarGridPagos();
        }
    }
}