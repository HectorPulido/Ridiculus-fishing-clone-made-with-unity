using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Vector2 xSpeedRange;
    public Vector2 ySpeedRange;
    protected Transform parent;
    protected Rigidbody2D rb;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(parent != null)  
            transform.position = parent.position;
    }

    public virtual void Fished(Transform Hook)
    {
        parent = Hook;
        transform.transform.rotation = Quaternion.Euler(0,0,Random.Range(0,360));
    }
    public virtual void Released()
    {
        parent = null;
        rb.velocity = new Vector2(Random.Range(xSpeedRange.x,xSpeedRange.y), Random.Range(ySpeedRange.x,ySpeedRange.y));
        rb.gravityScale = 1;
    }
}
