using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetObject : MonoBehaviour
{
    public int initialMoveSpeed = 10;
    public int moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
    }
}
