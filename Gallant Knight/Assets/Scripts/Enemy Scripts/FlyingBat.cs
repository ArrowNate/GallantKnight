using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBat : MonoBehaviour
{
    [SerializeField] private float moveSpeedHorizontal = 2f, moveSpeedVertical = -2f;
    [SerializeField] private float horizontalMovementThreshold = 7f, verticalMovementThreshold = 4f;

    private float minX, maxX, minY, maxY;

    private Vector3 tempPos;
    private SpriteRenderer spriteRenderer;

    private bool moveHorizontal = true;
    private bool moveVertical;

    private void Awake()
    {
        minX = transform.position.x - horizontalMovementThreshold;
        maxX = transform.position.x + horizontalMovementThreshold;

        minY = transform.position.y - verticalMovementThreshold;
        maxX = transform.position.y + verticalMovementThreshold;

        moveVertical = Random.Range(0, 2) > 0 ? true : false;

        if (Random.Range(0, 2) > 0)
            moveSpeedHorizontal *= -1f;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();
    }

    void HandleHorizontalMovement()
    {
        if (moveHorizontal)
        {
            tempPos = transform.position;
            tempPos.x += moveSpeedHorizontal * Time.deltaTime;

            if (tempPos.x > maxX)
                moveSpeedHorizontal = -Mathf.Abs(moveSpeedHorizontal);

            if (tempPos.x < minX)
                moveSpeedHorizontal = Mathf.Abs(moveSpeedHorizontal);

            transform.position = tempPos;

            if (moveSpeedHorizontal < 0)
                spriteRenderer.flipX = true;
            else if (moveSpeedHorizontal > 0)
                spriteRenderer.flipX = false;
        }
    }

    void HandleVerticalMovement()
    {
        if (moveVertical)
        {
            tempPos = transform.position;
            tempPos.y += moveSpeedVertical * Time.deltaTime;

            if (tempPos.y > maxY)
                moveSpeedVertical = -Mathf.Abs(moveSpeedVertical);

            if (tempPos.y < minY)
                moveSpeedVertical = Mathf.Abs(moveSpeedVertical);

            transform.position = tempPos;
        }
    }
}