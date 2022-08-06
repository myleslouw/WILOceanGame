using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    public MeshRenderer Mesh;
    Color startColour;
    Color endColour = new Color(0.199f, 0.453f, 0.271f, 1);

    private void Awake()
    {
        startColour = Mesh.material.GetColor("BaseColour");
        print("blue: " + startColour.ToString());
    }
    // Start is called before the first frame update
    void Start()
    {
        Mesh.material.SetColor("BaseColour", endColour);
        print("green: " + endColour.ToString());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Input");
            Mesh.material.SetColor("BaseColour", startColour);
        }
    }

}
