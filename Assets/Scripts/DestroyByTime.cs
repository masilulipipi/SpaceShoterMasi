using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {


    [Header("Destruye el objeto de pantalla")] 
    public float destroybytime;   // Destruye el objeto de pantalla


    void Start () {

        Destroy(gameObject, destroybytime);
        
		
	}
	
	
}
