using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 8f;
	public float jumpForce = 12f;
	public Transform groundCheck;
	public float groundRadius = 0.15f;
	public LayerMask groundLayer;

	private Rigidbody2D rb;
	private float moveInput;
	private bool isGrounded;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
		float keyboardInput = 0f;
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			keyboardInput -= 1f;
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			keyboardInput += 1f;
		}

		float gamepadInput = Gamepad.current != null ? Gamepad.current.leftStick.ReadValue().x : 0f;
		moveInput = Mathf.Abs(gamepadInput) > Mathf.Abs(keyboardInput) ? gamepadInput : keyboardInput;

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

		bool jumpPressed = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			|| (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame);

		if (isGrounded && jumpPressed)
		{
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
		}
	}

	void FixedUpdate()
	{
		rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
	}
}
