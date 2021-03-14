using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int length = 1;

    [SerializeField] private GameObject explosion;

    [SerializeField] private LayerMask layer;

    [SerializeField] private int lengthUp, lengthDown, lengthRight, lengthLeft;

    private void Awake()
    {
        lengthUp = length;
        lengthDown = length;
        lengthRight = length;
        lengthLeft = length;
    }

    public void OnInitWeapon(int length,float waitTimes)
    {

        this.length = length;

        GetComponent<Animator>().SetFloat("CountBomb", 1/waitTimes);
        DetectAround();

    }

    public void DetectAround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, length, ~layer);

        // If it hits something...
        if (hit.collider != null)
        {
            if(hit.collider.CompareTag(ConstVariable.TAG_BREAKABLE_BLOCK) || hit.collider.CompareTag(ConstVariable.TAG_UNBREAKABLE_BLOCK))
                lengthLeft = (int)(Vector2.Distance(transform.position, hit.collider.transform.position));
        }
        else
        {
            lengthLeft = length;
        }

        hit = Physics2D.Raycast(transform.position, Vector2.right, length, ~layer);

        // If it hits something...
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag(ConstVariable.TAG_BREAKABLE_BLOCK) || hit.collider.CompareTag(ConstVariable.TAG_UNBREAKABLE_BLOCK))
                lengthRight = (int)(Vector2.Distance(transform.position, hit.collider.transform.position));
        }
        else
        {
            lengthRight = length;
        }

        hit = Physics2D.Raycast(transform.position, Vector2.up, length, ~layer);

        // If it hits something...
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag(ConstVariable.TAG_BREAKABLE_BLOCK) || hit.collider.CompareTag(ConstVariable.TAG_UNBREAKABLE_BLOCK))
                lengthUp = (int)(Vector2.Distance(transform.position, hit.collider.transform.position));
        }
        else
        {
            lengthUp = length;
        }


        hit = Physics2D.Raycast(transform.position, Vector2.down, length, ~layer);

        // If it hits something...
        if (hit.collider != null)
        {
            if(hit.collider.CompareTag(ConstVariable.TAG_BREAKABLE_BLOCK) || hit.collider.CompareTag(ConstVariable.TAG_UNBREAKABLE_BLOCK))
                lengthDown = (int)(Vector2.Distance(transform.position, hit.collider.transform.position));
        }
        else
        {
            lengthDown = length;
        }
    }

    public void Fire()
    {

        if(explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        for(int i = 1; i <= length; i++)
        {
            if(i <= lengthUp)
                Instantiate(explosion, transform.position + Vector3.up * i, Quaternion.identity);

            if (i <= lengthDown)
                Instantiate(explosion, transform.position + Vector3.down * i, Quaternion.identity);

            if (i <= lengthRight)
                Instantiate(explosion, transform.position + Vector3.right * i, Quaternion.identity);

            if (i <= lengthLeft)
                Instantiate(explosion, transform.position + Vector3.left * i, Quaternion.identity);
        }

        Destroy(gameObject);
    } 

}
