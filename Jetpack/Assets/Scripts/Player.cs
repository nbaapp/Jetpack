using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject jetpackBeam;
    public Rigidbody2D rb;
    private PlayerInputActions playerInputActions;
    public Camera mainCamera;

    public float jetpackForce = 10;
    public float speedCap = 100;
    public float beamOff = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Enable();
        //playerInputActions.Player.Jetpack.performed += Jetpack;


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Wobble();
        Jetpack();
    }

    private void Jetpack()
    {
        if (playerInputActions.Player.Jetpack.inProgress)
        {
            if(rb.velocity.x < speedCap && rb.velocity.y < speedCap)
            {
                rb.AddRelativeForce(new Vector3(0, 1, 0) * jetpackForce);
            }
            if (GameObject.FindWithTag("Exhaust") == null)
            {
                Instantiate(jetpackBeam, transform);
            }

        }
        else
        {
            if (GameObject.FindWithTag("Exhaust") != null)
            {
                Destroy(GameObject.FindWithTag("Exhaust"));
            }
        }
    }

    private void Wobble()
    {
        Vector2 inputVector = playerInputActions.Player.Wobble.ReadValue<Vector2>();
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(inputVector);
        //transform.LookAt(worldPos);
        transform.up = new Vector3(worldPos.x, worldPos.y, 0) - transform.position;
        //Debug.Log(inputVector.x + "x " + inputVector.y + "y");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.angularVelocity = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.angularVelocity = 0;
    }
}
