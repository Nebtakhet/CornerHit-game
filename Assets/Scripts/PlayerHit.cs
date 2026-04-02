using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHit : MonoBehaviour
{
	public Transform hitPoint;
	public Vector2 hotBoxSize = new Vector2(1.4f, 0.8f);
	public LayerMask ballLayer;
	public float hitForce = 10f;

    void Update()
    {
		if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			Collider2D hitBall = Physics2D.OverlapBox(hitPoint.position, hotBoxSize, 0f, ballLayer);
			if (hitBall != null)
			{
				Rigidbody2D ballRb = hitBall.GetComponent<Rigidbody2D>();
				if (ballRb != null)
				{
					Vector2 hitDirection = (hitBall.transform.position - transform.position).normalized;
					ballRb.AddForce(hitDirection * hitForce, ForceMode2D.Impulse);
				}
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		if (hitPoint != null)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(hitPoint.position, hotBoxSize);
		}
	}
}
