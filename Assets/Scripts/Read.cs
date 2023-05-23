using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.UI;
public class Read : MonoBehaviour
{
    private string connectionString;
    string query;
    private MySqlConnection connection;
    private MySqlCommand command;
    private MySqlDataReader reader;
    public Text textCanvas;

    public void viewInfo()
    {
        query = "SELECT * FROM users";

        connectionString = "Server=localhost; database = mokrilugkaw; user = root; password = ''; charset = utf8";

        connection = new MySqlConnection(connectionString);

        connection.Open();

        command = new MySqlCommand(query, connection);

        reader = command.ExecuteReader();

        while (reader.Read())
        {
            textCanvas.text += "\n" + reader[0].ToString() + "       " + reader[1].ToString() + "        " + reader[2].ToString();
        }
        reader.Close();
    }


}

