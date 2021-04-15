using UnityEngine;
using UnityEngine.SceneManagement;


public class Gameovermanager : MonoBehaviour
{
    public void OnClickRetry()
    {
        SceneManager.LoadScene("Main");
    }
}
