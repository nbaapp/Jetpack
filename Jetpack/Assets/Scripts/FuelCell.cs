using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCell : MonoBehaviour
{
    private Logic Logic;
    private Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.Find("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Logic.ResetFuel();
            Destroy(gameObject);
        }
    }
}
