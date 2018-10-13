<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication11._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
          <div class="form-in">
               <div class="log">
                   <asp:TextBox ID="tb_login" runat="server"  placeholder="Логин" ></asp:TextBox> 
               </div>
               <div class="pass">
                   <asp:TextBox ID="tb_password" runat="server" placeholder="Пароль" TextMode="Password"></asp:TextBox>
               </div>
               <div class="send">
                   <asp:Button ID="btn_Send" runat="server" Text="Войти" OnClick="Send_Click" /> 
               </div>
               <div class="regError">
                   <asp:Label ID="lbl_regError" runat="server" Text="regError"></asp:Label>
               </div>
          </div>
    </div>
</asp:Content> 

<%--Переход на страницу--%>
<%--PostBackUrl="~/Contact.aspx"--%>