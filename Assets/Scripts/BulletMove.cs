using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
   
    [SerializeField]
    private float speed = 30f;
    private Gamemanager gamemanager = null;
    void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();
    }

  
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(transform.localPosition.y > gamemanager.MaxPosition.y + 2f)
        {
            Destroy(gameObject);
        }
    }
}
