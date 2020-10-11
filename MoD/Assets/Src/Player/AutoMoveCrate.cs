using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveCrate : PhysicsObject
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, targetVelocity.y);
    }
}
