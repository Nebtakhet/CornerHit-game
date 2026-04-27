using UnityEngine;

public class CornerTrigger : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ball"))
		{
			ArenaManager arena = ArenaManager.Instance;
			if (arena)
				arena.OnBallHitCorner();
		}
	}
}
