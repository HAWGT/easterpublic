using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(0, player.GetComponent<PlayerScript>().GetHighestPosition() - 1.5f, -10);
        }
    }
}
