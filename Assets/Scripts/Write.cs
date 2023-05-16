using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEditor.VersionControl;

public class Write : MonoBehaviour
{
    public TextMeshProUGUI username;
    public TextMeshProUGUI score;
    private string connectionString;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    string query;
    public void sendInfo()
    {
        try
        {
            connection();

            query = "INSERT INTO `users`(`userName`, `highScore`) VALUES ('" + username.text + "' , '" + score.text +"');";

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
        connectionString = "Server=.d; database=mokrilugkaw; password=password; user=root; ; charset = utf8;";
        MS_Connection = new MySqlConnection(connectionString);

        MS_Connection.Open();
    }
}
