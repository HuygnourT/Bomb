using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int length = 1;

    [SerializeField] private GameObject explosion;

    [SerializeField] private LayerMask layer;

    private int lengthTop, lengthBot, lengthRight, lengthLeft;

    public void OnInitWeapon(int length,float waitTimes)
    {

        this.length = length;

        GetComponent<Animator>().SetFloat("CountBomb", 1/waitTimes);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, length, layer);

        // If it hits something...
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject);
        }
    }

    public void Fire()
    {

        if(explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        for(int i = 0; i < length; i++)
        {

        }

        Destroy(gameObject);
    } 

}
