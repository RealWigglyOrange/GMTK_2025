using TMPro;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameMode GM;
    [SerializeField] private PlayerController player;

    public static UserInterface instance;
    public GameObject canvas;
    public GameObject panel;
    public GameObject fastForward;
    public TextMeshProUGUI uiText;
    public TextMeshProUGUI timeText;

    public void Awake()
    {
        instance = this;
        panel.SetActive(false);
        fastForward.SetActive(false);
    }

    public void show(string text)
    {
        panel.SetActive(true);
        uiText.text = text;
    }

    private void Update()
    {
        updateClock();
        if (player.fastForwarding)
        {
            fastForward.SetActive(true);
        } else
        {
            fastForward.SetActive(false);
        }
    }

    void updateClock()
    {
        float hours = Mathf.Floor(GM.minutes / 60) + 9.0f;
        float minutes = GM.minutes % 60;

        if (GM.minutes < 10)
        {
            timeText.text = hours + ":0" + minutes;
        }
        else
        {
            timeText.text = hours + ":" + minutes;
        }
    }
}
