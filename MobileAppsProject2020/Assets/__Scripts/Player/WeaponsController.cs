using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponsController : MonoBehaviour
{
    //public fields
    public Transform firePoint;
    // == private fields ==
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float firingRate = 0.25f;
    [SerializeField] private AudioClip shootClip;
    [SerializeField][Range(0f, 1.0f)] private float shootVolume = 0.5f;

    private Coroutine firingCoroutine;
    
    private AudioSource audioSource;

    // == private methods ==
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // one way to fire
        
            // implement a coroutine to fire
            firingCoroutine = StartCoroutine(FireCoroutine());
        }
        if(Input.GetKeyUp(KeyCode.Space))
        { 
            StopCoroutine(firingCoroutine);
        }
    }

    // coroutine returns an IEnumerator type
    private IEnumerator FireCoroutine()
    {
        while(true)
        {
            //create a bullet
            Bullet bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
            bullet.transform.position = transform.position;
            // play sound - AudioClip
            
            audioSource.PlayOneShot(shootClip, shootVolume);

            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.velocity = bullet.transform.right * bulletSpeed;
            // sleep for short time
            yield return new WaitForSeconds(firingRate); // pick a number!!!
            
        }
    }

   
}
