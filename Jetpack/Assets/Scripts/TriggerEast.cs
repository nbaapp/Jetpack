using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEast : MonoBehaviour
{
    public bool hitEast = false;
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
                if (collision.gameObject.layer == 3 && hitEast == false)
                {
                    hitEast = true;
                }
            }
        }
    }
}
