using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    [Header("Disparo Enemigo")]
    public float delay;
    public float fireRate;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        InvokeRepeating("Fire", delay, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
