using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FishingLine : MonoBehaviour
{
    public Transform pivot1;    
    public Transform pivot2;

    LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPositions(new Vector3[]{
            pivot1.position, pivot2.position
        });
    }
}
