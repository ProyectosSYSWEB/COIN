﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRedirectPosgrado.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRedirectPosgrado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function RedirectSysPosgrado(Cve, Form) {


            var ruta = 'https://sysweb.unach.mx/INGRESOS_MVC/Home/Index?WXI=' + Cve + '&Formulario=' + Form;

            //window.open(ruta, "frmPosgrado", "toolbar=yes", "location=no", "menubar=yes", "resizable=yes");

            $('#frmPosgrado').attr('src', ruta);
            //window.open(ruta, '_blank');
            $('#frmPosgrado').load();
        }

        function RedirectIngMVC(Cve, Form) {
            //$(location).attr('href', 'https://sysweb.unach.mx/INGRESOS_MVC/Home/Index?WXI=' + Cve + '&Formulario=' + Form);
            window.location.href = 'https://sysweb.unach.mx/INGRESOS_MVC/Home/Index?WXI=' + Cve + '&Formulario=' + Form;

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
  
       <%-- <div class="row">
            <div class="col text-right">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnRedirect" runat="server" Height="33px" ImageUrl="~/Imagenes/agrandar_imagen.png" OnClick="imgBttnRedirect_Click" Width="51px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>--%>
    
        <div class="row">
            <div class="col">
  <%--<iframe id="frmPosgrado" runat="server" scrolling="auto" src=""  style="width: 100%; height: 1400px" ></iframe>--%>


                <iframe id="frmPosgrado" style="width: 100%; height: 1400px" frameborder="NO" name="frmPosgrado"></iframe>

            </div>
        </div>
    </div>
</asp:Content>
