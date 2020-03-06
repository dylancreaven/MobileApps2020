using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// move left when things start

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour
{
    // == private fields ==
    [SerializeField] private float speed = 5.0f;
    public Transform target;
    public bool lvlcomplete=false;
    private Rigidbody2D rb;

    // == private methods ==
    private void Start()
    {
        
        var player = GameObject.FindGameObjectWithTag("Player");
        if(player){
            target = player.GetComponent<Transform>();
         //rb = GetComponent<Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //will follow target (i.e the player)
        
        if(lvlcomplete==false){       
             if(target)
             {
             transform.position = Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
             // rb.velocity = new Vector2(-1 * speed, 0);
             } 
        }
    }
    public void ToggleLvlComplete(){
        lvlcomplete=!lvlcomplete;
        Debug.Log("Inside ToggleLvlComplete() "+ lvlcomplete);
    }
    public static EnemyBehaviour FindEnemyBehaviour()
    {
        EnemyBehaviour eb = FindObjectOfType<EnemyBehaviour>();
        if(!eb)
        {
            Debug.LogWarning("Missing EnemyBehaviour");
        }
        return eb;
    }
}