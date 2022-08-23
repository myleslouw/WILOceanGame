using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Pollutant", menuName ="CustomItems")]
public class PollutantObject : ScriptableObject
{

    //scriptable object for every pollutant
    public PollutantType.type pollutantType;            //the type of the pollutant (G, P, GW)
    public int pollutantReward;                         //the score reward for this type
    public Vector3 pollutantRotation;                   //its rotation in the water
    public Vector3 startOffset;                         //GW spawns sideways

}
