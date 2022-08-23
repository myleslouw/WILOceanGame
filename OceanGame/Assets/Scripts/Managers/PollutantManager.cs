using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutantManager : MonoBehaviour 
{
    //used for creating and storing pollutants
    //when creating it randoms a pollutant type and gives it a reward for recycling based on the type
    public Pollutant pollutantPrefab;
    public Pollutant spawnedObj;
    public List<Pollutant> pollutants = new List<Pollutant>();

    void Start()
    {
        print("initial type: " + pollutantPrefab.pollutantType);
        for (int i = 0; i < 5; i++)
        {
            spawnedObj = CreatePollutant();
            print("spawned: " + spawnedObj.pollutantType);
            pollutants.Add(spawnedObj);
        }

        for (int i = 0; i < pollutants.Count; i++)
        {
            print(pollutants[i].pollutantType);
        }
    }

    public void SpawnPollutant()
    {

    }

    private Pollutant CreatePollutant()
    {
        Vector3 position = new Vector3(0, 0, 0);
        //spawns in a place
        Pollutant newPollutant = Instantiate(pollutantPrefab, position, Quaternion.identity);
        print("in mEthod: " + newPollutant.pollutantType);
        print("Created");
        return newPollutant;
    }
}
