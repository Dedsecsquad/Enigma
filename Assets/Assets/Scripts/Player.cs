using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] CharacterController _controller;
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpHight = 3f;
    [SerializeField] float _gravity = -9.81f;
    [SerializeField] LayerMask _groundMask;

    Vector3 _velocity;
    float _rotationSpeed = 10f;
    private void Update()
    {
        //horizontal movement
        float horizontal = Input.GetAxis("Horizontal");
        _velocity.x = horizontal * _speed;
        if (horizontal >0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 90f, 0f), 10f * Time.deltaTime);
        }
        else if (horizontal < 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 270f, 0f), 10f * Time.deltaTime);
        }
        _animator.SetBool("isRunning", Mathf.Abs(horizontal) > 0.05f);

        //vertical movement
        bool isGrounded = Physics.CheckSphere(_groundCheck.position, 0.1f, _groundMask);
        if (isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -2f;
            _animator.SetBool("isGrounded", true);
        }

        _velocity.y += _gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHight * -2f * _gravity);
            _animator.SetTrigger("jump");
            _animator.SetBool("isGrounded", false);
            _audioSource.Play();
        }

        _controller.Move(_velocity * Time.deltaTime);
    }
}
