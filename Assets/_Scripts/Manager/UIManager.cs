using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    private string suggest1 = "Plain and simple";
    private string suggest2 = "Try more";
    private string suggest3 = "Just press on it";
    private string suggest4 = "Back";
    private string suggest5 = "Try dying";
    private string suggest6 = "Don't touch it";
    private string suggest7 = "Press harder";
    private string suggest8 = "Shambles";
    private string suggest9 = "Press pause";
    private string suggest10 = "Dont trust your eyes";


    [SerializeField] private Button mainPauseBtn;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    public GameObject pausePanel;


    private void Update()
    {
        if (LevelManager.Instance.currentLevel == 10)
        {
            mainPauseBtn.gameObject.SetActive(false);
            return;
        } else
        {
            mainPauseBtn.gameObject.SetActive(true);
        }

        switch (LevelManager.Instance.currentLevel)
        {
            case 2:
                textMeshProUGUI.text = suggest1;
                break;
            case 3:
                textMeshProUGUI.text = suggest2;
                break;
            case 4:
                textMeshProUGUI.text = suggest3;
                break;
            case 5:
                textMeshProUGUI.text = suggest4;
                break;
            case 6:
                textMeshProUGUI.text = suggest5;
                break;
            case 7:
                textMeshProUGUI.text = suggest6;
                break;
            case 8:
                textMeshProUGUI.text = suggest7;
                break;
            case 9:
                textMeshProUGUI.text = suggest8;
                break;
            case 10:
                textMeshProUGUI.text = suggest9;
                break;
            case 11:
                textMeshProUGUI.text = suggest10;
                break;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void BackToStartScene()
    {
        SceneMoveManager.Instance.MoveToMenuScene();
    }
}
