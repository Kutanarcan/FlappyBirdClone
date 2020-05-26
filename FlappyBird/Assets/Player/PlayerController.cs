using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    PlayerMovement playerMovement;
    PlayerInput playerInput;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void DisablePlayerControl()
    {
        playerMovement.enabled = false;
        playerInput.enabled = false;
        playerMovement.Body.gravityScale = 0;
    }

    public void DisableInput()
    {
        playerInput.enabled = false;
    }

    public void EnablePlayerControl()
    {
        playerMovement.enabled = true;
        playerInput.enabled = true;
        playerMovement.Body.gravityScale = 1;
    }
}
