using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    Rigidbody2D body;
    Vector2 moveDirection;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        moveDirection = -Vector2.right * movementSpeed * Time.fixedDeltaTime;
        GameEvents.OnGameOvered += GameEvents_OnGameOvered;
    }

    private void GameEvents_OnGameOvered()
    {
        moveDirection = Vector2.zero;
    }

    void FixedUpdate()
    {
        body.velocity = moveDirection;
    }

    void OnDisable()
    {
        GameEvents.OnGameOvered -= GameEvents_OnGameOvered;
    }
}
