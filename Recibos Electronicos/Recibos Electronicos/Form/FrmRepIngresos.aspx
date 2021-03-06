﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRepIngresos.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmRepIngresos" %>
<%@ Register assembly="CapaNegocio" namespace="CapaNegocio" tagprefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 156px;
        }
        .auto-style3 {
            width: 276px;
        }
        .auto-style4 {
            width: 125px;
        }
        .auto-style5 {
            width: 275px;
        }
        .auto-style6 {
            width: 156px;
            height: 18px;
        }
        .auto-style7 {
            width: 276px;
            height: 18px;
        }
        .auto-style8 {
            width: 275px;
            height: 18px;
        }
        .auto-style9 {
            height: 18px;
        }
        .auto-style10 {
            width: 1008px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>
                <table style="width: 100%;" width="100%">
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                                                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                                                </td>
                        <td colspan="3">
                                                                        <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                                                        </asp:DropDownList>
                                                                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                                                                    <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblCiclo" runat="server" Text="Ciclo Escolar:" Visible="False"></asp:Label>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                        <td class="auto-style3">         
                            <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                <ContentTemplate>
                                    <customControl:GroupDropDownList ID="ddlCiclo" runat="server" AutoPostBack="True" Visible="False" Width="100%">
                                    </customControl:GroupDropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
            </td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>             
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                                                                    <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                                                </td>
                        <td class="auto-style3">         
                            <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                <ContentTemplate>
                                                                                   <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Factura_Ini" PopupButtonID="imgCalendarioIni" />
                                                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />                                                        
                                </ContentTemplate>
                            </asp:UpdatePanel>
            </td>
                        <td class="auto-style5"><table width="100%">
                            <tr>
                                <td class="auto-style4">
                                                                                                        <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:"></asp:Label>

                                </td>
                                <td>
                                           <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                               <ContentTemplate>
                                                                                              <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" style="margin-left: 0px" Width="95px"></asp:TextBox>
                                                                     <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                                                     <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />

                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                </td>
                            </tr>
                                                </table>
                                                                </td>
                        <td>             
            </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                                                    <asp:Label ID="lblNivel" runat="server" Text="Nivel:"></asp:Label>
                                                </td>
                        <td class="auto-style3">
                                                                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDLNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNivel_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                        <td class="auto-style5"><table width="100%">
                            <tr>
                                <td class="auto-style4">
                                                                                                        <asp:Label ID="lblOrdenar" runat="server" Text="Ordenar por:"></asp:Label>

                                </td>
                                <td>
                                           <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                               <ContentTemplate>
                                                                                              <asp:DropDownList ID="ddlOrden" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrden_SelectedIndexChanged">
                                                                                                  <asp:ListItem Value="1">Clave</asp:ListItem>
                                                                                                  <asp:ListItem Value="2">Descripción</asp:ListItem>
                                                                                              </asp:DropDownList>

                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                </td>
                            </tr>
                                                </table>
                                                                </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2" valign="top">
                                            <asp:Label ID="lblBuscar" runat="server" Text="Buscar:"></asp:Label>
                                                </td>
                        <td colspan="3" valign="top">
                                                                                                                            <table style="width:100%;">
                                                                                                                                <tr valign="top">
                                                                                                                                    <td class="auto-style10">
                                                                                                                                        <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                                                                                                                            <ContentTemplate>
                                                                                                                                                <asp:TextBox ID="txtBuscar" runat="server" Width="100%" PlaceHolder="Por Clave ó Descripción"></asp:TextBox>
                                                                                                                                            </ContentTemplate>
                                                                                                                                        </asp:UpdatePanel>
                                                                                                                                    </td>
                                                                                                                                    <td>
                                                                                                                                        <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                                                                                                            <ContentTemplate>
                                                                                                                                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                                                                                                                    <ContentTemplate>
                                                                                                                                                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                                                                                                                                    </ContentTemplate>
                                                                                                                                                </asp:UpdatePanel>
                                                                                                                                            </ContentTemplate>
                                                                                                                                        </asp:UpdatePanel>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" valign="top">
                                                                <asp:Label ID="lblConceptos" runat="server" Text="Conceptos:"></asp:Label>
                                                </td>
                        <td colspan="3" valign="top">
                                                                                                                            <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                                                                                                                <ContentTemplate>
                                                                                                                                    <div id="divGrid" runat="server" style="border-style: none none solid none; overflow: auto; height: 230px; border-bottom-color: #D9D9D9; border-bottom-width: 1px;">
                                                                                                                                    <asp:GridView ID="grvConceptos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnPageIndexChanging="grvConceptos_PageIndexChanging" Width="100%" DataKeyNames="ClaveConcepto">
                                                                                                                                        <Columns>
                                                                                                                                            <asp:BoundField DataField="ClaveConcepto" HeaderText="Cve.">
                                                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                                                            </asp:BoundField>
                                                                                                                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                                                                <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                                                                                            </asp:BoundField>
                                                                                                                                            <asp:TemplateField>
                                                                                                                                                <HeaderTemplate>
                                                                                                                                                    <asp:CheckBox ID="chkTodosConc" runat="server" OnCheckedChanged="chkTodosConc_CheckedChanged" AutoPostBack="True" />
                                                                                                                                                </HeaderTemplate>
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:CheckBox ID="chkConcepto" runat="server" Checked='<%# Bind("Habilita") %>' />
                                                                                                                                                </ItemTemplate>
                                                                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                                                                            </asp:TemplateField>
                                                                                                                                        </Columns>
                                                                                                                                        <FooterStyle CssClass="enc" />
                                                                                                                                        <HeaderStyle CssClass="enc" />
                                                                                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                                                                        <SelectedRowStyle CssClass="sel" />
                                                                                                                                    </asp:GridView>
                                                                                                                                        </div>
                                                                                                                                </ContentTemplate>
                                                                                                                            </asp:UpdatePanel>
                                                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9" align="right">
                            <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                    &nbsp;<asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
