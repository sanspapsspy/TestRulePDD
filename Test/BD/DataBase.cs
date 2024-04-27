using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Data.SqlClient;

namespace Test.BD
{
    internal class DataBase
    {
        private const string connectionString = "Data Source=DESKTOP-QKDTUFV\\SQLEXPRESS;Initial Catalog = RulePDD2; Integrated Security = True; Encrypt=True;Trust Server Certificate=True;";
        private static int SendNonqueryReqest(String sqlExpression)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                return command.ExecuteNonQuery();
            }
        }
        public static bool LoginUser(UserClass user)
        {
            //принимает имя , пароль пользователя и даёт понять что пользователь существует. Входное - UserClass user. Идёт вызов метода
            string sqlExpression = $"SELECT * FROM Users WHERE Name = \'{user.Name}\' AND Password = \'{user.Password}\'";
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        count++;
                    }
                }
                reader.Close();
            }
            return count > 0;
        }
        public static bool RegisterUser(UserClass user)
        {
            string sqlExpression = $"Inser Users (Name, Password) VALUES ('{user.Name}','{user.Password}')";
            return SendNonqueryReqest(sqlExpression) == 1;
        }
        public static bool PushTestResult(BDClass bDClass)
        {
            string sqlExpression = $"Inser TestResult (UserID , Grade ,CorrectAnswer) VALUES ('{bDClass.UserID}','{bDClass.Grade}','{bDClass.CorrectAnswer}')";
            return SendNonqueryReqest(sqlExpression) == 1;
        }
    }
}

//Data Source=DESKTOP-QKDTUFV\SQLEXPRESS;Initial Catalog=RulePDD2;Integrated Security=True;Encrypt=True;Trust Server Certificate=True