using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void PauseGame()
    {
        UIManager.Instance.PauseGame();
    }
}
