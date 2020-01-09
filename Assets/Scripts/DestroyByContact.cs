using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject playerexplotion;
    public GameObject explotion;
    private GameController gamecontroller; // esto llama el metodo para sumar puntos que esta en gamecontroller
    [Header("Valor de puntos al destruirse este objeto")]
    public int scorevalue;


    private void Start() // esto asigna el objeto 
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gamecontroller = gameControllerObject.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;

        if (explotion != null)
        {
            Instantiate(explotion, transform.position, transform.rotation);
        }
                   

        if (other.CompareTag("Player"))
        {
            Instantiate(playerexplotion, other.transform.position, other.transform.rotation);
            gamecontroller.GameOver(); // esto llama al texto game over
        }
        gamecontroller.AddScore(scorevalue); // esto llama el metodo para sumar puntos que esta en gamecontroller
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
