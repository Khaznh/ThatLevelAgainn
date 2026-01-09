using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : Singleton<SceneMoveManager>
{
    public void MoveToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MoveToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
