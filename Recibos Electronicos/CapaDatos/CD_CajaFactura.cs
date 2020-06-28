﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;
using System.Web.UI.WebControls;
using System.IO;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_CajaFactura
    {
        public void FacturaClienteConsultaGrid(CajaFactura ObjCjaFactura, ref List<CajaFactura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_Matricula", "P_Dependencia" };
                String[] Valores = { ObjCjaFactura.FACT_MATRICULA, ObjCjaFactura.FACT_DEPENDENCIA };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas_Cliente", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjCjaFactura = new CajaFactura();
                    ObjCjaFactura.ID_FACT = Convert.ToString(dr.GetValue(0)); //Este obtiene el Id de la Tabla Factura o Factura_Caja
                    ObjCjaFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(1));
                    ObjCjaFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(6));
                    ObjCjaFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(2));
                    ObjCjaFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(3));
                    ObjCjaFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(4));
                    ObjCjaFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(5));
                    ObjCjaFactura.Avance = Convert.ToInt32(dr.GetValue(7));
                    //ObjCjaFactura.IdCajaFact = Convert.ToInt32(dr.GetValue(9));
                    ObjCjaFactura.FACT_BANCO = Convert.ToString(dr.GetValue(8));
                    ObjCjaFactura.FACT_CONFIRMADO = Convert.ToString(dr.GetValue(9));
                    ObjCjaFactura.FACT_RECEPTOR_CORREO = Convert.ToString(dr.GetValue(10));
                    ObjCjaFactura.ID_FICHA_BANCARIA = Convert.ToInt32(dr.GetValue(11));
                    ObjCjaFactura.FACT_STATUS_CAJA = Convert.ToString(dr.GetValue(12));
                    ObjCjaFactura.FACT_RECEPTOR_STATUS = Convert.ToString(dr.GetValue(13));
                    ObjCjaFactura.FACT_TIPO = Convert.ToString(dr.GetValue(14));
                    ObjCjaFactura.FACT_CLIENTE = Convert.ToString(dr.GetValue(15));
                    List.Add(ObjCjaFactura);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }
        public void FacturaCajaConsultaGrid(Usuario ObjUsuario, ref CajaFactura ObjCjaFactura, String Dependencia, String FechaInicial, String FechaFinal, string Referencia, string Status, string Confirmados, ref List<CajaFactura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_usuario", "p_dependencia", "p_fecha_inicial", "p_fecha_final", "p_referencia", "p_status", "p_confirmados" };
                String[] Valores = { ObjUsuario.Usu_Nombre, Dependencia, FechaInicial, FechaFinal, Referencia, Status, Confirmados };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas_Caja", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjCjaFactura = new CajaFactura();
                    ObjCjaFactura.ID_FACT = Convert.ToString(dr.GetValue(0)); //Este obtiene el Id de la Tabla Factura o Factura_Caja
                    ObjCjaFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(1));
                    ObjCjaFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(6));
                    ObjCjaFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(2));
                    ObjCjaFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(3));
                    ObjCjaFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(4));
                    ObjCjaFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(5));
                    ObjCjaFactura.Avance = Convert.ToInt32(dr.GetValue(7));
                    //ObjCjaFactura.IdCajaFact = Convert.ToInt32(dr.GetValue(9));
                    ObjCjaFactura.FACT_BANCO = Convert.ToString(dr.GetValue(8));
                    ObjCjaFactura.FACT_CONFIRMADO = Convert.ToString(dr.GetValue(9));
                    ObjCjaFactura.FACT_RECEPTOR_CORREO = Convert.ToString(dr.GetValue(10));
                    ObjCjaFactura.ID_FICHA_BANCARIA = Convert.ToInt32(dr.GetValue(11));
                    ObjCjaFactura.FACT_STATUS_CAJA = Convert.ToString(dr.GetValue(12));
                    ObjCjaFactura.FACT_RECEPTOR_STATUS = Convert.ToString(dr.GetValue(13));
                    ObjCjaFactura.Ruta = (ObjCjaFactura.FACT_RECEPTOR_STATUS == "R") ? "../Imagenes/desactivado.PNG" : "";
                    ObjCjaFactura.FACT_TIPO = Convert.ToString(dr.GetValue(14));
                    ObjCjaFactura.FACT_CLIENTE = Convert.ToString(dr.GetValue(15));
                    //ObjCjaFactura.Ruta = Convert.ToString(dr.GetValue(16));
                    List.Add(ObjCjaFactura);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }
        public void FacturaDoctosConsultaGrid(Factura ObjFactura, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_Id_Factura" };
                String[] Valores = { ObjFactura.ID_FACT };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Doctos_Facturas", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.FACT_TIPO = Convert.ToString(dr.GetValue(0)); //Este obtiene el Id de la Tabla Factura o Factura_Caja
                    ObjFactura.RUTA_ADJUNTO = Convert.ToString(dr.GetValue(1));
                    ObjFactura.OFICIO = Convert.ToString(dr.GetValue(2));
                    List.Add(ObjFactura);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }
        public void FacturaCajaEfectivoConsultaGrid(Usuario ObjUsuario, ref CajaFactura ObjCjaFactura, String Dependencia, String FechaInicial, String FechaFinal, string Referencia, string Status, string Confirmados, string Tipo, ref List<CajaFactura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_usuario", "p_dependencia", "p_fecha_inicial", "p_fecha_final", "p_referencia", "p_status", "p_confirmados", "p_tipo" };
                String[] Valores = { ObjUsuario.Usu_Nombre, Dependencia, FechaInicial, FechaFinal, Referencia, Status, Confirmados, Tipo };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas_Efec_Caja", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjCjaFactura = new CajaFactura();
                    ObjCjaFactura.ID_FACT = Convert.ToString(dr.GetValue(0)); //Este obtiene el Id de la Tabla Factura o Factura_Caja
                    ObjCjaFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(1));
                    ObjCjaFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(2));
                    ObjCjaFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(3));
                    ObjCjaFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(4));
                    ObjCjaFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(5));
                    ObjCjaFactura.Avance = Convert.ToInt32(dr.GetValue(7));
                    //ObjCjaFactura.IdCajaFact = Convert.ToInt32(dr.GetValue(9));                    
                    ObjCjaFactura.FACT_CONFIRMADO = Convert.ToString(dr.GetValue(9));
                    ObjCjaFactura.FACT_RECEPTOR_CORREO = Convert.ToString(dr.GetValue(10));
                    ObjCjaFactura.FACT_STATUS_CAJA = Convert.ToString(dr.GetValue(12));
                    ObjCjaFactura.FACT_RECEPTOR_STATUS = Convert.ToString(dr.GetValue(13));
                    ObjCjaFactura.Ruta = (ObjCjaFactura.FACT_RECEPTOR_STATUS == "R") ? "../Imagenes/desactivado.PNG" : "";
                    ObjCjaFactura.FACT_TIPO = Convert.ToString(dr.GetValue(14));
                    ObjCjaFactura.FACT_FECHA_CAPTURA = Convert.ToString(dr.GetValue(15));
                    ObjCjaFactura.FACT_DIAS_EMISION = Convert.ToInt32(dr.GetValue(16));
                    List.Add(ObjCjaFactura);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }
        public void FacturaCajaEfectivoBorrar(CajaFactura ObjCjaFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_FACTURA_EFEC"
                                      };
                object[] Valores = { ObjCjaFactura.IdCajaFact };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_FACTURA_CAJA_EFECTIVO", ref Verificador, Parametros, Valores, ParametrosOut);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        public void FacturaCajaBorrar(Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_FACTURA", "P_TIPO"
                                      };
                object[] Valores = { ObjFactura.ID_FACT, ObjFactura.FACT_TIPO };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_FACTURA_CAJA", ref Verificador, Parametros, Valores, ParametrosOut);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        public void FacturaCajaAgregar(string Usuario, ref List<CajaFactura> Archivos, Factura objFactura, string RutaServ, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < Archivos.Count; i++)
                {
                    if (Archivos[i].Ruta != null)
                    {
                        FileStream FS = new FileStream(RutaServ + Archivos[i].NombreArchivo, FileMode.Open, FileAccess.Read);
                        Archivos[i].ArchivoBlob = new byte[FS.Length];
                        string ext = Path.GetExtension(Archivos[i].NombreArchivo);
                        FS.Read(Archivos[i].ArchivoBlob, 0, System.Convert.ToInt32(FS.Length));
                        FS.Close();
                        cmm = CDDatos.GenerarOracleCommand_Imagen("INS_FACTURA_CAJA", objFactura, Usuario, Archivos[i].ArchivoBlob, Archivos[i].Fecha_Fact_Cja, Archivos[i].Folio_Fact_Cja, Archivos[i].ExtensionArchivo, objFactura.FACT_TIPO, Archivos[i].Ruta, ref Verificador);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }
        public void FacturaCajaAgregar(string Usuario, ref List<CajaFactura> Archivos, int IdFactura, string RutaServ, string Tipo, ref string Verificador)
        {
            for (int i = 0; i < Archivos.Count; i++)
            {
                CD_Datos CDDatos = new CD_Datos();
                OracleCommand OracleCmd = null;

                try
                {

                    if (Archivos[i].Ruta != null)
                    {
                        string[] Parametros = { "P_ID_FACTURA",
                                        "P_TIPO",
                                        "P_USUARIO",
                                        "P_FECHA_FACT",
                                        "P_FOLIO_FACT",
                                        "P_EXTENSION",
                                        "P_RUTA"
                                      };
                        string[] ParametrosOut = { "P_BANDERA" };


                        object[] Valores = {
                                        IdFactura,
                                        Tipo,
                                        Usuario,
                                        Archivos[i].Fecha_Fact_Cja,
                                        Archivos[i].Folio_Fact_Cja,
                                        Archivos[i].ExtensionArchivo,
                                        Archivos[i].Ruta
                                       };
                        OracleCmd = CDDatos.GenerarOracleCommand("INS_FACTURA_CAJA_GRAL", ref Verificador, Parametros, Valores, ParametrosOut);
                        string OrigenArchivo = RutaServ + Archivos[i].NombreArchivo; // + Archivos[i].ExtensionArchivo;
                        string DestinoArchivo;
                        DestinoArchivo = /*IdFactura + */RutaServ.Replace("ArchivosFacturasTemp", "ArchivosFacturas") + Archivos[i].Folio_Fact_Cja + Archivos[i].ExtensionArchivo;
                        if (System.IO.File.Exists(OrigenArchivo))
                        {
                            System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                            System.IO.File.Delete(OrigenArchivo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    CDDatos.LimpiarOracleCommand(ref OracleCmd);
                }
            }
        }
        public void ConsultarPdfXmlFactura1(ref CajaFactura ObjCjaFactura, string Tipo, ref List<CajaFactura> List)
        {
            try
            {
                OracleDataReader dr = null;
                CD_Datos CDDatos = new CD_Datos();
                string SP = "";
                string Ruta = "";
                string Archivo = string.Empty;
                string IdFact;
                string[] Parametros = { "P_Id_Fact", "P_TIPO" };
                object[] Valores = { ObjCjaFactura.ID_FACT, Tipo };

                Ruta = AppDomain.CurrentDomain.BaseDirectory + "/Facturas/PDF/";
                IdFact = ObjCjaFactura.ID_FACT;
                SP = "pkg_felectronica.Obt_Pdf_Xml_Factura";
                OracleCommand cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);
                while (dr.Read())
                {

                    ObjCjaFactura = new CajaFactura();
                    Archivo = "" + dr.GetValue(3) + dr.GetValue(5);
                    Archivo = System.IO.Path.Combine(Ruta, Archivo);

                    if (System.IO.File.Exists(Archivo))
                        System.IO.File.Delete(Archivo);


                    if (dr[4] != DBNull.Value)
                    {
                        ObjCjaFactura.ArchivoBlob = (byte[])dr[4];
                        FileStream FS = new FileStream(Ruta + dr.GetValue(3) + dr.GetValue(5), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        FS.Write(ObjCjaFactura.ArchivoBlob, 0, ObjCjaFactura.ArchivoBlob.Length);
                        FS.Close();
                        FS = null;
                    }


                    ObjCjaFactura.Ruta = "../Facturas/PDF/" + dr.GetValue(3) + dr.GetValue(5); //Ruta + dr.GetValue(3) + dr.GetValue(5);
                    ObjCjaFactura.ID_FACT = IdFact;
                    ObjCjaFactura.Fecha_Fact_Cja = Convert.ToString(dr.GetValue(2));
                    ObjCjaFactura.Folio_Fact_Cja = Convert.ToString(dr.GetValue(3));
                    ObjCjaFactura.NombreArchivo = Convert.ToString(dr.GetValue(3)) + Convert.ToString(dr.GetValue(5));
                    ObjCjaFactura.ExtensionArchivo = Convert.ToString(dr.GetValue(5));
                    List.Add(ObjCjaFactura);
                }
                CDDatos.LimpiarOracleCommand(ref cmm);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarPdfXmlFactura3(ref CajaFactura ObjCjaFactura, string Tipo, ref List<CajaFactura> List)
        {
            try
            {
                OracleDataReader dr = null;
                CD_Datos CDDatos = new CD_Datos();
                string SP = "";
                string Ruta = "";
                string Archivo = string.Empty;
                string IdFact;
                string[] Parametros = { "P_Id_Fact", "P_TIPO" };
                object[] Valores = { ObjCjaFactura.ID_FACT, Tipo };

                Ruta = AppDomain.CurrentDomain.BaseDirectory + "/ArchivosFacturas/";
                IdFact = ObjCjaFactura.ID_FACT;
                SP = "pkg_felectronica.Obt_Pdf_Xml_Factura";
                OracleCommand cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);
                while (dr.Read())
                {

                    ObjCjaFactura = new CajaFactura();
                    ObjCjaFactura.Ruta = "../ArchivosFacturasTemp/" + dr.GetValue(3) + dr.GetValue(5); //Ruta + dr.GetValue(3) + dr.GetValue(5);
                    ObjCjaFactura.ID_FACT = IdFact;
                    ObjCjaFactura.Fecha_Fact_Cja = Convert.ToString(dr.GetValue(2));
                    ObjCjaFactura.Folio_Fact_Cja = Convert.ToString(dr.GetValue(3));
                    ObjCjaFactura.NombreArchivo = Convert.ToString(dr.GetValue(3)) + Convert.ToString(dr.GetValue(5));
                    ObjCjaFactura.ExtensionArchivo = Convert.ToString(dr.GetValue(5));
                    List.Add(ObjCjaFactura);

                    string OrigenArchivo = Ruta + dr.GetValue(3) + dr.GetValue(5);
                    string DestinoArchivo;
                    DestinoArchivo = Ruta.Replace("ArchivosFacturas", "ArchivosFacturasTemp") + dr.GetValue(3) + dr.GetValue(5);
                    if (System.IO.File.Exists(OrigenArchivo))
                    {
                        System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                        System.IO.File.Delete(OrigenArchivo);
                    }

                }
                CDDatos.LimpiarOracleCommand(ref cmm);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarPdfXmlFactura(ref CajaFactura ObjCjaFactura, string Tipo, ref List<CajaFactura> List)
        {
            try
            {
                OracleDataReader dr = null;
                CD_Datos CDDatos = new CD_Datos();
                string SP = "";
                string Ruta = "";
                string Archivo = string.Empty;
                string IdFact;
                string[] Parametros = { "P_Id_Factura", "P_Tipo" };
                object[] Valores = { ObjCjaFactura.ID_FACT, Tipo };

                Ruta = AppDomain.CurrentDomain.BaseDirectory + "/ArchivosFacturas/";
                IdFact = ObjCjaFactura.ID_FACT;
                SP = "pkg_felectronica_2016.Obt_Combo_Facturas_Cja";
                OracleCommand cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);
                while (dr.Read())
                {

                    ObjCjaFactura = new CajaFactura();
                    ObjCjaFactura.Fecha_Fact_Cja = Convert.ToString(dr.GetValue(3));
                    ObjCjaFactura.Folio_Fact_Cja = Convert.ToString(dr.GetValue(2));
                    ObjCjaFactura.Ruta = "../ArchivosFacturas/" + dr.GetValue(0) ; //Ruta + dr.GetValue(3) + dr.GetValue(5);
                    ObjCjaFactura.NombreArchivo = Convert.ToString(dr.GetValue(0));
                    ObjCjaFactura.ExtensionArchivo = Convert.ToString(dr.GetValue(4));
                    List.Add(ObjCjaFactura);
                }
                CDDatos.LimpiarOracleCommand(ref cmm);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}