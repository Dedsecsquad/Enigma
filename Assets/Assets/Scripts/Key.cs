using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] Gate _gate;
    [SerializeField] AudioSource _audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            _gate.Open();
            Destroy(gameObject);
            
        }
    }
}
