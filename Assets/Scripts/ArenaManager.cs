using UnityEngine;
using UnityEngine.Serialization;

public class ArenaManager : MonoBehaviour
{
	public static ArenaManager Instance { get; private set; }

	[Header("Arena")]
	public float arenaWidth = 16f;
	public float arenaHeight = 9f;
	public float wallThickness = 0.5f;

	[Header("Growth")]
	public int stage = 0;
	public int maxStages = 5;
	[FormerlySerializedAs("withGrowth")]
	public float widthGrowth = 4f;
	public float heightGrowth = 2.25f;

	[Header("References")]
	public Transform leftWall;
	public Transform rightWall;
	public Transform topWall;
	public Transform bottomWall;
	public Transform cornerTL;
	public Transform cornerTR;
	public Transform cornerBL;
	public Transform cornerBR;

	public Camera mainCamera;
	public CameraController cameraController;
	public float camPadding = 1f;

	private bool canTriggerCorner = true;

	private void Awake()
	{
		Instance = this;
	}

    void Start()
    {
		ResolveCameraController();
		EnsureCornerTriggerComponents();
        RebuildArena();
    }

	void OnValidate()
	{
		ResolveCameraController();

		if (!Application.isPlaying)
		{
			EnsureCornerTriggerComponents();
			RebuildArena();
		}
	}

	public void OnBallHitCorner()
	{
		if (!canTriggerCorner || stage >= maxStages)
			return;

		canTriggerCorner = false;
		stage++;

		if (stage > maxStages)
		{
			BreakArena();
			return;
		}

		arenaWidth += widthGrowth;
		arenaHeight += heightGrowth;

		if (mainCamera != null)
		{
			CameraShake cameraShake = mainCamera.GetComponent<CameraShake>();
			if (cameraShake != null)
			{
				StartCoroutine(cameraShake.Shake(0.3f, 0.2f));
			}
		}
		UIManager uiManager = UIManager.Instance;
		if (uiManager != null)
		{
			uiManager.UpdateStageText(stage, maxStages);
		}

		RebuildArena();
		Invoke(nameof(ResetCornerTrigger), 0.2f);
	}

	void ResetCornerTrigger()
	{
		canTriggerCorner = true;
	}

	void RebuildArena()
	{
		if (leftWall == null || rightWall == null || topWall == null || bottomWall == null ||
			cornerTL == null || cornerTR == null || cornerBL == null || cornerBR == null)
		{
			return;
		}

		float left = -arenaWidth / 2f;
		float right = arenaWidth / 2f;
		float top = arenaHeight / 2f;
		float bottom = -arenaHeight / 2f;
		float horizontalWallLength = arenaWidth + wallThickness;
		float verticalWallLength = arenaHeight + wallThickness;

		topWall.localPosition = new Vector3(0f, top, 0f);
		bottomWall.localPosition = new Vector3(0f, bottom, 0f);
		leftWall.localPosition = new Vector3(left, 0f, 0f);
		rightWall.localPosition = new Vector3(right, 0f, 0f);

		topWall.localScale = new Vector3(horizontalWallLength, wallThickness, 1f);
		bottomWall.localScale = new Vector3(horizontalWallLength, wallThickness, 1f);
		leftWall.localScale = new Vector3(wallThickness, verticalWallLength, 1f);
		rightWall.localScale = new Vector3(wallThickness, verticalWallLength, 1f);

		PositionCorner(cornerTL, left, top);
		PositionCorner(cornerTR, right, top);
		PositionCorner(cornerBL, left, bottom);
		PositionCorner(cornerBR, right, bottom);

		float targetCamSize = arenaHeight / 2f + camPadding;
		if (cameraController)
		{
			cameraController.SetTargetSize(targetCamSize);
		}
		else if (mainCamera)
		{
			mainCamera.orthographicSize = targetCamSize;
		}
	}

	void ResolveCameraController()
	{
		if (cameraController)
		{
			return;
		}

		if (mainCamera)
		{
			cameraController = mainCamera.GetComponent<CameraController>();
		}
	}

	void PositionCorner(Transform corner, float x, float y)
	{
		float offset = wallThickness / 2f;
		float posX = x > 0f ? x - offset : x + offset;
		float posY = y > 0f ? y - offset : y + offset;
		corner.localPosition = new Vector3(posX, posY, 0f);

		BoxCollider2D cornerCollider = corner.GetComponent<BoxCollider2D>();
		if (cornerCollider != null)
		{
			float cornerSize = Mathf.Max(0.1f, wallThickness + 0.1f);
			cornerCollider.size = new Vector2(cornerSize, cornerSize);
			cornerCollider.offset = Vector2.zero;
			cornerCollider.isTrigger = true;
		}
	}

	void EnsureCornerTriggerComponents()
	{
		TryAddCornerTrigger(cornerTL);
		TryAddCornerTrigger(cornerTR);
		TryAddCornerTrigger(cornerBL);
		TryAddCornerTrigger(cornerBR);
	}

	void TryAddCornerTrigger(Transform corner)
	{
		if (corner == null || corner.GetComponent<CornerTrigger>() != null)
		{
			return;
		}

		corner.gameObject.AddComponent<CornerTrigger>();
	}

	void BreakArena()
	{
		topWall.gameObject.SetActive(false);
		bottomWall.gameObject.SetActive(false);
		leftWall.gameObject.SetActive(false);
		rightWall.gameObject.SetActive(false);

		cornerTL.gameObject.SetActive(false);
		cornerTR.gameObject.SetActive(false);
		cornerBL.gameObject.SetActive(false);
		cornerBR.gameObject.SetActive(false);

		GameManager gameManager = GameManager.Instance;
		if (gameManager)
		{
			gameManager.GameOver();
		}

		UIManager uiManager = UIManager.Instance;
		if (uiManager)
		{
			uiManager.ShowGameOverPanel();
		}
	}
}
