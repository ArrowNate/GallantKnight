using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSoldier : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private RaycastHit2D groundHit;

    private Vector3 tempPos;
    private Vector3 tempScale;

    private bool moveLeft;

    private void Awake()
    {
        groundCheckPos = transform.GetChild(0).transform;

        /*if (Random.Range(0,2) > 0)
            moveLeft = true;
        else
            moveLeft = false;*/

        moveLeft = Random.Range(0, 2) > 0 ? true : false;
    }

    private void Update()
    {
        HandleMovement();
        CheckForGround();
    }

    void HandleMovement()
    {
        tempPos = transform.position;
        tempScale = transform.localScale;

        if (moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
            tempScale.x = -1f;
        }
        else
        {
            tempPos.x += moveSpeed * Time.deltaTime;
            tempScale.x = 1f;
        }

        transform.position = tempPos;
        transform.localScale = tempScale;
    }

    void CheckForGround()
    {
        groundHit = Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.5f, groundLayer);

        if (!groundHit)
            moveLeft = !moveLeft;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            Destroy(collision.gameObject);
        }
    }
}