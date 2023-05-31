using TMPro;
using UnityEngine;

public class DisplayUserTwo : MonoBehaviour
{
    private TextMeshProUGUI usernameText;

    // Start is called before the first frame update
    void Start()
    {
        usernameText = GetComponent<TextMeshProUGUI>();

        string username = PlayerPrefs.GetString("UserTwo");

        usernameText.text = username;
    }

}
