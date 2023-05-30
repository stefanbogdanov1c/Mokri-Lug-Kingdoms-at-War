using MySql.Data.MySqlClient;
using System;
using TMPro;
using UnityEngine;

public class Write : MonoBehaviour
{

    public TMP_InputField username;
    private string connectionString;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    string query;
    string check_user;
    public void sendInfo()
    {
        try
        {
            connection();

            if (username.text == "")
            {
                username.text = "Guest";
            }

            check_user = "SELECT COUNT(*) FROM users WHERE userName = '" + username.text.ToLower() + "';";

            MS_Command = new MySqlCommand(check_user, MS_Connection);

            MS_Command.ExecuteScalar();

            var row_number = MS_Command.ExecuteScalar();
            Debug.Log(Convert.ToInt32(row_number));
            Debug.Log(row_number.GetType());

            if (Convert.ToInt32(row_number) < 1)
            {

                query = "INSERT INTO users ( userName ) VALUES ('" + username.text.ToLower() + "');";


                MS_Command = new MySqlCommand(query, MS_Connection);

                MS_Command.ExecuteNonQuery();

                PlayerPrefs.SetString("Username", username.text.ToLower());

                MS_Connection.Close();
            }
            else
            {
                return;
            }



        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    private void connection()
    {
        connectionString = "Server=localhost; database = mokrilugkaw; user = root; password = ''; charset = utf8";
        MS_Connection = new MySqlConnection(connectionString);

        MS_Connection.Open();
    }
}
