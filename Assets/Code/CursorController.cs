using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour
{
    public float radius = 1f;
    private float theta;
    // Use this for initialization
    void Start ()
    {
        transform.position = transform.parent.transform.position;
	}

    // Update is called once per frame
    void Update ()
    {
        Vector3 pos = transform.parent.transform.position;
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float MouseX = mouse_pos.x;
        float MouseY = mouse_pos.y;
        theta = Mathf.Atan((MouseY - pos.y) / (MouseX - pos.x));
        if (mouse_pos.x < pos.x)
        {
            pos.x -= radius * Mathf.Cos(theta);
            pos.y -= radius * Mathf.Sin(theta);
        }
        else
        {
            pos.x += radius * Mathf.Cos(theta);
            pos.y += radius * Mathf.Sin(theta);
        }
        transform.position = pos;
	}
}
