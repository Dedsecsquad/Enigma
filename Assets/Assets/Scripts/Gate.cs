using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    bool _isOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            if (_isOpen)
            {
                Destroy(gameObject);
            }
            
        }
    }


    public void Open()
    {
        _isOpen = true;
    }
}
