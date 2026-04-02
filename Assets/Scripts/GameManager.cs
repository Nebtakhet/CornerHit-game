using UnityEngine;

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
	}

	public void PauseGame()
	{
		IsGamePaused = true;
		Time.timeScale = IsGamePaused ? 0 : 1;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1f;
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	}

	void Update()
	{
		if (IsGameOver && Input.GetKeyDown(KeyCode.R))
		{
			ResumeGame();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseGame();
		}
	}
}