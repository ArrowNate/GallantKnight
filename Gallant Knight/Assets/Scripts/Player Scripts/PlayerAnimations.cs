using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayRun(int run)
    {
        animator.SetInteger(TagManager.RUN_ANIMATION_PARAM, run);
    }
}
