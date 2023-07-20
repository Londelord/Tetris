using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.IO;

public class Button : MonoBehaviour
{
    [SerializeField] UnityEvent action;
    [SerializeField] TextMeshProUGUI textPlace;

    private TextMeshProUGUI buttonText; 

    private void Awake()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void SetDifficulty(float speed, string selectedDifficulty)
    {
        Data.selectedDifficulty = selectedDifficulty;
        Data.stepDelay = speed;
        textPlace.text = $"Selected difficulty:\n{Data.selectedDifficulty}";
    }

    private void OnMouseEnter()
    {
        buttonText.color = new Color(255, 0, 255);
    }

    private void OnMouseExit()
    {
        buttonText.color = new Color(255, 255, 255);
    }

    private void OnMouseUpAsButton()
    {
        buttonText.color = new Color(255, 255, 255);
        action?.Invoke();
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonOptions()
    {
        textPlace.text = $"Selected difficulty:\n{Data.selectedDifficulty}";
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonEasy()
    {
        SetDifficulty(0.7f, "Easy");
    }

    public void ButtonNormal()
    {
        SetDifficulty(0.3f, "Normal");
    }

    public void ButtonHard()
    {
        SetDifficulty(0.1f, "Hard");
    }

    public void ButtonToMenu()
    {
        Data.score = 0;
        SceneManager.LoadScene(0);
    }

    public void ButtonHighScoreTable()
    {
        string[] records = File.ReadAllText($"{Application.streamingAssetsPath}/HighScoreTable.txt").Split();
        for(int i = 0; i < records.Length; i++)
        {
            textPlace.text += $"{i+1}.{records[i]}\n";
        }
    }
}
