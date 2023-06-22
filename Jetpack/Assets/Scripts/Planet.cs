using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private SFX sfx;
    private TriggerEast triggerEast;
    private TriggerNorth triggerNorth;
    private TriggerSouth triggerSouth;
    private TriggerWest triggerWest;
    private Rigidbody2D myRb;
    private Logic logic;
    private DistanceJoint2D tether;
    //private Rigidbody2D otherRb;
    //public float gravityConst = 5;
    //private float gravitationalForce;
    public float rotateForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        sfx = GameObject.Find("SFX Player").GetComponent<SFX>();
        logic = GameObject.Find("Logic").GetComponent<Logic>();
        myRb = gameObject.GetComponent<Rigidbody2D>();
        tether = GameObject.Find("Player").GetComponent<DistanceJoint2D>();
        triggerNorth = transform.parent.transform.Find("Trigger North").GetComponent<TriggerNorth>();
        triggerEast = transform.parent.transform.Find("Trigger East").GetComponent<TriggerEast>();
        triggerSouth = transform.parent.transform.Find("Trigger South").GetComponent<TriggerSouth>();
        triggerWest = transform.parent.transform.Find("Trigger West").GetComponent<TriggerWest>();

        SetRotation();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.GameOverScreen.activeInHierarchy)
        {
            RotatedAround();
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D collision) // gravity
    {
        Vector2 direction;
        if (collision.gameObject.layer == 3) // collides with player
        {
            otherRb = collision.gameObject.GetComponent<Rigidbody2D>();
            gravitationalForce = (gravityConst * myRb.mass * otherRb.mass) / Mathf.Pow(Vector2.Distance(transform.position, collision.gameObject.transform.position), 2); // calculates gravity

            direction = (myRb.transform.position - otherRb.transform.position).normalized; // gets direction of force

            otherRb.AddForce(direction * gravitationalForce); //applies gravity force
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
            logic.GameOver();
        }
    }

    private void SetRotation()
    {
        myRb.angularVelocity += rotateForce * Mathf.Sign(Random.Range(-1, 1));
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    private void RotatedAround()
    {
        if(tether != null)
        {
            if (!tether.enabled && triggerNorth.hitNorth == true && triggerSouth.hitSouth == true && triggerEast.hitEast == true && triggerWest.hitWest == true)
            {
                sfx.playAsteroidBoom();
                logic.IncreaseScore();
                Destroy(gameObject);
            }
        }
    }

    
}
