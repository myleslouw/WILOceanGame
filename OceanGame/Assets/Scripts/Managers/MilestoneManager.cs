using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilestoneManager : MonoBehaviour
{
    public int currentMilestone;
    public int currentXP;
    public int nextLevelXPRequirement;

    public static MilestoneManager Instance
    {
        get { return instance; }
        set { }
    }

    private static MilestoneManager instance = null;

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

    private void Start()
    {
        currentXP = 0;
        currentMilestone = 1;
        nextLevelXPRequirement = 15;

        EventManager.OnDelegateEvent AddXPDelegate = AddXP;
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.ADD_XP, AddXPDelegate);
    }
    public void AddXP(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        PollutantRecycler recycler = (PollutantRecycler)Params;
        print("CALLED: " + Inventory.Instance.PollutantInventory[recycler.recyclerType]);

        //adds the amount in the players inventory as XP
        currentXP += 1 * Inventory.Instance.PollutantInventory[recycler.recyclerType];

        //if the player has enough xp to level
        if(currentXP >= nextLevelXPRequirement)
        {
            //level up
            currentMilestone++;
            print("Leveled UP");
        }

        //triggers the event to change the UI back to 0
        EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.RECYCLE_UI, this, recycler);
    }
}
