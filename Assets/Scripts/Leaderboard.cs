using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{

    public GameObject options;
    void Start()
    {
        textCanvas.text = "";
        query = "SELECT * FROM users ORDER BY (won/lost) DESC";

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
        options.SetActive(false);
    }
}
