using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCell : MonoBehaviour
{
    private Logic Logic;
    private float timer = 0;
    private float killTimer = 15;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.Find("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        Kill();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Logic.ResetFuel();
            Destroy(gameObject);
        }
    }

    private void Kill()
    {
        timer += Time.deltaTime;
        if (timer >= killTimer)
        {
            Destroy(gameObject);
        }
    }
}
