using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    public List<Sprite> nSprites;
    public List<Sprite> neSprites;    
    public List<Sprite> eSprites;    
    public List<Sprite> seSprites;    
    public List<Sprite> sSprites;    
    
    public float walkSpeed;
    public float frameRate;
    
    public float idleTime;

    Vector2 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get direction of input
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        
        // Set walk based on direction
        body.velocity = direction * walkSpeed;
        
        HandleSpriteFlip();
        SetSprite();
       
    }

    void SetSprite() 
    {
        List<Sprite> directionSprites = GetSpriteDirection();

        if(directionSprites != null)
        {
            float playTime = Time.time - idleTime;
            int totalFrames = (int)(playTime * frameRate);
            int frame = totalFrames % directionSprites.Count;

            spriteRenderer.sprite = directionSprites[frame]; //Image 9 for complety 
        }
        else
        {
            idleTime = Time.time;
        }
    }

    void HandleSpriteFlip()
    {
        if(!spriteRenderer.flipX && direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(spriteRenderer.flipX && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        } 
        
    }

    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        if(direction.y > 0)
        {
            if(Mathf.Abs(direction.x) > 0) // WEST OR EAST
            {
                selectedSprites = neSprites;
            }   
            else // ZERO DESLOCATION FOR X
            {
                selectedSprites = nSprites;
            }
        } else if(direction.y < 0)
        {
            if(Mathf.Abs(direction.x) > 0) // WEST OR EAST
            {
                selectedSprites = seSprites;
            }   
            else // ZERO DESLOCATION FOR X
            {
                selectedSprites = sSprites;
            }
        }
        else
        {
            if(Mathf.Abs(direction.x) > 0) // WEST OR EAST
            {
                selectedSprites = eSprites;
            }              
        }
        return selectedSprites;
    }
}

