using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform target;
    public Vector3 camera_position;
    public Vector3 camera_angle;
    public float smoothSpeed = 0.125f;
    public int softzone = 5;


    // Update is called once per frame
    void FixedUpdate()
    {
        if(target.position.z > softzone)
        {
            Vector3 desiredPos = new Vector3(camera_position.x, camera_position.y, target.position.z + camera_position.z - softzone);
            Vector3 dir = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.fixedDeltaTime);
            transform.position = dir;

            Vector3 rotationVector = new Vector3(60, 0, 0);
            Quaternion rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotationVector), Time.deltaTime * smoothSpeed);
            transform.rotation = rotation;

        }

        if (FindObjectOfType<GameManager>().isGameOver)
        {
            Vector3 desiredPos = new Vector3(camera_position.x, 10f, target.position.z - softzone);
            Vector3 dir = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.fixedDeltaTime);
            transform.position = dir;
        }
    }
}
