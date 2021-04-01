using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
   
    [SerializeField]
    private float speed = 50f;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
