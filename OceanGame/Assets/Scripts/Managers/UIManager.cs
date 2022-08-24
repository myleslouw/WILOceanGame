using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text glassCount, plasticCount, generalWasteCount;

    // Start is called before the first frame update

    private void Start()
    {
        //the listener for the pickup event
        EventManager.OnDelegateEvent IncrementDelegate = IncrementPollutantUI;
        EventManager.OnDelegateEvent ResetDelegate = ResetPollutantUI;
        //EventManager.Instance.AddListener(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, PickupPollutant);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.PICKUP_UI, IncrementDelegate);
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.RECYCLE_UI, ResetDelegate);

    }

    private void IncrementPollutantUI(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //this is be exectured on event trigger,   there a few components it can access ^^
        //gets the pollutant object to see what type to increment

        Pollutant pickedUpObj = (Pollutant)Params;       //gets the object sent and casts it so we can use it
        UpdatePollutantCount(pickedUpObj.pollutantObj.pollutantType);
    }

    private void ResetPollutantUI(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        PollutantRecycler recycler = (PollutantRecycler)Params;
        UpdatePollutantCount(recycler.recyclerType);
    }

    private void UpdatePollutantCount(PollutantType.type polObjType)
    {
        //gets the type and updates that UI based on the invetory

        switch (polObjType)
        {
            case PollutantType.type.Glass:
                glassCount.text = Inventory.Instance.invGlassCount.ToString();
                print("UI updated");
                break;

            case PollutantType.type.Plastic:
                plasticCount.text = Inventory.Instance.invPlasticCount.ToString();
                print("UI updated");
                break;

            case PollutantType.type.GeneralWaste:
                generalWasteCount.text = Inventory.Instance.invGeneralWasteCount.ToString();
                print("UI updated");
                break;

            default:
                break;
        }
    }
}
