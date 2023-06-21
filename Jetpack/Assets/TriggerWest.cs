using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWest : MonoBehaviour
{
    public bool hitWest = false;
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            hitWest = true;
        }
    }
}