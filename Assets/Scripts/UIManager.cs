using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance { get; private set; }

	public TextMeshProUGUI stageText;
	public GameObject gameOverPanel;

	private void Awake()
	{
		Instance = this;
	}

	public void UpdateStageText(int currentStage, int maxStages)
	{
		stageText.text = $"Stage: {currentStage}/{maxStages}";
	}

	public void ShowGameOverPanel()
	{
		gameOverPanel.SetActive(true);
	}

}