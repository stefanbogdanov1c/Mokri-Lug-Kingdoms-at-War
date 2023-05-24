using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;

    private GameObject[,] positions = new GameObject[7, 7];
    private GameObject[] playerBlack = new GameObject[7];
    private GameObject[] playerWhite = new GameObject[7];

    private string currentPlayer = "white";

    private bool gameOver = false;

    private float cellSize = 1.0f; // Adjust the cell size according to your game

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
        GameObject obj = Instantiate(chesspiece, new Vector3(0,0,-1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.cellSize = cellSize; // Pass the cellSize value to the Chessman script
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }
}
