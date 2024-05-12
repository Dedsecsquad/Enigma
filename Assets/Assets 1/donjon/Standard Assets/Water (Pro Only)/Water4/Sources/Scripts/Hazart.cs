using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Hazart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlatformerCharacterController>() != null)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
