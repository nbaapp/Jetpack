using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SFX sfx;
    public Logic Logic;
    public GameObject jetpackBeam;
    //public GameObject planet;
    public DistanceJoint2D tether;
    public Rigidbody2D rb;
    private PlayerInputActions playerInputActions;
    public Camera mainCamera;
    private GameObject[] Planets;
    private GameObject nearestPlanet;

    public float jetpackForce = 10;
    public float speedCap = 100;
    public float beamOff = 10;
    public float rotateSpeed = 10;
    public float speed;
    public float maxFuel = 50;
    public float fuelLeft;
    public float swingBoost = 10;
    public float distanceThreshold = 30;

    private float distanceToTarget;
    private float distance;
    private float nearestDistance;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.Find("Logic").GetComponent<Logic>();
        fuelLeft = maxFuel;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;
    }

    private void FixedUpdate()
    {
        KeyboardWobble(); // rotates player
        //MouseWobble();
        Jetpack(); // moves player
        Lock(); //attatches tether to closest planet
    }

    private void Jetpack()
    {
        if (playerInputActions.Player.Jetpack.inProgress && fuelLeft > 0)
        {
            if(rb.velocity.x < speedCap && rb.velocity.y < speedCap)
            {
                rb.AddRelativeForce(new Vector3(0, 1, 0) * jetpackForce);
            }
            if (GameObject.FindWithTag("Exhaust") == null)
            {
                Instantiate(jetpackBeam, transform);
                sfx.playJetpackSound();
            }
            Logic.DecreaseFuel();
        }
        else
        {
            if (GameObject.FindWithTag("Exhaust") != null)
            {
                sfx.stopJetpackSound();
                Destroy(GameObject.FindWithTag("Exhaust"));
            }
        }
    }

  //  private void MouseWobble()
  //  {
       // Vector2 inputVector = playerInputActions.Player.Wobble.ReadValue<Vector2>();
        //Vector3 worldPos = mainCamera.ScreenToWorldPoint(inputVector);
       // transform.up = new Vector3(worldPos.x, worldPos.y, 0) - transform.position;
        //Debug.Log(inputVector.x + "x " + inputVector.y + "y");
 //   }

    private void KeyboardWobble()
    {
        Vector2 inputVector = playerInputActions.Player.Wobble.ReadValue<Vector2>();
        rb.angularVelocity = -inputVector.x * rotateSpeed;
    }
    private void Lock()
    {
        Vector2 forward;
        forward = rb.velocity.normalized;
        if (playerInputActions.Player.Lock.inProgress)
        {
            if (tether.enabled == false)
            {
                findClosestPlanet();
                if (nearestDistance <= distanceThreshold)
                {
                    tether.enabled = true;
                    distanceToTarget = Vector2.Distance(transform.position, nearestPlanet.transform.position);
                    tether.distance = distanceToTarget;
                    tether.connectedBody = nearestPlanet.GetComponent<Rigidbody2D>();
                }
            }
            if(tether.enabled == true)
            {
                rb.velocity = rb.velocity + new Vector2(forward.x, forward.y).normalized * swingBoost;
            }
        }
        else
        {
            tether.enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.angularVelocity = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.angularVelocity = 0;
    }

    private void findClosestPlanet()
    {
        Planets = GameObject.FindGameObjectsWithTag("Planet");

        for(int i = 0; i < Planets.Length; i++)
        {
            distance = Vector2.Distance(transform.position, Planets[i].transform.position);
            if(i == 0)
            {
                nearestPlanet = Planets[i];
                nearestDistance = distance;
            }
            if (distance < nearestDistance)
            {
                nearestPlanet = Planets[i];
                nearestDistance = distance;
            }
        }
    }
   
}
