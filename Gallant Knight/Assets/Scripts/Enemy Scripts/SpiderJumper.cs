using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float minWaitTime = 2f, maxWaitTime = 5f;
    [SerializeField] private float minJumpForce = 5f, maxJumpForce = 10f;

    private float jumpTimer;

    private Animator animator;
    private Rigidbody2D sJRB;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sJRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Time.time > jumpTimer) Jump();

        if (sJRB.velocity.y == 0f) animator.SetBool(TagManager.JUMP_ANIMATION_PARAM, false);
    }

    void Jump()
    {
        jumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);

        jumpForce = Random.Range(minJumpForce, maxJumpForce);

        sJRB.velocity = new Vector2(0f, jumpForce);

        animator.SetBool(TagManager.JUMP_ANIMATION_PARAM, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG)) Destroy(collision.gameObject);
    }
}
