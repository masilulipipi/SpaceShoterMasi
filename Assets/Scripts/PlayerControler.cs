using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]  // esto hace que una clase se vea en el inspeddtor de unity
public class Boundary  // esta es una clase para poder acceder a ella desde cualquier lado.
{
    public float xMin, xMax, zMin, zMax; // esto es para los limites que la nave no se pase del escenario
}

public class PlayerControler : MonoBehaviour
{
    private Rigidbody rig;

    [Header("Movements")]
    public float speed; // variable para la velocidad de movimieto de la navesita
    public Boundary boundary;  // esta es una clase para poder acceder a ella desde cualquier lado.
    public float tilt;  // esto es para el desplasamiento laterar de rotacion
    public float tilt2;

    [Header("Shooting")]
    public GameObject shot;
    public Transform shotSpawn;
   // public Transform shotSpawn2;
    public float firerate;
    private float nextfire;
        
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
          //  Instantiate(shot, shotSpawn2.position, Quaternion.identity);
        }
    }

   

    // Use this for initialization
    void Awake ()
    {
        rig = GetComponent<Rigidbody>();
	}


    void Start()
    {
        UpdateBoundary();
    }

    void UpdateBoundary()
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();
        boundary.xMin = -half.x + 0.7f;
        boundary.xMax = half.x - 0.7f;
        boundary.zMin = -half.y + 6f;
        boundary.zMax = half.y - 2f;
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        // esto marca el movimiento de la nave 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");        

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rig.velocity = movement * speed;

        // esto es para los limites que la nave no se pase del escenario 
        //y a las variables de la clase se acdcede con su nombre mas el punto.

        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax),  // mov de X
            0f, // mov de y que no se usa 
            Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax)); // mov de Z 
         
        // esto es para el desplasamiento lateral de rotacion

        // rig.rotation = Quaternion.Euler(rig.velocity.z * tilt2, 0f, rig.velocity.x * -tilt); // original que anda 
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);


    }
}
