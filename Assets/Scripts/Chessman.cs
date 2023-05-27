using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    //References to objects in our Unity Scene
    public GameObject controller;
    public GameObject movePlate;

    //Position for this Chesspiece on the Board
    //The correct position will be set later
    private int xBoard = -1;
    private int yBoard = -1;

    //Variable for keeping track of the player it belongs to "black" or "white"
    private string player;

    //References to all the possible Sprites that this Chesspiece could be
    public Sprite crni_vojnik, crni_kralj, crni_strelac;
    public Sprite beli_vojnik, beli_kralj, beli_strelac;


    public void Activate()
    {
        //Get the game controller
        controller = GameObject.FindGameObjectWithTag("GameController");

        //Take the instantiated location and adjust transform
        SetCoords();

        //Choose correct sprite based on piece's name
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
        //Get the board value in order to convert to xy coords
        float x = xBoard;
        float y = yBoard;

        //Adjust by variable offset
        x *= 1.343f;
        y *= 1.322f;

        //Add constants (pos 0,0)
        x += -4.0f;
        y += -4.0f;

        //Set actual unity values
        this.transform.position = new Vector3(x, y, -2.0f);
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