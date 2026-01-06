using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Button mainPauseBtn;
    public GameObject pausePanel;
    private void Update()
    {
        if (LevelManager.Instance.currentLevel == 9)
        {
            mainPauseBtn.gameObject.SetActive(false);
            return;
        } else
        {
            mainPauseBtn.gameObject.SetActive(true);
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

    }
}
