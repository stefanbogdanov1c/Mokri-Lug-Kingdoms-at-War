using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;

    int matrixX;
    int matrixY;

    //bool for checking if the move attacks or just moves
    public bool attacked = false;

    public void Start()
    {
        if (attacked)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attacked)
        {
            GameObject attacker = reference;
            GameObject defender = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            Battle(attacker.GetComponent<Chessman>(), defender.GetComponent<Chessman>());
        }
        else
        {
            controller
                .GetComponent<Game>()
                .SetPositionEmpty(
                    reference.GetComponent<Chessman>().GetXBoard(),
                    reference.GetComponent<Chessman>().GetYBoard()
                );

            reference.GetComponent<Chessman>().SetXBoard(matrixX);
            reference.GetComponent<Chessman>().SetYBoard(matrixY);
            reference.GetComponent<Chessman>().SetCoords();

            controller.GetComponent<Game>().SetPosition(reference);
        }

        controller.GetComponent<Game>().NextTurn();

        reference.GetComponent<Chessman>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }

    public void Battle(Chessman attacker, Chessman defender)
    {
        int attackerHealth = attacker.GetHealth();
        int attackerAttack = attacker.GetAttack();
        int defenderHealth = defender.GetHealth();
        int defenderAttack = defender.GetAttack();

        // Both figures' health is not 0 or below
        if (attackerHealth > 0 && defenderHealth > 0)
        {
            // Attacker damages defender's health
            defenderHealth -= attackerAttack;

            // Defender damages attacker's health
            attackerHealth -= defenderAttack;

            // Update health values
            attacker.SetHealth(attackerHealth);
            defender.SetHealth(defenderHealth);
        }

        // Defender's health goes 0 or below
        if (defenderHealth <= 0 && attackerHealth > 0)
        {
            // Destroy the defender
            Destroy(defender.gameObject);

            // Move the attacker to the defender's position
            attacker.SetXBoard(defender.GetXBoard());
            attacker.SetYBoard(defender.GetYBoard());
            attacker.SetCoords();
        }

        // Attacker's health goes 0 or below
        if (attackerHealth <= 0 && defenderHealth > 0)
        {
            // Destroy the attacker
            Destroy(attacker.gameObject);
        }

        // Both chesspieces' health goes to 0 or below
        if (attackerHealth <= 0 && defenderHealth <= 0)
        {
            // Destroy both chesspieces
            Destroy(attacker.gameObject);
            Destroy(defender.gameObject);
        }

        // Start the next turn
        // ...
        if(attacker.name == "beli_kralj" && attackerHealth <= 0) {
           controller.GetComponent<Game>().Winner("black");


        } else if (attacker.name == "crni_kralj" && attackerHealth <= 0) {
            controller.GetComponent<Game>().Winner("white");

        } else if(defender.name == "beli_kralj" && defenderHealth <= 0) {
            controller.GetComponent<Game>().Winner("black");

        } else if(defender.name == "crni_kralj" && defenderHealth <= 0) {
            controller.GetComponent<Game>().Winner("white");
        } else if((attacker.name == "crni_kralj" && attackerHealth <= 0) && (defender.name == "beli_kralj" && defenderHealth <= 0)) {

            controller.GetComponent<Game>().Winner("none");

        } else if((attacker.name == "beli_kralj" && attackerHealth <= 0) && (defender.name == "crni_kralj" && defenderHealth <= 0)) {

            controller.GetComponent<Game>().Winner("none");

        }
    }
}
