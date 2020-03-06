using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // == public fields ==

    // == private fields ==
    private Rigidbody2D rb;
    private bool facingRight=true;
    [SerializeField] private int playerLives=3;
    public int PlayerLives{
            get{return playerLives;} 

        }
    
    private Camera gameCamera;
    
    [SerializeField] private float speed = 5.0f;

    // == private methods ==

    //need method to handle death

    
    //play big crash sound, respawn player and decriment no of lives

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // add hMovement
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
        //Debug.Log(rb.velocity);
        float yValue = Mathf.Clamp(rb.position.y, -1.9f, 4.222464f);
        float  xValue = Mathf.Clamp(rb.position.x, -9.21339f, 9.268325f);

        rb.position = new Vector2(xValue, yValue);

    }
    private void Flip()//switch way player is facing
	{

		
		facingRight = !facingRight;

		/*flips orientation of player. From Brackeys Github - https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs 
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;*/

        
        
         transform.Rotate(0f,180f,0f); // taken from Brackeys Youtube video - https://www.youtube.com/watch?v=wkKsl1Mfp5M
	}

    
}
