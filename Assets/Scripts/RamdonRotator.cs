using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdonRotator : MonoBehaviour {
    [Header("Velocidad Rotacion Asteroide")]
    public float tumble;
    
    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {


        rig.angularVelocity = Random.insideUnitSphere * tumble; 

		
	}
	
	
}
