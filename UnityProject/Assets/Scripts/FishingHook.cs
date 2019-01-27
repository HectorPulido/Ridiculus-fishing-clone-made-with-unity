using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHook : MonoBehaviour
{
    public enum GameState
    {
        State1,
        State2,
        State3
    }

    public float initialSpeed;
    public float finalSpeed;
    public float jumpSpeed;
    public float horizontalSpeed;
    public FollowCamera followCamera;
    public FishInstancer fishInstancer;
    public GameObject scope;
    public GameState currentState = GameState.State1;

    Rigidbody2D rb;
    List<Fish> fishes = new List<Fish>(); 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    float v;
    void Update()
    {
        v = Input.GetAxis("Horizontal");

        if(transform.position.y > 0 && currentState == GameState.State2)
        {
            currentState = GameState.State3;
            scope.SetActive(true);
            followCamera.enabled = false;
            rb.velocity = new Vector2(0, jumpSpeed);
            rb.gravityScale = 1f;
            foreach (var child in fishes) {
                child.Released();
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tempVel = -initialSpeed * v;

        if(currentState == GameState.State1)
        {
            rb.velocity = new Vector2(tempVel,initialSpeed);
        }
        else if(currentState == GameState.State2)
        {
            rb.velocity = new Vector2(tempVel,finalSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(currentState == GameState.State3)
            return;

        if(col.CompareTag("Fish"))
        {
            var f = col.GetComponent<Fish>();
            f.Fished(transform);
            fishes.Add(f);

            if(currentState == GameState.State1)
            {
                currentState = GameState.State2;
                fishInstancer.enabled = false;
            }
        }
    }

}
