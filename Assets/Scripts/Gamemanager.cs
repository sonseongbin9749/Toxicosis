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
    
    private long score = 0;
    
    [SerializeField]
    private int life = 3;
    
    void Start()
    {
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
    public void Dead()
    {
        life--;
        UpdateUI();
        if(life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
   

    public void UpdateUI()
    {
        textLife.text = string.Format("Life\n{0}", life);
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