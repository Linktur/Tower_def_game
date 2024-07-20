using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f; 
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
    }

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        Vector3 direction = Vector3.zero;

        if (Input.GetKey("w"))
        {
            direction += transform.forward;
        }

        if (Input.GetKey("s"))
        {
            direction += -transform.forward;
        }

        if (Input.GetKey("d"))
        {
            direction += transform.right;
        }

        if (Input.GetKey("a"))
        {
            direction += -transform.right;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            direction += transform.up;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            direction += -transform.up;
        }

        rb.velocity = direction * panSpeed;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = rb.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        rb.MovePosition(pos);

        if (Input.GetMouseButton(1)) 
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.Rotate(Vector3.up, mouseX, Space.World);
            transform.Rotate(Vector3.right, -mouseY); 
        }
    }
}
