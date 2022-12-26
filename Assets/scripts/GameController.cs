using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject paperball;

    private Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        if (paperball == null)
        {
            throw new System.Exception("Paperball is null");
        }
        origin = paperball.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (paperball.transform.position.y <= 0.2)
            ResetBall();
    }
    // read keyboard input 'r' and then call the appropriate function 
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.type == EventType.KeyDown)
        {
            if (e.keyCode == KeyCode.R)
            {
                Debug.Log("E key pressed pipipi");
                // call the function to reset the ball
                ResetBall();
            }
        }
    }

    // Reset the ball to the origin
    public void ResetBall()
    {
        paperball.transform.position = origin;
        paperball.transform.rotation = Quaternion.identity;
        paperball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        paperball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

}
