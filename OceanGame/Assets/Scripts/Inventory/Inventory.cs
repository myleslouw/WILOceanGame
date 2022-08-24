using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //the amount in the inv
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
    private void Start()
    {
        ClearInventory();
        //creates the delegates and the methods to it
        EventManager.OnDelegateEvent AddPollutantDelegate = AddToInventory;
        EventManager.OnDelegateEvent RecyclePollutantDelegate = RecycleType;
        //becomes a listener for the POLLUTANT_PICKUP event
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, AddPollutantDelegate);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.RECYCLE_POLLUTANT, RecyclePollutantDelegate);
    }
    public void ClearInventory()
    {
        //clears amounts at the start
        invGlassCount = 0;
        invPlasticCount = 0;
        invGeneralWasteCount = 0;
    }

    public void AddToInventory(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //casts the obj recieved from the event to a pollutant and then increments the count in inv based on type
        Pollutant pickedUpPollutant = (Pollutant)Params;

        print(pickedUpPollutant.ToString());

        //increase the amount in inventory 
        switch (pickedUpPollutant.pollutantObj.pollutantType)
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

        //UI event becuase the UI would pudate before it was added to inv
        EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.PICKUP_UI, this, pickedUpPollutant);
    }

    public void RecycleType(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //gets the type and then sets the inventory count of that type to 0 and then calls UI event
        PollutantRecycler recycler = (PollutantRecycler)Params;

        switch (recycler.recyclerType)
        {
            case PollutantType.type.Glass:
                print("Recycling Glass...");
                invGlassCount = 0;
                break;

            case PollutantType.type.Plastic:
                print("Recycling Plastic...");
                invPlasticCount = 0;
                break;

            case PollutantType.type.GeneralWaste:
                print("Recycling General Waste...");
                invGeneralWasteCount = 0;
                break;

            default:
                break;
        }

        //UI event
        EventManager.Instance.PostEventNotification(EventManager.EVENT_TYPE.RECYCLE_UI, this, recycler);
    }
}
