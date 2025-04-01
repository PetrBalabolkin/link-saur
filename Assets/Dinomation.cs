using System.Collections;
using UnityEngine;

public class Dinomation : MonoBehaviour
{
    public float speed;
    public float offScreenX;
    public float startScreenX;
    
    public static bool IsRunning;
    
    private void Update()
    {
        if (!IsRunning & Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Run());
        }
    }

    IEnumerator Run()
    {
        IsRunning = true;
        
        while(transform.position.x > offScreenX)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            yield return null;
        }
        
        transform.position = new Vector3(startScreenX, transform.position.y, transform.position.z);
        
        IsRunning = false;
    }
}
