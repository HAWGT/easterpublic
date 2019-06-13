using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().PickUpShield();
            Destroy(gameObject);
        }
    }
}
