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

    private void SetDifficulty(float speed, string selectedDifficulty)
    {
        Data.selectedDifficulty = selectedDifficulty;
        Data.stepDelay = speed;
        difficulty.text = $"Selected difficulty:\n{Data.selectedDifficulty}";
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

    public void ButtonOptions()
    {
        difficulty.text = $"Selected difficulty:\n{Data.selectedDifficulty}";
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonEasy()
    {
        SetDifficulty(1f, "Easy");
    }

    public void ButtonNormal()
    {
        SetDifficulty(0.4f, "Normal");
    }

    public void ButtonHard()
    {
        SetDifficulty(0.25f, "Hard");
    }

    public void ButtonToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
