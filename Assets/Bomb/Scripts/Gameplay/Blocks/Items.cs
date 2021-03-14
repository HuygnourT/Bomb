using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{   

    [SerializeField] private EnumVariable.TypeItem typeItem;

    private bool isReceive = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isReceive)
        {
            isReceive = true;
            StatCharacter stat = collision.gameObject.GetComponent<StatCharacter>();

            if(stat != null)
            {
                stat.ChangeStat(typeItem);
            }

            Destroy(gameObject);
        }
    }

}
