using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSouth : MonoBehaviour
{
    public bool hitSouth  = false;
    private DistanceJoint2D tether;

    private void Awake()
    {
        tether = GameObject.Find("Player").GetComponent<DistanceJoint2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tether != null)
        {
            if (tether.enabled)
            {
                if (collision.gameObject.layer == 3 && hitSouth == false)
                {
                    hitSouth = true;
                }
            }
        }
    }
}
