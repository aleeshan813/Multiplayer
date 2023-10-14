using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : NetworkBehaviour
{
    Vector3 MovDir = new Vector3(0, 0, 0);
    float MovSpeed = 3f;

    private void Update()
    {
        if (!IsOwner) return;
        // Reset MovDir each frame to prevent drift in movement
        MovDir = Vector3.zero;

        // Check for input and set the movement direction accordingly
        if (Input.GetKey(KeyCode.W))
            MovDir += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            MovDir += Vector3.back;

        if (Input.GetKey(KeyCode.A))
            MovDir += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            MovDir += Vector3.right;

        // Normalize MovDir to prevent faster diagonal movement
        if (MovDir != Vector3.zero)
            MovDir.Normalize();

        // Move the GameObject in the desired direction with MovSpeed
        transform.position += MovDir * MovSpeed * Time.deltaTime;
    }
}
