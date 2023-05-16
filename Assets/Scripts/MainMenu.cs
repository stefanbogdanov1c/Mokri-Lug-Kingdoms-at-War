using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeSceneToLogin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //ovo moze da se menja da se stavljaju default scene
    }

    public void ChangeSceneToLeaderboard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        //ovo moze da se menja da se stavljaju default scene
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
