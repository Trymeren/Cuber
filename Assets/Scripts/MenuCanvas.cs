using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCreditScene()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
