using TMPro;
using UnityEngine;

public class Status : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text attackText;
    private Chessman chessman;
    private Sprite crni_vojnik;

    // Start is called before the first frame update
    void Start()
    {
        chessman = GetComponent<Chessman>();
        UpdateText();
    }

    // Update is called once per frame
    void UpdateText()
    {
        this.GetComponent<SpriteRenderer>().sprite = crni_vojnik;
        healthText.text = "Health " + chessman.GetHealth();
        attackText.text = "Attack " + chessman.GetAttack();
    }
}
