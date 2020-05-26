using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Body { get; private set; }

    float jumpForce = 3f;
    float rotationForce = 8f;

    [SerializeField]
    GameObject jumpSound;

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.eulerAngles = Vector3.forward * Body.velocity.y * rotationForce;
    }

    public void Jump()
    {
        Body.velocity = Vector2.up * jumpForce;
        GameObject tmp = Instantiate(jumpSound);
        Destroy(tmp.gameObject, 1.5f);
    }
}
