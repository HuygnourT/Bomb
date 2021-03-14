using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisbleComponent : MonoBehaviour
{
    public void DisableAnimator()
    {
        Animator animator = GetComponent<Animator>();

        if (animator != null)
            animator.enabled = false;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
