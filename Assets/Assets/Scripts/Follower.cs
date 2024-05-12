using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform _traget;
    [SerializeField] float _speed = 5f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _traget.position,  _speed * Time.deltaTime);
    }
}
