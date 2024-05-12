using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
