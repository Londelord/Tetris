using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] UnityEvent action;
    [SerializeField] TextMeshProUGUI difficulty;

    private TextMeshProUGUI text; 

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

    }

    private void OnMouseEnter()
    {
        text.color = new Color(255, 0, 255);
    }

    private void OnMouseExit()
    {
        text.color = new Color(255, 255, 255);
    }

    private void OnMouseUpAsButton()
    {
        text.color = new Color(255, 255, 255);
        action?.Invoke();
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonEasy()
    {
        Data.stepDelay = 1f;
        difficulty.text = "Selected difficulty:\nEasy";
    }

    public void ButtonNormal()
    {
        Data.stepDelay = 0.4f;
        difficulty.text = "Selected difficulty:\nNormal";
    }

    public void ButtonHard()
    {
        Data.stepDelay = 0.1f;
        difficulty.text = "Selected difficulty:\nHard";
    }

    public void ButtonToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
