using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollutant : MonoBehaviour
{
    public PollutantType.type pollutantType;
    public int pollutantReward;

    private void Awake()
    {
        pollutantType = SetType();
        pollutantReward = SetReward(pollutantType);
    }
    void Start()
    {
        pollutantType = SetType();
        pollutantReward = SetReward(pollutantType);
    }

    //randoms a type
    PollutantType.type SetType()
    {
        System.Random rndm = new System.Random();
        return (PollutantType.type)rndm.Next(0, 3);
    }

    //sets a reward based on the type
    int SetReward(PollutantType.type type)
    {
        if (type == PollutantType.type.Glass)
        {
            return 1;
        }
        else if (type == PollutantType.type.Plastic)
        {
            return 2;
        }
        else   //general waste
        {
            return 3;
        }
    }
}
