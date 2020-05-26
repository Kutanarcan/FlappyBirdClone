using UnityEngine;

public class ForeGroundTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagHelper.PLAYER_TAG))
        {
            PlayerEvents.OnPlayerHitObstacleFunction();
        }
    }
}
