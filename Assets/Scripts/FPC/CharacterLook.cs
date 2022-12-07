using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float smoothing = 1f;
    public float sensitivity = 2;
    
    Vector2 frameVelocity;
    Vector2 velocity;

    void Reset()
    {
        character = GetComponentInParent<CharacterMovement>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // velocity
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);
        velocity += frameVelocity;
        

        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
    }
}
