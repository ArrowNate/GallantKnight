using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingSpike : MonoBehaviour
{
    [SerializeField] LayerMask collisionLayer;

    private Rigidbody2D sRB;
    private RaycastHit2D playerCast;

    private bool collidedWitPlayer;

    private void Awake()
    {
        sRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckForPlayerCollision();
    }

    void CheckForPlayerCollision()
    {
        if (collidedWitPlayer) return;

        playerCast = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, collisionLayer);

        if (playerCast.collider != null)
        {
            collidedWitPlayer = true;
            sRB.gravityScale = 10f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG)) Destroy(collision.gameObject);
    }
}