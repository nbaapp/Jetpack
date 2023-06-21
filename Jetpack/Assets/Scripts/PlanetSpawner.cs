using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public Logic Logic;
    public GameObject Planet;
    public GameObject Player;
    public GameObject FuelCell;
    public float spawnDist = 10;
    public float planetSpawnTime = 5;
    public float fuelSpawnTime = 10;
    private float planetTimer = 0;
    private float fuelTimer = 0;
    private float yMax = 21;
    private float yMin = -24;
    public float speedIncrement = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.Find("Logic").GetComponent<Logic>();
        Instantiate(Planet, new Vector3(transform.position.x, Random.Range(yMin, yMax), Player.transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlanet();
        SpawnFuel();
    }

    private void SpawnPlanet()
    {
        planetTimer += Time.deltaTime;
        if (planetTimer >= planetSpawnTime)
        {
            Instantiate(Planet, new Vector3(transform.position.x + spawnDist, Random.Range(yMin, yMax), Player.transform.position.z), Quaternion.identity);
            planetTimer = 0;
            Logic.IncreaseScore();
        }
    }

    private void SpawnFuel()
    {
        fuelTimer += Time.deltaTime;
        if (fuelTimer >= fuelSpawnTime)
        {
            Instantiate(FuelCell, new Vector3(transform.position.x + spawnDist, Random.Range(yMin, yMax), Player.transform.position.z), Quaternion.identity);
            fuelTimer = 0;
        }
    }
}
