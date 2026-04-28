using UnityEngine;

public class PausePanelController : MonoBehaviour
{
    public void Resume()
    {
        var gm = GameManager.Instance;
        if (gm != null)
            gm.ResumeGame();
    }

    public void Restart()
    {
        var gm = GameManager.Instance;
        if (gm != null)
            gm.RestartLevel();
    }
}
