using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    // == public fields ==
   
    // == private fields ==
     private float xValue;
    private float yValue;
    private Rigidbody2D rb;
    private bool facingRight=true;
 
    [SerializeField] private float speed = 5.0f;


    
    //play big crash sound, respawn player and decriment no of lives

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       Movement();

    }
    private void Flip()//switch way player is facing
	{
		facingRight = !facingRight;
         transform.Rotate(0f,180f,0f);
	}

    void Movement(){
        Debug.Log("In Movement");
        // if the player presses the up arrow, then move
        float vMovement = Input.GetAxis("Vertical");
        float hMovement = Input.GetAxis("Horizontal");
        // apply a force, get the player moving.
        rb.velocity = new Vector2(hMovement * speed, 
                                  vMovement * speed);
         if ((hMovement * speed >0||vMovement * speed >0)&& !facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if ((hMovement * speed <0||vMovement * speed <0)&&facingRight)
			{
				// ... flip the player.
				Flip();
			}
        
         int y = SceneManager.GetActiveScene().buildIndex; // find what index current scene is
         if (y==2)
         {
            Debug.Log("Game level 1");
            yValue = Mathf.Clamp(rb.position.y, -1.9f, 4.222464f);
            xValue = Mathf.Clamp(rb.position.x, -9.21339f, 9.268325f);
         }
         else if (y==3)
         {
            Debug.Log("Game level 2");
            yValue = Mathf.Clamp(rb.position.y, -4.445691f, 6.316514f);
            xValue = Mathf.Clamp(rb.position.x, -8.785898f, 8.784029f);
         }
        

        rb.position = new Vector2(xValue, yValue);
    }
}
