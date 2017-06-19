using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour
{
    public float active_time = 2f;
    public Vector3 velocity { get; set; }
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += (2f * velocity) * Time.deltaTime;
        if (active_time <= 0f)
        {
            Destroy(gameObject);
        }
        active_time -= Time.deltaTime;
    }
}
