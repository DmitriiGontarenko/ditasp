using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication11
{
    // TODO: Hide 'Error' label
    // TODO: make refactoring
    // TODO: авторизация пользователя

    public partial class Contact : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DepartmentITConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //con.Open();

            //lbl_getInfoError.Text = Request.QueryString["userNumber"]; // номер пользователя
        }

        // отравить заявку
        public void SendOrder() 
        {
            con.Open();

            int num_service = 0;

            switch (service.SelectedIndex) // DropDownList
            {
                case 0: // Fix
                    num_service = 1;
                    break;
                case 1: // Tuning
                    num_service = 2;
                    break;
                case 2: // Diagnostic
                    num_service = 3;
                    break;
                case 3: // Clear
                    num_service = 4;
                    break;
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO [Orders] (Employee, EmplPPC, Service, Description) VALUES ('" + numUser.Text + "', '" + numPC.Text + "', '" + num_service + "', '" + description.Text + "')", con);
            cmd.ExecuteNonQuery();

            con.Close();     

            GetOrderId(); // получить номер заявки

            // Очитска полей ввода после отправки
            numUser.Text = null;
            numPC.Text = null;
            service.SelectedIndex = 0;
            description.Text = null;
        }

        // получить номер заявки, вызывается в SendOrder
        public void GetOrderId()
        {
            con.Open();

            DateTime get_date = DateTime.Now;

            SqlCommand cmd_2 = new SqlCommand("SELECT Orders.id FROM Orders WHERE Employee = '100' AND RegistrationDate = '" + get_date + "' AND Description = '" + description.Text + "' ", con);

            IDataReader reader = cmd_2.ExecuteReader();

            while (reader.Read())
            {
                lbl_setOrderError.Text = "Номер вашей заявки: " + Convert.ToString(reader.GetInt32(0));
            }

            con.Close();
        }

        // получить информацию о заявке
        public void GetOrderInfo()
        {
            con.Open();

            int checkOrder = 0;

            SqlCommand cmd = new SqlCommand("SELECT Orders.EmplPPC, Orders.RegistrationDate, StatusOrders.Name as Status FROM Orders JOIN StatusOrders ON Orders.Status = StatusOrders.id WHERE Orders.id = '" + txt_setNumOrder.Text + "' ", con);

            IDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lbl_getNumPc.Text = Convert.ToString(reader.GetInt32(0));
                lbl_getData.Text = Convert.ToString(reader.GetDateTime(1)).Remove(10);
                lbl_getStatus.Text = reader.GetString(2);

                checkOrder++;
            }

            if (checkOrder == 1)
            {
                lbl_getNumPc.Visible = true;
                lbl_getData.Visible = true;
                lbl_getStatus.Visible = true;

                lbl_getInfoError.Visible = false;
            }
            else
            {
                lbl_getNumPc.Visible = false;
                lbl_getData.Visible = false;
                lbl_getStatus.Visible = false;

                lbl_getInfoError.Visible = true;
                lbl_getInfoError.Text = "Заявка не найдена";
            }

            con.Close();
        }

        // Кнопка "Отправить"
        protected void btn_send_Click(object sender, EventArgs e)
        {

            SendOrder(); // отправить заявку

            con.Close(); // закрыть соеденение


        }

        // Кнопка "Проверить"
        protected void btn_check_Click(object sender, EventArgs e)
        {
            GetOrderInfo(); // получить данные о заявке
        }
    }
}