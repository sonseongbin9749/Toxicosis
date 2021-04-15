using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private Text textLife = null;
    [SerializeField]
    private Text textScore = null;
    [SerializeField]
    private GameObject enemyCroissantPrefab = null;
    [SerializeField]
    private int life = 3;
    public Vector2 MinPosition { get; private set;}//구분하기 위해서 Min~~ 대문자로 씀

    public Vector2 MaxPosition { get; private set;} //해킹 방지, 여기에서만 변경 가능
    private long score = 0;

    void Start()
    
    {
        MinPosition = new Vector2(-7f, -12f);//f쓰는 이유는 float이기 때문 안쓰면 오류남
        MaxPosition = new Vector2(7f, 12f);
        StartCoroutine(SpawnCroissant());
    }
    public void AddScore(long addScore)//밖에서 접근하지만 변수는 건들지 못함 (변수를 감싼다)
    {
        score += addScore;
        UpdateUI();
    }

    
    public void UpdateUI()
    {
      textScore.text = string.Format("score\n{0}", score);//score.형은 int형 string을 써야지 문자가 출력이 됨 
    }

    public void UpdateDead()
    {
        textLife.text = string.Format("Life : {0}", life);
  
    }
    public void Dead()
    {
        life--;
        UpdateDead();
        if(life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
   

    
    private IEnumerator SpawnCroissant() //대기시간

    {
        float spawnDelay = 0f;
        float randomX = 0f;
        
        while (true)
        {
            
            randomX = Random.Range(-7f, 7f);
            spawnDelay = Random.Range(2f, 5f);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(enemyCroissantPrefab, new Vector2(randomX, 20f), Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
            }
                
                            yield return new WaitForSeconds(spawnDelay);

        }

    }
}