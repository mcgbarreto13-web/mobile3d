using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [Header ("Lerp")]
    public float lerpSpeed = 1f;
    public Transform target;
   
    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "End Line";

    public GameObject endScreen;

    private Vector3 _pos;
    private bool _canRun;
   
    void Update()
    {
        if(!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed*Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckEndLine)
        {
            EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            EndGame();
        }
    }

private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }
}
