using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.UI;
using TMPro;

public class Write : MonoBehaviour
{

    public TMP_InputField username;
    //public? TMP_InputField score;
    private string connectionString;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    string query;
    public void sendInfo()
    {
        try
        {
            connection();

            query = "INSERT INTO users ( userName ) VALUES ('" + username.text + "');";

            MS_Command = new MySqlCommand(query, MS_Connection);

            MS_Command.ExecuteNonQuery();

            MS_Connection.Close();

        }catch (Exception ex)
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
