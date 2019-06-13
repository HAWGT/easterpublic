using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleScript : MonoBehaviour
{
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage();
            //SPAWN PARTICLES
            //SOUND
            Destroy(gameObject);
        }
    }
}
