using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Logic logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.Find("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            logic.GameOver();
        }
    }
}
