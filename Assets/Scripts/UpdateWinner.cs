using MySql.Data.MySqlClient;
using System;
using UnityEngine;

public class UpdateWinner : MonoBehaviour
{
    private string connectionString;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    string updateQuery;
    string getWon;
    string getLost;

    public void UpdateUserScoreDb(string user, int won, int lost)
    {
        try
        {
            connection();
            updateQuery = $"UPDATE users SET won={won}, lost={lost} WHERE username = '{user}'";
            //Debug.Log(user.GetType());
            //Debug.Log(user.ToString());
            MS_Command = new MySqlCommand(updateQuery, MS_Connection);
            MS_Command.ExecuteNonQuery();
            MS_Connection.Close();

        }
        catch (Exception ex)
        {

            Debug.Log(ex.Message);
        }
    }
    public void connection()
    {
        connectionString = "Server=localhost; database = mokrilugkaw; user = root; password = ''; charset = utf8";
        MS_Connection = new MySqlConnection(connectionString);

        MS_Connection.Open();
    }
}
