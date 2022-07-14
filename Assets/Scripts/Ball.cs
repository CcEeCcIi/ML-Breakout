using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float _speed = 50f;
    Rigidbody _rigidbody;
    Vector3 _velocity;
    Renderer _renderer;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        //add some delay between launch
        Invoke("Launch", 0.5f);
    }

    void Launch()
    {
        //make the ball travel up initially
        _rigidbody.velocity = Vector3.down * _speed;
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocity = _rigidbody.velocity;

        if (!_renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("ball before hit - " + _rigidbody.velocity);
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
        //Debug.Log("ball after hit - " + _rigidbody.velocity);
    }
}

