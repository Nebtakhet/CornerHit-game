using UnityEngine;
// Using legacy Input API for keyboard checks
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public bool IsGameOver = false;
	public bool IsGamePaused = false;

	private void Awake()
	{
		Instance = this;
	}

	public void GameOver()
	{
		IsGameOver = true;
		ResumeGame();
	}

	public void PauseGame()
	{
		if (IsGamePaused)
		{
			return;
		}

		IsGamePaused = true;
		Time.timeScale = 0f;

		UIManager uiManager = UIManager.Instance;
		if (uiManager != null)
		{
			uiManager.ShowPausePanel(true);
		}
	}

	public void ResumeGame()
	{
		if (!IsGamePaused)
		{
			return;
		}

		IsGamePaused = false;
		Time.timeScale = 1f;

		UIManager uiManager = UIManager.Instance;
		if (uiManager != null)
		{
			uiManager.ShowPausePanel(false);
		}
	}

	public void RestartLevel()
	{
		Time.timeScale = 1f;
		IsGamePaused = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void Update()
	{
		if (IsGameOver && Input.GetKeyDown(KeyCode.R))
		{
			RestartLevel();
		}

		if (!IsGameOver && Input.GetKeyDown(KeyCode.Return))
		{
			if (IsGamePaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}
}