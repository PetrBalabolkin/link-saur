using System;
using System.Collections;
using UnityEngine;

public class Dinomation : MonoBehaviour
{
    public float speed;
    public float offScreenX;
    public float startScreenX;

    private static bool _isRunning;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isRunning & Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Run());
        }
    }

    IEnumerator Run()
    {
        _isRunning = true;
        _animator.SetBool("isRunning", true);
        
        while(transform.position.x > offScreenX)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            yield return null;
        }
        
        _animator.SetBool("isRunning", false);
        
        transform.position = new Vector3(startScreenX, transform.position.y, transform.position.z);
        
        _isRunning = false;
    }
}
