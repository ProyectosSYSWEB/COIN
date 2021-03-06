﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmAlumnos_Clientes.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmAlumnos_Clientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="~/EnviarCorreo.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Js/jsGeneral.js"> </script>



    <style type="text/css">
        .auto-style9 {
            width: 296px;
        }

        .auto-style11 {
            width: 252px;
        }

        .auto-style15 {
            width: 156px;
        }

        .auto-style18 {
            width: 146px;
        }

        .auto-style19 {
            width: 3572px;
        }
    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlPrincipal" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td class="auto-style15" align="left">
                                                    <asp:Label ID="lblNivel" runat="server" Text="Nivel de Estudio:"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged1" Width="100%">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style15">
                                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlDependencia" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" Width="100%">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style15">
                                                    <asp:Label ID="lblCarrera0" runat="server" Text="Carrera:"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlCarrera0" runat="server" AutoPostBack="true"
                                                                ClientIDMode="Predictable" TabIndex="5"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style15">
                                                    <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                        <asp:ListItem Value="T">Todos</asp:ListItem>
                                                        <asp:ListItem Value="A">Activo</asp:ListItem>
                                                        <asp:ListItem Value="C">Inactivos</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style15" align="left" valign="top">
                                                    <asp:Label ID="lblNivel0" runat="server" Text="Matricula/Nombre:"></asp:Label>
                                                </td>
                                                <td class="auto-style19" valign="top">
                                                    <asp:TextBox ID="txtBusqueda" runat="server" Width="98%"></asp:TextBox>
                                                </td>
                                                <td valign="top" align="right">
                                                    <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                                    &nbsp;</td>
                                                <td align="right" valign="top">
                                                    <asp:ImageButton ID="imgBttnNuevo0" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" ValidationGroup="Nuevo" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1" align="center" colspan="4">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image86" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="style1" colspan="4">
                                                    <asp:GridView ID="grvAlumnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grvAlumnos_PageIndexChanging" OnRowDeleting="grvAlumnos_RowDeleting" OnSelectedIndexChanging="grvAlumnos_SelectedIndexChanging" PageSize="15" Width="100%" EmptyDataText="No existen registros." ShowHeaderWhenEmpty="True" ShowFooter="True">
                                                        <Columns>
                                                            <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                            <asp:BoundField DataField="Nivel" HeaderText="Nivel">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                            <asp:BoundField DataField="DescCarrera" HeaderText="Carrera" />
                                                            <asp:BoundField DataField="Semestre" HeaderText="Semestre">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Grupo" HeaderText="Grupo">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# Bind("ImageStatusMatricula") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="IdPersona" HeaderText="Id" />
                                                            <asp:TemplateField HeaderText="ENVIAR NOTIFICACIÓN">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <FooterTemplate>
                                                                    <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                                                    &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                                                </FooterTemplate>
                                                                <HeaderTemplate>
                                                                    <asp:Button ID="bttnAgregar" runat="server" CssClass="btn btn-blue-grey" Font-Size="X-Small" OnClick="bttnAgregar_Click" Text="+" Visible="False" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" OnClick="imgBttnEditar_Click" />
                                                                    &nbsp;<asp:ImageButton ID="imgBttnCancelar" runat="server" CommandName="Delete" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/del.png" OnClientClick="return confirm('¿Desea eliminar el registro?');" />
                                                                </ItemTemplate>
                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle CssClass="enc" />
                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                        <SelectedRowStyle CssClass="sel" />
                                                        <HeaderStyle CssClass="enc" />
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                    <asp:HiddenField ID="hddnModal" runat="server" />
                                                    <asp:ModalPopupExtender ID="modalCorreo" runat="server" PopupControlID="pnlCorreo" TargetControlID="hddnModal">
                                                    </asp:ModalPopupExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style22" align="center" colspan="4">
                                                    <asp:Panel ID="pnlCorreo" runat="server" CssClass="TituloModalPopupMsg" Width="40%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="auto-style1" colspan="3">
                                                                    <div class="titulo_pop">
                                                                        Enviar Notificación
                                                                    </div>
                                                                    <div class="mensaje">
                                                                        <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Label ID="lblMensajeCorreo" runat="server" Font-Bold="True" Font-Size="16px"></asp:Label>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" valign="top" width="33%">
                                                                    <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td align="left" valign="top" width="67%">
                                                                    <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtCorreo0" runat="server" Width="90%"></asp:TextBox>
                                                                            <br />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCorreo" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="correo"></asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td align="left" valign="top" width="67%">
                                                                    <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="auto-style1" colspan="3">
                                                                    <asp:UpdateProgress ID="UpdateProgress11" runat="server" AssociatedUpdatePanelID="UpdatePanel37">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                    <asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="UpdatePanel38">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="Image89" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                    <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="bttnCorreo" runat="server" CssClass="btn btn-info" Height="40px" OnClick="bttnCorreo_Click" Text="Enviar" ValidationGroup="correo" />
                                                                            &nbsp;<asp:Button ID="bttnCancelarCorreo" runat="server" CssClass="btn btn-blue-grey" Height="40px" OnClick="bttnCancelarCorreo_Click" Text="Salir" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="33%">&nbsp;</td>
                                                                <td width="67%">&nbsp;</td>
                                                                <td width="67%">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="style22" colspan="4">
                                                    <div class="cuadro_botones">
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                                <ProgressTemplate>
                                    <asp:Image ID="Image87" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                        ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlDatos_Alumno" runat="server" Visible="False">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="auto-style18" align="left" valign="top">
                                                    <asp:Label ID="lblNivel_D" runat="server" Text="Nivel de Estudio:"></asp:Label>
                                                </td>
                                                <td class="style7" colspan="2" valign="top">
                                                    <asp:DropDownList ID="ddlNivel_D" runat="server" TabIndex="2" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_D_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlNivel_D" ErrorMessage="*Requerido" InitialValue="Z" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style18" align="left" valign="top">
                                                    <asp:Label ID="lblDependencia_D" runat="server" Text="Dependencia:"></asp:Label>
                                                </td>
                                                <td class="style7" colspan="2" valign="top">
                                                    <asp:DropDownList ID="ddlDependencia_D" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlDependencia_D_SelectedIndexChanged" TabIndex="3" Width="85%">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDependencia_D" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="00000" ValidationGroup="guardar">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style18" valign="top">
                                                    <asp:Label ID="lblCarrera" runat="server" Text="Carrera:"></asp:Label>
                                                </td>
                                                <td class="style7" colspan="2" valign="top">
                                                    <asp:DropDownList ID="ddlCarrera" runat="server" AutoPostBack="true" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged" TabIndex="4" Width="85%">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style18" align="left" valign="top">
                                                    <asp:Label ID="lblOtraCarrera" runat="server" Text="Especificar:" Visible="False"></asp:Label>
                                                </td>
                                                <td class="style7" colspan="2" valign="top">
                                                    <asp:TextBox ID="txtCarrera" runat="server" CssClass="box" Visible="false" Width="85%" TabIndex="5" AutoPostBack="True"></asp:TextBox>
                                                    <asp:TextBoxWatermarkExtender ID="txtCarrera_TextBoxWatermarkExtender" runat="server" TargetControlID="txtCarrera" WatermarkCssClass="watermarked" WatermarkText="Escriba el nombre de la carrera " />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style18" valign="top">
                                                    <asp:Label ID="lblMatricula" runat="server" Text="Matricula:"></asp:Label>
                                                </td>
                                                <td class="style7" colspan="2" valign="top">
                                                    <asp:TextBox ID="txtMatricula" runat="server" CssClass="box" TabIndex="6"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style18" align="left" valign="top">
                                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                                                </td>
                                                <td class="style6" colspan="2" valign="top">
                                                    <asp:TextBox ID="txtNombre" runat="server" Width="85%" CssClass="box" TabIndex="7"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNombre"
                                                        CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar">                                        
                                                    </asp:RequiredFieldValidator>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style18" valign="top">
                                                    <asp:Label ID="lblPaterno" runat="server" Text="Apellido Paterno:"></asp:Label>
                                                </td>
                                                <td class="style6" colspan="2" valign="top">
                                                    <asp:TextBox ID="txtPaterno" runat="server" TabIndex="8" Width="85%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPaterno" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style18" valign="top">
                                                    <asp:Label ID="lblMaterno" runat="server" Text="Apellido Materno:"></asp:Label>
                                                </td>
                                                <td class="style6" colspan="2" valign="top">
                                                    <asp:TextBox ID="txtMaterno" runat="server" TabIndex="9" Width="85%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style18" align="left" valign="top">
                                                    <asp:Label ID="lblSemestre" runat="server" Text="Semestre:"></asp:Label>
                                                </td>
                                                <td valign="top" colspan="2">
                                                    <asp:TextBox ID="txtSemestre" runat="server" Width="100px" CssClass="box" TabIndex="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtSemestre"
                                                        CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar">                                        
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSemestre"
                                                        CssClass="MsjError" ErrorMessage="* Solo Números" ValidationExpression="\d+"
                                                        ValidationGroup="guardar" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    &nbsp;&nbsp;<asp:Label ID="lblGrupo" runat="server" Text="Grupo:"></asp:Label>
                                                    <asp:TextBox ID="txtGrupo" runat="server" CssClass="box" TabIndex="11" Width="50px"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style18" valign="top">
                                                    <asp:Label ID="lblGenero" runat="server" Text="Genero:"></asp:Label>
                                                </td>
                                                <td colspan="2" valign="top">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="auto-style11" valign="top">
                                                                <asp:RadioButtonList ID="rdoGenero" runat="server" RepeatDirection="Horizontal" TabIndex="12">
                                                                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                                                                    <asp:ListItem Selected="True" Value="M">Masculino</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rdoGenero" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator></td>
                                                            <td valign="top">
                                                                <asp:Label ID="lblActivo" runat="server" Text="Activo:"></asp:Label>
                                                                <asp:CheckBox ID="chkActivo" runat="server" Checked="true" TabIndex="13" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style18" valign="top">Correo: </td>
                                                <td class="auto-style9" valign="top">
                                                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="box" TabIndex="14" Width="100%"></asp:TextBox>
                                                </td>
                                                <td class="style8" valign="top">&nbsp; &nbsp; </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style18" align="left">&nbsp;
                                                </td>
                                                <td class="auto-style9" valign="top">&nbsp;
                                                </td>
                                                <td class="style8" valign="top">&nbsp; &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="style5" colspan="3">
                                                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-info" Height="45px" Text="GUARDAR" OnClick="btnGuardar_Click" ValidationGroup="guardar" TabIndex="15" />
                                                    &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" Height="45px"
                                                        Text="CANCELAR" OnClick="btnCancelar_Click" TabIndex="16" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">&nbsp; &nbsp; &nbsp; &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">

                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel3_">
                                <ProgressTemplate>
                                    <asp:Image ID="Image88" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                        ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>

                            <asp:UpdatePanel ID="UpdatePanel3_" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-mdb-color"
                                        OnClick="btnRegresar_Click" Visible="False" />
                                    <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor"
                                        style="height: 500px" width="100%"></iframe>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
