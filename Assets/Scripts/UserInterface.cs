using TMPro;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public static UserInterface instance;
    public GameObject canvas;
    public TextMeshProUGUI uiText;

    public void Awake()
    {
        instance = this;
        canvas.SetActive(false);
    }

    public void show(string text)
    {
        canvas.SetActive(true);
        uiText.text = text;
    }
}
