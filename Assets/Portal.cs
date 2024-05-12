using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlatformerCharacterController>() != null)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
        }
    }
}
