using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float horizontalMovement;

    private Rigidbody2D pRB;

    private Vector3 movePos;

    private void Awake()
    {
        pRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw(TagManager.HORIZONTAL_MOVEMENT_AXIS);
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (horizontalMovement > 0)
        {
            pRB.velocity = new Vector2(moveSpeed, pRB.velocity.y);
        }
        else if (horizontalMovement < 0)
        {
            pRB.velocity = new Vector2(-moveSpeed, pRB.velocity.y);
        }
        else
        {
            pRB.velocity = new Vector2(0f, pRB.velocity.y);
        }
    }
}
