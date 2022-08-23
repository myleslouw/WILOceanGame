using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRudder : MonoBehaviour
{

    //this was implemented from "How to make a parent follow a child in unity"
    //https://www.youtube.com/watch?v=NFBEgKd1mSc


    //used to make the parent of the gamobject rotate and move around a differnet pivot point

    public Transform follow = null;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(follow.position.x, follow.position.y , follow.position.z);
    }
}
