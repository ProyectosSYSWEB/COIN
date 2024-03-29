﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data;
using CapaNegocio;
using CapaEntidad;

namespace Recibos_Electronicos.Form
{
    public partial class FrmRepIngresos : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        List<ConceptoPago> ListDetConcepto = new List<ConceptoPago>();
        ConceptoPago ObjConceptos = new ConceptoPago();
        CN_ConceptoPago CNConceptos = new CN_ConceptoPago();

        protected string UrlReporte = null;

        #endregion
        protected string Conceptos_Seleccionados()
        {
            //string Conceptos = string.Empty;
            //string ConceptosSeleccionados;
            int UltimoReg;
            var ConceptosSeleccionados=string.Empty;
            IEnumerable<string> Conceptos;


            foreach (GridViewRow gvrow in grvConceptos.Rows)
            {
                var checkbox = gvrow.FindControl("chkConcepto") as CheckBox;
                if (checkbox.Checked)
                {
                    ConceptosSeleccionados = grvConceptos.DataKeys[gvrow.RowIndex].Value.ToString()+","+ ConceptosSeleccionados;
                }
            }

            //Conceptos = from GridViewRow msgRow in grvConceptos.Rows
            //                               where ((CheckBox)msgRow.FindControl("chkConcepto")).Checked
            //                               select
            //                               (String)(grvConceptos.DataKeys[msgRow.RowIndex].Value.ToString());
            //    ConceptosSeleccionados = Conceptos + ConceptosSeleccionados;
            
            //foreach (var CveConcepto in checkedCvesConceptos)
            //{
            //    Conceptos = Conceptos + CveConcepto + ",";
            //}

            UltimoReg = ConceptosSeleccionados.Length;
            if (UltimoReg > 0)
                ConceptosSeleccionados = ConceptosSeleccionados.Substring(0, UltimoReg - 1);
            else
                ConceptosSeleccionados = string.Empty;

            return ConceptosSeleccionados;



            //UltimoReg = Conceptos.Length;
            //if (UltimoReg > 0)
            //    ConceptosSeleccionados = Conceptos.Substring(0, UltimoReg - 1);
            //else
            //    ConceptosSeleccionados = string.Empty;

            //return ConceptosSeleccionados;
        }
        protected void Seleccionar_Todos()
        {
            var checkedCvesConceptos = from GridViewRow msgRow in grvConceptos.Rows
                                       where ((CheckBox)msgRow.FindControl("chkConcepto")).Checked
                                       select (String)(grvConceptos.DataKeys[msgRow.RowIndex].Value.ToString());
        }

