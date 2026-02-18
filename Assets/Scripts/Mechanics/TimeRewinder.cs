using UnityEngine;
using UnityEngine.InputSystem;

public class TimeRewinder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int maxFrames = 300;
    [SerializeField] public static bool isRewinding = false;

    private CircularBuffer<Vector3> positionHistory;
    private CircularBuffer<Quaternion> rotationHistory;
    private CircularBuffer<Vector3> scaleHistory;
    private CircularBuffer<Vector2> linearVelocityHistory;

    private Rigidbody2D rBody;

    private void Awake()
    {
        positionHistory = new CircularBuffer<Vector3>(maxFrames); // instantiate, pass in frames
        rotationHistory = new CircularBuffer<Quaternion>(maxFrames);
        scaleHistory = new CircularBuffer<Vector3>(maxFrames);
       
        // calls constructor and passes in maxframes as capacity
    }

    // Handle rewind action from input syystem
    public void OnRewind(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isRewinding = true;
            Debug.Log("Rewind Performed!");
        }
        else if (context.canceled)
        {
            isRewinding = false;
            Debug.Log("Rewind Cancelled!");
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    //Record
    private void Record()
    {
        positionHistory.Push(transform.position);
        rotationHistory.Push(transform.rotation);
        scaleHistory.Push(transform.localScale);
        
    }

    //Rewind
    private void Rewind()
    {
        if(positionHistory.Count > 0) // Make sure buffer has something in it. Buffers are parallel and will have the same count
        {
            transform.position = positionHistory.Pop(); // assign position to stored position
            transform.rotation = rotationHistory.Pop();

            Vector3 tempLocalScale = scaleHistory.Pop();
            transform.localScale = new Vector3(tempLocalScale.x * -1, tempLocalScale.y, tempLocalScale.z);
        }
        else
        {
            isRewinding = false; // Stop if we run out of items to process
        }
    }

}
