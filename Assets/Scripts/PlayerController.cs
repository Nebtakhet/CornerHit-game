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
		if (Keyboard.current != null)
		{
			if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
			{
				keyboardInput -= 1f;
			}

			if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
			{
				keyboardInput += 1f;
			}
		}

		float gamepadInput = Gamepad.current != null ? Gamepad.current.leftStick.ReadValue().x : 0f;
		moveInput = Mathf.Abs(gamepadInput) > Mathf.Abs(keyboardInput) ? gamepadInput : keyboardInput;

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

		bool jumpPressed = (Keyboard.current != null &&
			(Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame))
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
