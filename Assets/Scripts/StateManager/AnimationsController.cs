using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    Animator animator;
    MobManager mobManager;

    private void Awake()
    {
        this.animator = this.GetComponentInParent<Animator>();
        this.mobManager = this.GetComponentInParent<MobManager>();
    }

    private void Update()
    {
        this.animator.Play(this.mobManager.stateManager.GetAnimationName());
        
    }
}
