﻿using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos_Electronicos.Reportes
{
    public partial class frmReporteGrals : System.Web.UI.Page
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
        string Verificador = "";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
        }
        protected void Inicializar()
        {
            var Usu = SesionUsu.Usu_Nombre;
            //SesionUsu.ReporteEnExcel = "N";
            //SesionUsu.ReporteconGraficas = "N";
            //SesionUsu.Reporte = string.Empty;
            //SesionUsu.Evento = string.Empty;
            CargarCombos();

        }
        protected void CargarCombos()
        {
            try
            {

                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Niveles", ref DDLNivel, "INGRESOS");
                DDLNivel.SelectedValue = "T";
                DDLNivel_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);
            }
        }

        protected void DDLNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaComboG("PKG_FELECTRONICA_2016.Obt_Combo_Conceptos", ref DDLConceptos, "p_nivel", DDLNivel.SelectedValue);
        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.ReporteEnExcel = "S";
            ConsultarReportesConceptos();
            SesionUsu.ReporteEnExcel = "N";
        }
        protected void ConsultarReportesConceptos()
        {
            string ruta = "VisualizadorCrystal.aspx?Tipo=REP005&CDet=" + ddlDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&IdConcepto=" + DDLConceptos.SelectedValue + "&Ejercicio=" + 0 + "&Mes=" + 0 + "&ciclo=" + 0 + "&TipoDesc=0&Status=A&Nivel=" + DDLNivel.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
    }
}