using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goback : MonoBehaviour
{
    // Start is called before the first frame update


    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ToLore()
    {
        SceneManager.LoadScene("Lore");
    }

    public void ToBoard()
    {
        SceneManager.LoadScene("Board");

    }

    public void ToLogin()
    {
        SceneManager.LoadScene("Login");
    }

}
