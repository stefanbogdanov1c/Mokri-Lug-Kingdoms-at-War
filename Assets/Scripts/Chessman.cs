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
            case "crni_vojnik": this.GetComponent<SpriteRenderer>().sprite = crni_vojnik; player = "black"; break;
            case "crni_kralj": this.GetComponent<SpriteRenderer>().sprite = crni_kralj; player = "black"; break;
            case "crni_strelac": this.GetComponent<SpriteRenderer>().sprite = crni_strelac; player = "black"; break;

            case "beli_vojnik": this.GetComponent<SpriteRenderer>().sprite = beli_vojnik; player = "white"; break;
            case "beli_kralj": this.GetComponent<SpriteRenderer>().sprite = beli_kralj; player = "white"; break;
            case "beli_strelac": this.GetComponent<SpriteRenderer>().sprite = beli_strelac; player = "white"; break;

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

    public void OnMouseUp()
    {
        DestroyMovePlates();

        InitiateMovePlates();

    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    private void InitiateMovePlates()
    {
        switch (this.name)
        {
            case "crni_strelac":
            case "beli_strelac":
                LMovePlate();
                break;
            case "crni_kralj":
            case "beli_kralj":
                SurroundMovePlate();
                break;
            case "beli_vojnik":
                SoldierMovePlate(xBoard, yBoard + 1);
                break;
            case "crni_vojnik":
                SoldierMovePlate(xBoard, yBoard - 1);
                break;


        }
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 0);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);

    }

    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if (cp == null)
            {
                MovePlateSpawn(x, y);
            }
            else if(cp.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void SoldierMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            if(sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(x, y);
            }

            if(sc.PositionOnBoard(x+1,y) && sc.GetPosition(x+1,y)!=null && sc.GetPosition(x+1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }
            if (sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
            if (sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }
        }
    }

    public void MovePlateSpawn (int matrixX, int matrixY)
    {
        float x  = matrixX;
        float y = matrixY;

        x *= 1.343f;
        y *= 1.322f;

        x += -4.0f;
        y += -4.0f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1.343f;
        y *= 1.322f;

        x += -4.0f;
        y += -4.0f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
}