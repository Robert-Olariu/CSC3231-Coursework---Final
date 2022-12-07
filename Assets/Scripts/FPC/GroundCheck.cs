using UnityEngine;

[ExecuteInEditMode]
public class GroundCheck : MonoBehaviour
{
    public event System.Action Grounded;
    public bool isGrounded = true;
    public float distanceThreshold = .15f;

    const float OriginOffset = .001f;
    Vector3 RaycastOrigin => transform.position + Vector3.up * OriginOffset;
    float RaycastDistance => distanceThreshold + OriginOffset;


    void LateUpdate()
    {

        bool isGroundedNow = Physics.Raycast(RaycastOrigin, Vector3.down, distanceThreshold * 2);


        if (isGroundedNow && !isGrounded)
        {
            Grounded?.Invoke();
        }


        isGrounded = isGroundedNow;
    }
}
