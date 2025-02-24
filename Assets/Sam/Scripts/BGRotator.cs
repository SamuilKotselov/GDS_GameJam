using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRotator : MonoBehaviour
{
    public float speed = 10f;
    public float width = 14f;
    public Transform dupeSprite;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -width)
        {
            transform.position = new Vector3(dupeSprite.position.x + width, transform.position.y, transform.position.z);
        }
    }
}
