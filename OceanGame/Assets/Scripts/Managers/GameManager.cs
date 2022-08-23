using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MilestoneManager milestoneManager;
    private PollutantManager pollutantManager;

    // Start is called before the first frame update
    void Start()
    {
        milestoneManager = GetComponent<MilestoneManager>();
        pollutantManager = GetComponent<PollutantManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
