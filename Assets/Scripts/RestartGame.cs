using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void RestartCurrentScene()
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            gameManager.RestartLevel();
        }
    }
}
