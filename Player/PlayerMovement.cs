using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce;

    private float camRayLength = 100f;
    private int floorMask;
    [SerializeField] private float k = 0.1f;
    [Range(0f,1f)] [SerializeField] private float turnDeadZone = 0.01f; 
    float h, v;
    Animator animator;

    // [SerializeField] private Transform _lookAt; 

    private Rigidbody rb;

    [SerializeField] private float distToGround = 0.5f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("floor");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        if(IsWalking()) animator.SetBool("isWalking", true); else animator.SetBool("isWalking", false);
        // Turn();
        TurnJ();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            Vector3 movement = new Vector3(h, 0f, v);
            movement = movement.normalized;

            rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
        }
    }

    void TurnJ()
    {

        float h = Input.GetAxis("JHorizontal");
        float v = Input.GetAxis("JVertical");
        print($"h: {h}, v: {v}");
        // if(h != 0 || v != 0){
        // Vector3 lookAtVector = new Vector3(k+h+this.transform.position.x, 0f, k+v+this.transform.position.z);
        //_lookAt.localPosition = lookAtVector*k;
        //_lookAt.position = lookAtVector; causing the player to rotate along x, y axies.
        // _lookAt.position = lookAtVector;
        // transform.LookAt(_lookAt);
        // Quaternion newRot = Quaternion.LookRotation(lookAtVector);
        // rb.MoveRotation(newRot);    
        // }

        Vector3 y = new Vector3(h, 0f, v);
        if (y.magnitude > turnDeadZone)
        {
            Quaternion newRot = Quaternion.LookRotation(y);
            rb.MoveRotation(newRot);
        }

    }


    void Turn()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            rb.MoveRotation(newRotation);
        }
    }

    public bool IsWalking()
    {
        return (h != 0f || v != 0f);
    }

    /*
    * private void OnDrawGizmos()
    {
        if (IsGrounded())
        {
            Debug.DrawRay(transform.position, Vector3.down * distToGround, Color.green);
        }
        else
            Debug.DrawRay(transform.position, Vector3.down * distToGround, Color.red);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    bool IsGrounded() => Physics.Raycast(transform.position, Vector3.down, distToGround); 
    */
}
