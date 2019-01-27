using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform pivot;
    float offsetY;
    void Start()
    {
        offsetY = transform.position.y - pivot.position.y;
    }

    void LateUpdate()
    {
        if(pivot.position.y < 0)
            transform.position = new Vector3(transform.position.x, pivot.position.y + offsetY, transform.position.z);
    }
}
