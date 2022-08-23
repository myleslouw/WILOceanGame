using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollutant : MonoBehaviour
{
    public PollutantObject pollutantObj;        //the pollutant scriptable object
    
    void Start()
    {   //GW must be sideways at start others dont use this
        transform.Rotate(pollutantObj.startOffset);
    }
    private void Update()
    {
        //rotation of the object based on type
        transform.Rotate(pollutantObj.pollutantRotation);
    }
}
