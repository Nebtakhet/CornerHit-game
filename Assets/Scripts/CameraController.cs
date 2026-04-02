using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Camera mainCamera;
	public float zoomSpeed = 5f;
	public float targetSize;

	void Awake()
	{
		if (!mainCamera)
		{
			mainCamera = GetComponent<Camera>();
		}
	}

	void Start()
	{
		if (!mainCamera)
		{
			Debug.LogWarning("CameraController requires a Camera reference.");
			enabled = false;
			return;
		}

		if (targetSize <= 0f)
		{
			targetSize = mainCamera.orthographicSize;
		}
	}

	void Update()
	{
		if (!mainCamera)
		{
			return;
		}

		GameManager gameManager = GameManager.Instance;
		if (gameManager != null && (gameManager.IsGameOver || gameManager.IsGamePaused))
			return;

		mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
	}

	public void SetTargetSize(float newSize)
	{
		targetSize = Mathf.Max(0.01f, newSize);
	}
}