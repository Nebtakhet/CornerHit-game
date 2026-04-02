using UnityEngine;

public class BallController : MonoBehaviour
{
	public float startSpeed = 7f;
	private Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

    void Start()
    {
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
		rb.linearVelocity = dir * startSpeed;
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude < 0.01f)
		{
			rb.linearVelocity = rb.linearVelocity.normalized * startSpeed;
		}
    }
}
