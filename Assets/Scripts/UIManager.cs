using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance { get; private set; }

	public TextMeshProUGUI stageText;
	public GameObject winText;
	public GameObject restartText;

	private void Awake()
	{
		Instance = this;
		ShowGameOverPanel(false);
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

	public void ShowGameOverPanel(bool isVisible = true)
	{
		if (winText == null)
		{
			Debug.LogWarning("UIManager: Win text reference is missing.");
			return;
		}

		winText.SetActive(isVisible);
	}

	public void ShowPausePanel(bool isVisible)
	{
		if (restartText == null)
		{
			return;
		}

		restartText.SetActive(isVisible);
	}

}