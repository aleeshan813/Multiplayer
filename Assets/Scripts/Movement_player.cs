using UnityEngine;
using UnityEngine.EventSystems;

public class Movement_player : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    float HorizontalInput = 0;
    float VerticalInput = 0;

    Vector3 MovDirection;
    Vector3 Movement;

    float MoveSpeed = 2f;
    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        MovDirection = new Vector3(HorizontalInput,0,VerticalInput);
        MovDirection.Normalize();

        Movement = MovDirection * MoveSpeed * Time.deltaTime;

        playerTransform.Translate(Movement);
    }
}
