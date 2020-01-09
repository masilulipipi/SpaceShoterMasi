using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EvasiveManuver : MonoBehaviour {


    public float dodge;
    public float smoothing;

    public Vector2 starWait;
    public Vector2 manouverTime;
    public Vector2 manouverWait;
    public Boundary boundary;

    private float targetManouver;
    private Rigidbody rb;
    public float tilt; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start () {
        UpdateBoundary();
        StartCoroutine(Evade());
        

    }

    void UpdateBoundary()
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();
        boundary.xMin = -half.x + 0.9f;
        boundary.xMax = half.x - 0.9f;
        boundary.zMin = 0;//-half.y + 6f;
        boundary.zMax = 0;//half.y - 2f;

    }



    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(starWait.x, starWait.y));
        
        while (true)
        {
            targetManouver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(manouverTime.x, manouverTime.y));
            targetManouver = 0;
            yield return new WaitForSeconds(Random.Range(manouverWait.x, manouverWait.y));
        }
       
    }

	
	void FixedUpdate ()
    {
        float newMauneuver = Mathf.MoveTowards(rb.velocity.x, targetManouver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newMauneuver, 0.0f, rb.velocity.z);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0f, rb.position.z);
        rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -tilt);
    }
}
