using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static int GlassCount, PlasticCount, GeneralWasteCount;

    public static Inventory Instance
    {
        get { return instance; }
        set { }
    }

    private static Inventory instance = null;

    public static void ClearInventory()
    {
        //clears amounts at the start
        GlassCount = 0;
        PlasticCount = 0;
        GeneralWasteCount = 0;
    }

    public static void AddToInventory(Pollutant pollutant)
    {
        switch (pollutant.pollutantType)
        {
            case PollutantType.type.Glass:
                GlassCount++;
                break;
            case PollutantType.type.Plastic:
                PlasticCount++;
                break;
            case PollutantType.type.GeneralWaste:
                GeneralWasteCount++;
                break;
            default:
                break;
        }
    }

    //sets that type to 0 in the inventory and ssend xp to milestone
    public static void RecycleType(Pollutant pollutant)
    {
        switch (pollutant.pollutantType)
        {
            case PollutantType.type.Glass:
                print("Recycling Glass...");
                GlassCount = 0;
                MilestoneManager.Instance.AddXP(pollutant);
                break;

            case PollutantType.type.Plastic:
                print("Recycling Plastic...");
                PlasticCount = 0;
                MilestoneManager.Instance.AddXP(pollutant);
                break;

            case PollutantType.type.GeneralWaste:
                print("Recycling General Waste...");
                GeneralWasteCount = 0;
                MilestoneManager.Instance.AddXP(pollutant);
                break;

            default:
                break;
        }
    }
}
