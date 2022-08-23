using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutantManager : MonoBehaviour
{
    //used for creating and storing pollutants
    //when creating it randoms a pollutant type and gives it a reward for recycling based on the type
    [SerializeField] Pollutant[] PollutantOptions = new Pollutant[2];

    [SerializeField] List<Pollutant> pollutants = new List<Pollutant>();
    const float WATERHEIGHT = 4.03f;
    const int SpawnSpace = 20;

    Vector3[] positions;
    System.Random rand = new System.Random();

    void Start()
    {
        positions = new Vector3[] { new Vector3(SpawnSpace/2, WATERHEIGHT, SpawnSpace/2), new Vector3(-SpawnSpace/2, WATERHEIGHT, -SpawnSpace/3), new Vector3(SpawnSpace/2, WATERHEIGHT, -SpawnSpace/2), new Vector3(-SpawnSpace/3, WATERHEIGHT, SpawnSpace/2) };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < positions.Length; i++)
            {
                SpawnPollutant(i);
            }
        }
    }

    public void SpawnPollutant(int index)
    {
        //creates a pollutant
        Pollutant spawnedObj = new Pollutant();
        pollutants.Add(spawnedObj);
        spawnedObj = Instantiate(PollutantOptions[rand.Next(0,3)], positions[index], Quaternion.identity);
    }

}
