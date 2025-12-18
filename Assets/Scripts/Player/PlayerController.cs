using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;
using DG.Tweening;
using System.Dynamic;

public class PlayerController : Singleton<PlayerController>
{
     [Header ("Lerp")]
    public float lerpSpeed = 1f;
    public Transform target;
   
    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "End Line";

    public GameObject endScreen;

    [Header("TextMesh")]
    public TextMeshPro uiTextPowerUp;

    [Header ("Coin Setup")]
    public GameObject coinCollector;


    public bool invincible = false;


//privates
    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;
   
    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }
    void Update()
    {
        if(!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed*Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckEndLine)
        {
            if(!invincible) EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
           if(!invincible) EndGame();
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

    #region POWER UPS
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvincible(bool b = true)
    {
        invincible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        //var p = transform.position;
        //p.y = _startPosition.y + amount;
        //transform.position = p;

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight(float animationDuration)
    {
        transform.DOMoveY(_startPosition.y, animationDuration);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one*amount;
    }

    #endregion
}
