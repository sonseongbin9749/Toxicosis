using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [SerializeField]
    private long score = 10;
    [SerializeField]
    private int hp = 1;
    [SerializeField]
    private float speed = 25;

    private bool isDamaged = false;
    
    private Gamemanager gameManager = null;
    void Start()
    {
        gameManager = FindObjectOfType<Gamemanager>();

    }


    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(transform.localPosition.y < gameManager.MinPosition.y)
        {
            gameManager.Dead();
            Destroy(gameObject);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            if (hp > 0)
            {
                if (isDamaged) return;
                isDamaged = true;
                StartCoroutine(Damaged());
                return;
            }
            gameManager.AddScore(score);//게임 메니저에 있는 점수만큼 스코어를 올린다 gameManager(소문자 : 변수)
            Destroy(gameObject);
            
        }
    }

    private IEnumerator Damaged()
    {
        hp--;
        yield return new WaitForSeconds(0.1f);
        isDamaged = false;
    }

   
}
