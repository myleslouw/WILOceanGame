using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilestoneManager : MonoBehaviour
{
    public static int currentMilestone { get; set; }
    public static int currentXP { get; set; }
    public static int nextLevelXPRequirement { get; set; }

    public static MilestoneManager Instance
    {
        get { return instance; }
        set { }
    }

    private static MilestoneManager instance = null;

  
    public void AddXP(Pollutant item)
    {
        currentXP += item.pollutantReward;      //get the amount in the inventory

        //if the player has enough xp to level
        if(currentXP >= nextLevelXPRequirement)
        {
            //level up
            currentMilestone++;
        }
    }
}