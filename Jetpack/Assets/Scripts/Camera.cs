using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float cameraSpeed = 10;
    public float speedIncreaseTimer = 10;
    private float timer = 0;
    public float speedIncrement = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * cameraSpeed * Time.deltaTime;
        IncreaseSpeed();
    }

    private void IncreaseSpeed()
    {
        if (timer >= speedIncreaseTimer)
        {
            cameraSpeed += speedIncrement;
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
