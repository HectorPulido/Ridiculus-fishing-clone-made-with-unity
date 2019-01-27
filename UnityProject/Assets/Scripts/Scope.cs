using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public float scopeSpeed;
    public GameObject bloodParticles;
    public GameObject deadFish;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    float h,v;
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(c.Count > 0)
            {
                foreach(var fish in c)
                {
                    if(fish.gameObject.activeInHierarchy)
                    {            
                        Instantiate(bloodParticles, transform.position, bloodParticles.transform.rotation);           
                        Instantiate(deadFish, fish.transform.position, fish.transform.rotation);
                        fish.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        float tempVelY = scopeSpeed * v;
        float tempVelX = scopeSpeed * h;

        rb.velocity = new Vector2(tempVelX,tempVelY);
    }

    List<Collider2D> c = new List<Collider2D>();
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Fish"))
        {
            c.Add(col);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Fish"))
        {
            if(c.Contains(col))
                c.Remove(col);
        }
    }
}
