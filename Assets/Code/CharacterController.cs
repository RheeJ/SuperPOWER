using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
    /// <summary>
    /// Class Fields
    /// </summary>
    public float gravity = .3f;
    private bool isTouchingPlatform = true;
    private Vector3 velocity;

	// Use this for initialization
    void Awake()
    {
        velocity = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update () {
        if (!isTouchingPlatform)
        {
            velocity.y -= (gravity * Time.deltaTime);
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                velocity.y = 2f;
            }
        }
        transform.position += velocity * Time.deltaTime;
	}

    internal void OnTriggerEnter2D(Collider2D collision_object)
    {
        var pos = transform.position;
        pos.y = (collision_object.GetComponent<BoxCollider2D>().size.y / 2f) + collision_object.transform.position.y + .5f;
        velocity.y = 0;
        transform.position = pos;
        isTouchingPlatform = true;
    }

    internal void OnTriggerExit2D()
    {
        isTouchingPlatform = false;
    }

}
