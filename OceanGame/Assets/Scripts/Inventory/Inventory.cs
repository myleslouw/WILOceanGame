using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int invGlassCount, invPlasticCount, invGeneralWasteCount;

    public static Inventory Instance
    {
        get { return instance; }
        set { }
    }

    private static Inventory instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    public void ClearInventory()
    {
        //clears amounts at the start
        invGlassCount = 0;
        invPlasticCount = 0;
        invGeneralWasteCount = 0;
    }

    public void AddToInventory(PollutantObject pollutant)
    {
        //increase the amount in inventory 
        switch (pollutant.pollutantType)
        {
            case PollutantType.type.Glass:
                invGlassCount++;
                break;
            case PollutantType.type.Plastic:
                invPlasticCount++;
                break;
            case PollutantType.type.GeneralWaste:
                invGeneralWasteCount++;
                break;
            default:
                break;
        }

        //triggers the event to update UI
        EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, this, pollutant);
    }

    //sets that type to 0 in the inventory and ssend xp to milestone
    public void RecycleType(Pollutant pollutant)
    {
        switch (pollutant.pollutantObj.pollutantType)
        {
            case PollutantType.type.Glass:
                print("Recycling Glass...");
                invGlassCount = 0;
                MilestoneManager.Instance.AddXP(pollutant.pollutantObj);
                break;

            case PollutantType.type.Plastic:
                print("Recycling Plastic...");
                invPlasticCount = 0;
                MilestoneManager.Instance.AddXP(pollutant.pollutantObj);
                break;

            case PollutantType.type.GeneralWaste:
                print("Recycling General Waste...");
                invGeneralWasteCount = 0;
                MilestoneManager.Instance.AddXP(pollutant.pollutantObj);
                break;

            default:
                break;
        }
    }
}
