using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    // Positions
    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Sprite crni_vojnik, crni_kralj, crni_strelac;
    public Sprite beli_vojnik, beli_kralj, beli_strelac;

    public float cellSize = 1.0f; // Adjust the cell size according to your game

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "crni_vojnik": this.GetComponent<SpriteRenderer>().sprite = crni_vojnik; break;
            case "crni_kralj": this.GetComponent<SpriteRenderer>().sprite = crni_kralj; break;
            case "crni_strelac": this.GetComponent<SpriteRenderer>().sprite = crni_strelac; break;

            case "beli_vojnik": this.GetComponent<SpriteRenderer>().sprite = beli_vojnik; break;
            case "beli_kralj": this.GetComponent<SpriteRenderer>().sprite = beli_kralj; break;
            case "beli_strelac": this.GetComponent<SpriteRenderer>().sprite = beli_strelac; break;

        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        // Calculate the position offsets based on the board size and piece size
        float xOffset = -3.15f + (cellSize / 2f);
        float yOffset = -3.15f + (cellSize / 2f);

        // Calculate the final position based on the board indices and offsets
        float finalX = xOffset + (x * cellSize);
        float finalY = yOffset + (y * cellSize);

        this.transform.position = new Vector3(finalX, finalY, -2.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }
}
