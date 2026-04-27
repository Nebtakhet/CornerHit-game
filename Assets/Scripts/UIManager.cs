using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance { get; private set; }

	public TextMeshProUGUI stageText;
	public GameObject gameOverPanel;
	public GameObject pausePanel;

	private void Awake()
	{
		Instance = this;
		ShowPausePanel(false);
	}

	public void UpdateStageText(int currentStage, int maxStages)
	{
		if (stageText == null)
		{
			Debug.LogWarning("UIManager: Stage text reference is missing.");
			return;
		}

		stageText.text = $"Stage: {currentStage}/{maxStages}";
	}

	public void ShowGameOverPanel()
	{
		if (gameOverPanel == null)
		{
			Debug.LogWarning("UIManager: Game over panel reference is missing.");
			return;
		}

		gameOverPanel.SetActive(true);
	}

	public void ShowPausePanel(bool isVisible)
	{
		if (pausePanel == null)
		{
			return;
		}

		pausePanel.SetActive(isVisible);
	}

}