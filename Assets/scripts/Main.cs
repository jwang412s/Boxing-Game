using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHead;
    public GameObject GUI;
    private GameObject instantiatedGui;
    public GameObject sceneGUI;
    public List<GameObject> ListOfObstacles;
    public List<GameObject> totalListOfObstacles;
    public int spawnPoint; 
    public GameObject b;
    public static GameObject tempB;
    public int counter;
    public SteamVR_Action_Boolean input;

    // Start is called before the first frame update
    void Start()
    {
        toList();
        counter = totalListOfObstacles.Count;
        instantiatedGui = Instantiate(GUI);
        instantiatedGui.transform.position = new Vector3(-1.6f, 1.7f, 5);
        sceneGUI = instantiatedGui;
        

    }

    // Update is called once per frame
    void Update()
    {
        start();

        if (counter < 1) {
                SceneManager.LoadScene("end");
        }

        if (sceneGUI == null) {
            if (b == null) {
            b = spawn();
            }

            if (b.transform.position.z < -3) {
            DestroyImmediate(tempB);
            }
 
            b.transform.position += 4 * Time.deltaTime * new Vector3(0, 0, -0.5f);
        }
        
    }

    private void toList() {
        foreach (GameObject n in ListOfObstacles) {
            for (int i = 0; i < 15; i++) {
                totalListOfObstacles.Add(n);
            }
        }
    }

    public GameObject spawn() {
        tempB = Instantiate(totalListOfObstacles[counter - 1]);
        tempB.transform.position = new Vector3(0, playerHead.transform.position.y, spawnPoint);
        counter--;
        return tempB;
    }

    private void start() {
        if (input.stateDown && sceneGUI != null) {
            DestroyImmediate(instantiatedGui);
        }
    }



}

