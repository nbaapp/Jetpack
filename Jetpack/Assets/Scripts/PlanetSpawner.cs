using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public Logic Logic;
    private PlanetObject planets;
    private FuelCell fuelCells;
    public GameObject Planet;
    public GameObject Player;
    public GameObject FuelCell;
    public float spawnDist = 10;
    public float planetSpawnTime = 5;
    public float fuelSpawnTime = 10;
    private float planetTimer = 0;
    private float fuelTimer = 0;
    public float yMax = 21;
    public float yMin = -24;
    public float speedIncrement = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        planets = Planet.GetComponent<PlanetObject>();
        fuelCells = FuelCell.GetComponent<FuelCell>();
        Logic = GameObject.Find("Logic").GetComponent<Logic>();

        planets.moveSpeed = planets.initialMoveSpeed;
        fuelCells.moveSpeed = fuelCells.initialMoveSpeed;

        Instantiate(Planet, new Vector3(transform.position.x + spawnDist, Random.Range(yMin, yMax), Player.transform.position.z), Quaternion.identity);
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
            planets.moveSpeed++;
            fuelCells.moveSpeed++;
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
