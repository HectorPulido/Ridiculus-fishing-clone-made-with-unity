using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFish : Fish
{
    public float directionChange;
    public float fishSpeed;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {        
        while(!rb.isKinematic)
        {
            transform.rotation = Quaternion.Euler(0,transform.eulerAngles.y + 180,0);
            rb.velocity = -transform.right * fishSpeed;
            yield return new WaitForSeconds(directionChange);
        }
    }
    public override void Fished(Transform Hook)
    {
        base.Fished(Hook);
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
    // Update is called once per frame
    public override void Released()
    {
        rb.isKinematic = false;
        base.Released();
    }
}
