using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperballController : MonoBehaviour
{
    // Declare variables
    public float speed = 10.0f;
    public float rotateSpeed = 200.0f;
    public float throwForce = 1000.0f;
    public Transform throwPoint;

    private void Start()
    {
        throwPoint = this.transform;
    }
    // Update is called once per frame
    void Update()
    {
        // Rotate the paperball
        float rotateAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotateAmount);

        // Move the paperball forward
        float moveAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += transform.right * moveAmount;

        // Check if player pressed the throw button
        if (Input.GetButtonDown("Jump"))
        {
            // Throw the paperball
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(throwPoint.forward * throwForce);
        }
    }
}
