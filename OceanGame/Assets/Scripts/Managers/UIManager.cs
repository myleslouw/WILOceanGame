using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text glassCount, plasticCount, generalWasteCount;


    private void OnEnable()
    {
        //the listener for the pickup event
        EventManager.OnDelegateEvent PickupPollutant = PickupPollutantEntry;
        EventManager.Instance.AddListener(EventManager.EVENT_TYPE.POLLUTANT_PICKUP, PickupPollutant);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PickupPollutantEntry(EventManager.EVENT_TYPE eventType, Component sender, object Params = null)
    {
        //this is be exectured on event trigger,   there a few components it can access ^^
        //gets the pollutants scriptable object to see what type to increment

        PollutantObject pickedUpObj = (PollutantObject)Params;       //gets the object sent and casts it so we can use it
        IncrementScore(pickedUpObj);
    }

    private void IncrementScore(PollutantObject polObj)
    {
        switch (polObj.pollutantType)
        {
            case PollutantType.type.Glass:
                glassCount.text = Inventory.Instance.invGlassCount.ToString();
                break;

            case PollutantType.type.Plastic:
                plasticCount.text = Inventory.Instance.invPlasticCount.ToString();
                break;

            case PollutantType.type.GeneralWaste:
                generalWasteCount.text = Inventory.Instance.invGeneralWasteCount.ToString();
                break;

            default:
                break;
        }
    }
}
