<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication11.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="jumbotron" style="position: relative; float: left; height: 400px;">
          <div class="form-out">
               <div class="numUser">
                   <asp:TextBox ID="numUser" runat="server"  placeholder="Номер пользователя" ></asp:TextBox> 
               </div>
               <div class="numPC">
                   <asp:TextBox ID="numPC" runat="server" placeholder="Номер ПК"></asp:TextBox>
               </div>
               <div class="service">
                   <asp:DropDownList ID="service" runat="server" style="height: 51px; width: 100%; padding-left: 5px">
                       <asp:ListItem>Ремонт</asp:ListItem>
                       <asp:ListItem>Настройка</asp:ListItem>
                       <asp:ListItem>Диагностика</asp:ListItem>
                       <asp:ListItem>Чистка</asp:ListItem>
                   </asp:DropDownList>
               </div>
               <div class="description">
                       <asp:TextBox ID="description" runat="server" placeholder="Опишите проблему..." MaxLength="50" style="padding-left: 5px; width: 279px;"></asp:TextBox>
               </div>
               <div class="btn_send">
                    <%--set button--%>
                   <asp:Button ID="btn_send" runat="server" Text="Отправить" OnClick="btn_send_Click"/>
               </div>  
               <div class="lbl_setOrderError">
                   <%--set label--%>
                   <asp:Label ID="lbl_setOrderError" runat="server" Text="setError"></asp:Label>
               </div>            
          </div>
        </div>
        <div class="jumbotron getinfo">
            <div class="txt_setNumOrder">
                <asp:TextBox ID="txt_setNumOrder" runat="server" placeholder="Введите номер заявки..." style="padding-left: 5px;"></asp:TextBox>
            </div>
            <div class="orderInfo">
                <div class="setOrderinfo">
                    <div class="lbl_numPC">
                        <asp:Label ID="lbl_numPC" runat="server" Text="Номер ПК"></asp:Label>
                    </div>
                    <div class="lbl_data">
                        <asp:Label ID="lbl_data" runat="server" Text="Дата оформления"></asp:Label>
                    </div>
                    <div class="lbl_status">
                        <asp:Label ID="lbl_status" runat="server" Text="Статус"></asp:Label>
                    </div>                            
                </div>
                <div class="getOrderInfo">
                    <div class="lbl_getNumPc">
                        <asp:Label ID="lbl_getNumPc" runat="server" Text="Label" Visible="False"></asp:Label>
                    </div>
                    <div class="lbl_getData">
                        <asp:Label ID="lbl_getData" runat="server" Text="Label" Visible="False"></asp:Label>
                    </div>
                    <div class="lbl_getStatus">
                        <asp:Label ID="lbl_getStatus" runat="server" Text="Label" Visible="False"></asp:Label>
                    </div>                    
                </div>
            </div>
            <div class="btn_send check">
                <%--get button--%>
                   <asp:Button ID="btn_check" runat="server" Text="Проверить" OnClick="btn_check_Click"/> 
            </div>  
            <div class="lbl_getInfoError">
                <%--get label--%>
                <asp:Label ID="lbl_getInfoError" runat="server" Text="getError"></asp:Label>
            </div>

                         
        </div>


<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DepartmentITConnectionString %>" DeleteCommand="DELETE FROM [Orders] WHERE [id] = @id" InsertCommand="INSERT INTO [Orders] ([Employee], [EmplPPC], [Service], [Description], [RegistrationDate], [Status], [Master], [DeadlineDate]) VALUES (@Employee, @EmplPPC, @Service, @Description, @RegistrationDate, @Status, @Master, @DeadlineDate)" SelectCommand="SELECT * FROM [Orders]" UpdateCommand="UPDATE [Orders] SET [Employee] = @Employee, [EmplPPC] = @EmplPPC, [Service] = @Service, [Description] = @Description, [RegistrationDate] = @RegistrationDate, [Status] = @Status, [Master] = @Master, [DeadlineDate] = @DeadlineDate WHERE [id] = @id">
    <DeleteParameters>
        <asp:Parameter Name="id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Employee" Type="Int32" />
        <asp:Parameter Name="EmplPPC" Type="Int32" />
        <asp:Parameter Name="Service" Type="Int32" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter DbType="Date" Name="RegistrationDate" />
        <asp:Parameter Name="Status" Type="Int32" />
        <asp:Parameter Name="Master" Type="Int32" />
        <asp:Parameter DbType="Date" Name="DeadlineDate" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Employee" Type="Int32" />
        <asp:Parameter Name="EmplPPC" Type="Int32" />
        <asp:Parameter Name="Service" Type="Int32" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter DbType="Date" Name="RegistrationDate" />
        <asp:Parameter Name="Status" Type="Int32" />
        <asp:Parameter Name="Master" Type="Int32" />
        <asp:Parameter DbType="Date" Name="DeadlineDate" />
        <asp:Parameter Name="id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

</asp:Content>
