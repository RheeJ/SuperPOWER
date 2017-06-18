using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
    /// Class Fields
    public float gravity = .3f;
    private Animator anim;
    private SpriteRenderer render;
    private bool isTouchingPlatform = true;
    private Vector3 velocity;

	// Use this for initialization
    void Awake()
    {
        velocity = new Vector3(0f, 0f, 0f);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        /// Character Left Right Movement
        if (Input.GetKey(KeyCode.A))
        {
            render.flipX = true;
            velocity.x = -1f;
            anim.SetBool("playerMove", true);
        }
        else if(Input.GetKey(KeyCode.D)){
            render.flipX = false;
            velocity.x = 1f;
            anim.SetBool("playerMove", true);
        }
        else
        {
            velocity.x = 0f;
            anim.SetBool("playerMove", false);
        }
        /// Character Jump Movement
        if (!isTouchingPlatform)
        {
            velocity.y -= (gravity * Time.deltaTime);
        }
        else
        {
            if (Input.GetKeyDown("w"))
            {
                velocity.y = 2f;
                anim.SetTrigger("playerJump");
                Debug.Log("animation played");
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
