using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] EnumVariable.TypeBrick typeBrick;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ConstVariable.TAG_BOMB_EXPLOSION) && typeBrick == EnumVariable.TypeBrick.SoftBrick)
        {
            if (animator != null)
            {
                Debug.Log("Destroy");
                animator.Play(ConstVariable.TRIGGER_DESTROY_BLOCK);
            }
        }
    }
    
}
