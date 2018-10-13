using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class _Default : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DepartmentITConnectionString"].ConnectionString);

        private string password;
        public string Password {
            get { return password ; }
            set { this.password = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //con.Open(); // Открываем подключение
        }

        // Шифрование пароля
        public string Encryption(string hash)
        {
            Password = tb_password.Text;

            byte[] data = UTF8Encoding.UTF8.GetBytes(Password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    Password = Convert.ToBase64String(result, 0, result.Length);

                    return Password;
                }
            }
        }

        // Передача данных пользователя
        public void UserData()
        {            
            con.Open(); // Открываем соеденение

            SqlCommand cmd_getNum = new SqlCommand("SELECT Accounts.RegNum, EmployeesPC.RegNumberPC FROM Accounts JOIN Employees ON Employees.RegNum = Accounts.RegNum LEFT JOIN EmployeesPC ON EmployeesPC.RegNumEmpl = Employees.RegNum WHERE UserName = '" + tb_login.Text + "' ", con);
            IDataReader reader_num = cmd_getNum.ExecuteReader();

            while (reader_num.Read())
            {
                string userNumber = Convert.ToString(reader_num.GetInt32(0)); // получить номер пользователя
                //string pcNumber = Convert.ToString(reader_num.GetInt32(1)); // получить номер pc
                Response.Redirect(String.Format("Contact.aspx?userNumber={0}", userNumber));
            }

            con.Close(); // Закрывает соеденение
        }

        // Авторизация
        public void Authorization()
        {
            con.Open(); // Открывает соеденение

            SqlCommand cmd_auth = new SqlCommand("SELECT * FROM Accounts WHERE [username] = '" + tb_login.Text + "' and [password] = '" + Password + "'", con);
            IDataReader reader_auth = cmd_auth.ExecuteReader();

            int count = 0;
            while (reader_auth.Read())
            {
                count++;
            }

            con.Close(); // Закрывает соеденение

            // Если данные введены правильно и пользователь существует
            if (count == 1)
            {
                //UserData(); получить данные пользователя
                Response.Redirect("/Contact"); // Переход на страницу
            }

            // Если данные введены не корректно или пользователя не существует
            else
            {
                lbl_regError.Text = "Data is not correct";
            }
        }

        // Кнопка
        protected void Send_Click(object sender, EventArgs e)
        {
            Encryption("Dep@rtmentIt"); // Шифрование введенного пароля для последующего сравнения, принимает параметр значения хеша
            Authorization();
        }
    }
}