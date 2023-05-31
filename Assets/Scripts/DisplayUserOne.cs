using TMPro;
using UnityEngine;

public class DisplayUserOne : MonoBehaviour
{
    private TextMeshProUGUI usernameText;

    // Start is called before the first frame update
    void Start()
    {
        usernameText = GetComponent<TextMeshProUGUI>();

        string username = PlayerPrefs.GetString("UserOne");

        usernameText.text = username;
    }
}
