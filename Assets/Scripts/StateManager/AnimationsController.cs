using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    Animator animator;
    MobManager mobManager;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        mobManager = GetComponentInParent<MobManager>();
    }

    private void Update()
    {
        animator.Play(mobManager.stateManager.GetAnimationName());
    }
}