        protected void Inicializar()
        {
            SesionUsu.Editar = 0;
            txtFecha_Factura_Ini.Text = "01/01/" + System.DateTime.Now.Year.ToString();
            txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            if(UrlReporte == "REP045" || UrlReporte == "REP046")
            {
                //lblCiclo.Visible = true;
                //ddlCiclo.Visible = true;
                rowCiclo.Visible = true;
                lblFecha_Factura_Ini.Visible = false;
                txtFecha_Factura_Ini.Visible = false;
                lblFecha_Factura_Fin.Visible = false;
                txtFecha_Factura_Fin.Visible = false;
                lblNivel.Visible = false;
                DDLNivel.Visible = false;
                //lblOrdenar.Visible = false;
                //ddlOrden.Visible = false;
                //lblConceptos.Visible = false;
                grvConceptos.Visible = false;
                imgCalendarioIni.Visible = false;
                imgCalendarioFin.Visible = false;
                //divGrid.Style.Add("display", "none");
                //txtBuscar.Visible = false;
                linBttnBuscar.Visible = false;
                //imgBttnBuscar.Visible = false;

            }


            CargarCombos();
        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Niveles", ref DDLNivel, "INGRESOS");
                CNComun.LlenaComboG("pkg_pagos_2016.Obt_Ciclos_Escolares", ref ddlCiclo, "INGRESOS");
                DDLNivel.SelectedValue = "L";
                DDLNivel_SelectedIndexChanged(null, null);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private List<ConceptoPago> GetListConceptos(bool Habilitado)
        {
            Session["Conceptos"] = null;
            try
            {
                List<ConceptoPago> List = new List<ConceptoPago>();
                ObjConceptos.Nivel = DDLNivel.SelectedValue;
                ObjConceptos.Status = 'A';
                //CNConceptos.ConceptoConsultaGrid(ref ObjConceptos, ddlOrden.SelectedValue, Habilitado, txtBuscar.Text.ToUpper(), ref List);
                CNConceptos.ConceptoConsultaGrid(ref ObjConceptos, "1", Habilitado, string.Empty, ref List);
                Session["Conceptos"] = List;

                //if (Session["Conceptos"] == null)
                //{
                //    ListDetConcepto = new List<DetConcepto>();
                //    ListDetConcepto.Add(ObjConceptoDet);
                    return List;
            }
            catch (Exception ex)

            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGridCatConceptos(bool Habilitado)
        {
            //Int32[] Celdas1 = new Int32[] { 2, 3 };
            //Int32[] Celdas2 = new Int32[] { 3 };
            try
            {
                DataTable dt = new DataTable();
                grvConceptos.DataSource = dt;
                grvConceptos.DataSource = GetListConceptos(Habilitado);
                grvConceptos.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        //private void CargarGridCatConceptos2(bool Habilitado)
        //{
        //    //Int32[] Celdas1 = new Int32[] { 2, 3 };
        //    //Int32[] Celdas2 = new Int32[] { 3 };
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        grvConceptos.DataSource = dt;
        //        grvConceptos.DataSource = GetListConceptos();
        //        grvConceptos.DataBind();

        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];


            UrlReporte = Convert.ToString(Request.QueryString["SourceID"]);

            if (!IsPostBack)
                Inicializar();

            ScriptManager.RegisterStartupScript(this, GetType(), "Grid", "Conceptos();", true);

        }

        protected void DDLNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridCatConceptos(false);
        }

        protected void grvConceptos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConceptos.PageIndex = 0;
            grvConceptos.PageIndex = e.NewPageIndex;
            CargarGridCatConceptos(false);
        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;

            if (UrlReporte == "REP045" || UrlReporte == "REP046")
            {
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo="+ UrlReporte + "&dependencia=" + ddlDependencia.SelectedValue + "&ciclo=" + ddlCiclo.SelectedValue + "&enExcel=N";
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            }
            else
            {
                string ConceptosSeleccionados = string.Empty;
                CheckBox chkTodosConceptos = (CheckBox)grvConceptos.HeaderRow.FindControl("chkTodosConc");
                bool ValorActual = chkTodosConceptos.Checked;

                if (DDLNivel.SelectedValue == "T" && ValorActual == true)
                    ConceptosSeleccionados = "TODOS";
                else
                    ConceptosSeleccionados = Conceptos_Seleccionados();


                if (ConceptosSeleccionados != string.Empty)
                {
                    if (UrlReporte == "REP038") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP038&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
                    else if (UrlReporte == "REP039") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP039&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
                    else if (UrlReporte == "REP040") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP040&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
                    else if (UrlReporte == "REP041") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP041&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Debe seleccionar al menos un concepto.');", true); //lblMsj.Text = ex.Message;

            }
        }

        protected void ddlOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridCatConceptos(false);

        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;

            if (UrlReporte == "REP045" || UrlReporte == "REP046")
            {
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo="+ UrlReporte + "&dependencia=" + ddlDependencia.SelectedValue + "&ciclo=" + ddlCiclo.SelectedValue + "&enExcel=S";
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            }
            else
            {

                string ConceptosSeleccionados = string.Empty;
                CheckBox chkTodosConceptos = (CheckBox)grvConceptos.HeaderRow.FindControl("chkTodosConc");
                bool ValorActual = chkTodosConceptos.Checked;

                if (DDLNivel.SelectedValue == "T" && ValorActual == true)
                    ConceptosSeleccionados = "TODOS";
                else
                    ConceptosSeleccionados = Conceptos_Seleccionados();




                if (ConceptosSeleccionados != string.Empty)
                {
                    if (UrlReporte == "REP038") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP038&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=S";
                    else if (UrlReporte == "REP039") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP039&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=S";
                    else if (UrlReporte == "REP040") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP040&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=S";





                    else if (UrlReporte == "REP041") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP041&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=S";
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Debe seleccionar al menos un concepto.');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void chkTodosConc_CheckedChanged(object sender, EventArgs e)
        {
            bool ValorActual;
            SesionUsu.Editar = 1;
            CheckBox chkTodosConc = (CheckBox)sender;
            ValorActual = chkTodosConc.Checked;
            CargarGridCatConceptos(ValorActual);
            
            CheckBox chkTodosConceptos = (CheckBox)grvConceptos.HeaderRow.FindControl("chkTodosConc");
            chkTodosConceptos.Checked = ValorActual;
            SesionUsu.Editar = 0;

        }

        //protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        //{
        //    CargarGridCatConceptos(false);
        //}

        protected void linBttnBuscar_Click(object sender, EventArgs e)
        {
            CargarGridCatConceptos(false);
        }

        protected void chkConcepto_CheckedChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Editar == 0)
            {
                CheckBox cbi = (CheckBox)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvConceptos.SelectedIndex = row.RowIndex;
                DetConcepto ObjConceptoDet = new DetConcepto();

                ListDetConcepto = (List<ConceptoPago>)Session["Conceptos"];

                if (cbi.Checked == true)
                {
                    ObjConceptoDet.ClaveConcepto = grvConceptos.SelectedRow.Cells[0].Text;
                    ListDetConcepto.Add(ObjConceptoDet);
                }
                else
                {
                    ListDetConcepto.RemoveAt(row.RowIndex);
                    Session["Conceptos"] = ListDetConcepto;
                }
            }
        }

        protected void grvConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBox cbi = (CheckBox)(grvConceptos.SelectedRow.Cells[2].FindControl("chkConcepto"));
            ListDetConcepto = (List<ConceptoPago>)Session["Conceptos"];
            DetConcepto ObjConceptoDet = new DetConcepto();
            if (cbi.Checked == true)
            {
                ObjConceptoDet.ClaveConcepto = grvConceptos.SelectedRow.Cells[0].Text;
                ListDetConcepto.Add(ObjConceptoDet);
            }
            else
            {
                ListDetConcepto.RemoveAt(grvConceptos.SelectedRow.RowIndex);
                Session["Conceptos"] = ListDetConcepto;
            }
        }

        protected void linkBttnVerRecibos_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvConceptos.SelectedIndex = row.RowIndex;
            string concepto = grvConceptos.SelectedRow.Cells[0].Text;
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP071" + "&dependencia=" + ddlDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&IdConcepto=" + concepto;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
    }
}