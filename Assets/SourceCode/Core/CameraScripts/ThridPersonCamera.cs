using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonCamera : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform target;
    [SerializeField] private Camera cam;


    void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        //This is getting the normalized vector from the target to the camera
        Vector3 direction = (target.position - cam.transform.position).normalized;

        //Gets the look roation vector from the normalized vector
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        
        //we are changed only the y value of the rotaiton
        lookRotation.x = transform.rotation.x;
        lookRotation.z = transform.rotation.z;

        //Lerp the rotation fromm the cureent rotaion tot he expected roation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.smoothDeltaTime * 100);

        //Also lerp the the position od the camera from the taget position tott he ennd of the postion
        transform.position = Vector3.Slerp(transform.position, target.position, Time.smoothDeltaTime * speed);
    }
}
