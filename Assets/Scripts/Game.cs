using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    //Reference from Unity IDE
    public GameObject chesspiece;

    //Matrices needed, positions of each of the GameObjects
    //Also separate arrays for the players in order to easily keep track of them all
    //Keep in mind that the same objects are going to be in "positions" and "playerBlack"/"playerWhite"

    private GameObject[,] positions = new GameObject[7, 7];
    private GameObject[] playerBlack = new GameObject[7];
    private GameObject[] playerWhite = new GameObject[7];

    //current turn
    private string currentPlayer = "white";

    //Game Ending
    private bool gameOver = false;
    private string getWon;
    private string getLost;

    //Data for database, connection...
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    private string connectionString;


    //Unity calls this right when the game starts, there are a few built in functions
    //that Unity can call for you
    void Start()
    {

        playerWhite = new GameObject[] {
            Create("beli_vojnik", 0, 0), Create("beli_strelac", 1, 0), Create("beli_vojnik", 2, 0),
            Create("beli_kralj", 3, 0), Create("beli_vojnik", 4, 0), Create("beli_strelac", 5, 0), Create("beli_vojnik", 6, 0)
        };
        playerBlack = new GameObject[] {
            Create("crni_vojnik", 0, 6), Create("crni_strelac", 1, 6), Create("crni_vojnik", 2, 6),
            Create("crni_kralj", 3, 6), Create("crni_vojnik", 4, 6), Create("crni_strelac", 5, 6), Create("crni_vojnik", 6, 6)
        };

        for (int i = 0; i < playerWhite.Length; i++)
        {
            SetPosition(playerWhite[i]);
            SetPosition(playerBlack[i]);
        }


    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -2), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>(); //We have access to the GameObject, we need the script
        cm.name = name; //This is a built in variable that Unity has, so we did not have to declare it before
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate(); //It has everything set up so it can now Activate()

        switch (name)
    {
        case "beli_vojnik":
        case "crni_vojnik":
            cm.SetAttack(2);
            cm.SetHealth(3);
            break;
        case "beli_strelac":
        case "crni_strelac":
            cm.SetAttack(3);
            cm.SetHealth(4);
            break;
        case "beli_kralj":
        case "crni_kralj":
            cm.SetAttack(2);
            cm.SetHealth(8);
            break;
    }
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        //Overwrites either empty space or whatever was there
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }


    //checking if the position is on bounds of the board
    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false; return true;
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentPlayer == "white")
        {
            currentPlayer = "black";
        }
        else
        {
            currentPlayer = "white";
        }

    }

    public void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            SceneManager.LoadScene("Game");
        }
    }


    public void Winner(string playerWinner)
    {
        gameOver = true;
        if (playerWinner == "white")
        {
            GameObject.FindGameObjectWithTag("BeliPobeda").GetComponent<Image>().enabled = true;
            UpdateWinner win = new();
            connection();
            string userOneWon = PlayerPrefs.GetString("UserOne");
            string userTwoWon = PlayerPrefs.GetString("UserTwo");
            win.UpdateUserScore(userOneWon, userTwoWon);

        }
        if (playerWinner == "black")
        {
            GameObject.FindGameObjectWithTag("CrniPobeda").GetComponent<Image>().enabled = true;
            UpdateWinner win = new();
            connection();
            string userOneWon = PlayerPrefs.GetString("UserOne");
            string userTwoWon = PlayerPrefs.GetString("UserTwo");
            win.UpdateUserScore(userTwoWon, userOneWon);
        }
    }

    private void connection()
    {
        connectionString = "Server=localhost; database = mokrilugkaw; user = root; password = ''; charset = utf8";
        MS_Connection = new MySqlConnection(connectionString);

        MS_Connection.Open();
    }


}