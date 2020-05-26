using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField]
    GameObject dieSound;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        PlayerEvents.OnPlayerHitObstacle += PlayerEvents_OnPlayerHitObstacle;
    }

    private void PlayerEvents_OnPlayerHitObstacle()
    {
        Instantiate(dieSound);
        playerController.DisableInput();
        GameManager.Instance.GameOver();
        PlayerEvents.OnPlayerHitObstacle -= PlayerEvents_OnPlayerHitObstacle;
    }   
}
