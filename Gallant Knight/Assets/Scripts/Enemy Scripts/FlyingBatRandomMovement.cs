using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBatRandomMovement : MonoBehaviour
{
    [SerializeField] private float minX = -8.3f, maxX = 8.3f, minY = -4.5f, maxY = 4.5f;
    [SerializeField] private float moveSpeed = 2f;

    private float previousX;

    private Vector3 targetPosition;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveToTargetPosition();
    }

    void MoveToTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
            previousX = transform.position.x;
        }

        ChangeFacingDirection();
    }

    void ChangeFacingDirection()
    {
        if (transform.position.x > previousX) spriteRenderer.flipX = false;
        else if (transform.position.x < previousX) spriteRenderer.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG)) Destroy(collision.gameObject);
    }
}
