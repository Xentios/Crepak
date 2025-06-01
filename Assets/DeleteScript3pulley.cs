using UnityEngine;

public class DeleteScript3pulley : MonoBehaviour
{
    [SerializeField]
    private Rigidbody solMass;
    [SerializeField]
    private Rigidbody sagMass;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnGUI()
    {
        // Create a button at position (10, 10) with size (100, 50)
        if (GUI.Button(new Rect(1600, 10, 300, 150), "Push From Right"))
        {
            sagMass.mass++;
        }

        if (GUI.Button(new Rect(10, 10, 300, 150), "Push From Left"))
        {
            solMass.mass++;
        }

        if (GUI.Button(new Rect(810, 1000, 300, 150), "Reset Forces"))
        {
            solMass.mass = 5;
            sagMass.mass = 5;
        }
    }

}
