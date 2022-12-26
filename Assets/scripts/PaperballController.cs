using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaperballController : MonoBehaviour
{
    // Declare variables
    public float speed = 10.0f;
    public float rotateSpeed = 200.0f;
    public float throwForce = 800.0f;
    public Transform throwPoint;
    public Vector3 throwDirection;
    public Vector3 currentDrag;
    //public Vector3 lastDrag;

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

        // Throw the paperball  
        if (Input.GetMouseButtonDown(0))
        {
            //lastDrag = Input.mousePosition;
            currentDrag = Input.mousePosition; // z is zero because it's 2D
                                               // project 3d point to screen   
            var throwWindowPoint = Camera.main.WorldToScreenPoint(throwPoint.position);
            throwWindowPoint.z = 0;

            throwDirection = currentDrag - throwWindowPoint;
            throwForce = throwDirection.magnitude;
            throwDirection.z = throwForce;

            throwDirection.Normalize();
        }
        // Check if player pressed the throw button
        if (Input.GetMouseButtonUp(0))
        {
            // Throw the paperball
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(throwDirection * throwForce);
        }
    }


    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    currentDrag = (eventData.position - eventData.pressPosition).normalized;
    //}

    //private DraggedDirection GetDragDirection(Vector3 dragVector)
    //{
    //    float positiveX = Mathf.Abs(dragVector.x);
    //    float positiveY = Mathf.Abs(dragVector.y);
    //    DraggedDirection draggedDir;
    //    if (positiveX > positiveY)
    //    {
    //        draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
    //    }
    //    else
    //    {
    //        draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
    //    }
    //    Debug.Log(draggedDir);
    //    return draggedDir;
    //}
}
