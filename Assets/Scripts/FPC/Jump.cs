using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    public event System.Action Jumped;
    public float jumpStrength = 2;
    
    [SerializeField]
    GroundCheck groundCheck;


    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
        {
            rigidbody.AddForce(Vector3.up * 110 * jumpStrength);
            Jumped?.Invoke();
        }
    }
}
