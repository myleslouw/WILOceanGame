using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MilestoneManager milestoneManager;

    // Start is called before the first frame update
    void Start()
    {
        milestoneManager = GetComponent<MilestoneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
