using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    [SerializeField] // 밖에서 수정할때 쓰는 것
    private Transform bulletPosition = null; //해킹방지


    [SerializeField]
    private GameObject bulletPrefab = null;


    [SerializeField]
    private float speed = 30f;

    private Vector2 targetPosition = Vector2.zero;
    private Gamemanager gameManager = null;
    private SpriteRenderer spriteRenderer = null;
    private bool isDamaged = false;


    void Start()
    {
        gameManager = FindObjectOfType<Gamemanager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Fire()); // 이 코드를 꼭 써줘야함 Fire()할때


    }

    void Update()
    {
        if (Input.GetMouseButton(0))//0 = 좌클릭 1 = 우클릭 
        {
            targetPosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);// 메인 카메라의 기준을 바꿔준다
            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.MinPosition.x, gameManager.MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.MinPosition.y, gameManager.MaxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);

        }
    }

    private IEnumerator Fire() //스킬 쿨타임 대기할떄 등 쓰는 코드
    {
        GameObject bullet;

        while (true)
        {
            bullet =
            Instantiate(bulletPrefab, bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(0.2f); //대기시간


        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDamaged) return;
        isDamaged = true;
        StartCoroutine(Damaged());
    }

    private IEnumerator Damaged()
    {
        gameManager.Dead();
        for (int i = 0; i < 10; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        isDamaged = false;
    }
}
