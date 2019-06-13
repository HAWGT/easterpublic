using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Shield" || collision.gameObject.name == "GroundCheck"){
            if (collision.gameObject.name == "Player") collision.gameObject.GetComponent<PlayerScript>().Die();
            return;
        }
        Destroy(collision.gameObject);
    }
}
