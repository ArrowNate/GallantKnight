using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayRun(int run)
    {
        animator.SetInteger(TagManager.RUN_ANIMATION_PARAM, run);
    }

    public void ChangeFacingDirection(int direction)
    {
        if (direction > 0)
            spriteRenderer.flipX = false;
        else if (direction < 0)
            spriteRenderer.flipX = true;
    }
}