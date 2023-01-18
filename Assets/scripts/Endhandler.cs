using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Endhandler : MonoBehaviour
{
    public SteamVR_Action_Boolean input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(input.stateDown) {
            SceneManager.LoadScene("Main");
        }
    }
}
