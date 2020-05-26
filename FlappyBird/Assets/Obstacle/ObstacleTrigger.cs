using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            PlayerEvents.OnPlayerHitObstacleFunction();
        }

        if (other.CompareTag(TagHelper.OBSTACLE_DESTROY_TAG))
        {
            Obstacle parent = GetComponentInParent<Obstacle>();
            Destroy(parent.gameObject);
        }
    }
}
