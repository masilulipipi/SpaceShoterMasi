using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorArranca : MonoBehaviour {


    public GameObject motorarranca;

   /* private void OnGUI()
    {
        motorarranca.SetActive(true);
    }
    */
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Vertical"))
        {
            motorarranca.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) == false)
        { 
            motorarranca.SetActive(false);
        }
        
            
        


    }
}
