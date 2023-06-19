using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private Rigidbody2D myRb;
    private Rigidbody2D otherRb;
    public float gravityConst = 5;
    private float gravitationalForce;
    // Start is called before the first frame update
    void Start()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector2 direction;
        if (collision.gameObject.layer == 3)
        {
            otherRb = collision.gameObject.GetComponent<Rigidbody2D>();
        }

        gravitationalForce = (gravityConst * myRb.mass * otherRb.mass) / Mathf.Pow(Vector2.Distance(transform.position, collision.gameObject.transform.position), 2);

        direction = (myRb.transform.position - otherRb.transform.position).normalized;

        otherRb.AddForce(direction * gravitationalForce);
    }
}
