using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    public MeshRenderer Mesh;
    Color startColour;
    Color endColour = new Color(0.199f, 0.653f, 0.271f, 1);

    private void Awake()
    {
        startColour = Mesh.material.GetColor("ShallowWater");
        print("blue: " + startColour.ToString());
    }
    // Start is called before the first frame update
    void Start()
    {
        Mesh.material.SetColor("ShallowWater", endColour);
        print("green: " + endColour.ToString());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Mesh.material.SetColor("ShallowWater", startColour);
        }
    }

}
