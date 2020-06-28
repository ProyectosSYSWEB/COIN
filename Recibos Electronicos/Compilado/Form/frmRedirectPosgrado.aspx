﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRedirectPosgrado.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRedirectPosgrado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function RedirectSysPosgrado(Cve, Form) {
        $('#frmPosgrado').attr('src', 'https://sysweb.unach.mx/INGRESOS_MVC/Home/Index?WXI=' + Cve + '&Formulario=' + Form);
            $('#frmPosgrado').reload();
    }

    function RedirectIngMVC(Cve, Form) {
        //$(location).attr('href', 'https://sysweb.unach.mx/INGRESOS_MVC/Home/Index?WXI=' + Cve + '&Formulario=' + Form);
        window.location.href = 'https://sysweb.unach.mx/INGRESOS_MVC/Home/Index?WXI=' + Cve + '&Formulario=' + Form;

    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="text-right">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnRedirect" runat="server" Height="33px" ImageUrl="~/Imagenes/agrandar_imagen.png" OnClick="imgBttnRedirect_Click" Width="51px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <iframe id="frmPosgrado" style="width: 100%; height: 700px" frameborder="NO" name="frmPosgrado"></iframe>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>