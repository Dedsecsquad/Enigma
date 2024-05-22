using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecube : MonoBehaviour
{
   


    void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0f , 0F, Space.Self );
    }
}
