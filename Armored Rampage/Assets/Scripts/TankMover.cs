using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    Vector2 movementVector;
    Vector2 direction;
    float frameRate;

    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    float idleTime;

    public SpriteRenderer spriteRenderer;

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        direction = new Vector2(movementVector.x, movementVector.y).normalized;

        rb2d.velocity = direction * maxSpeed * Time.deltaTime;

      

        HandleSpriteFlip();

        List<Sprite> directionSprites = GetSpriteDirection();

        if (directionSprites != null)
        {
            spriteRenderer.sprite = directionSprites[0];
        }
        else
        {

        }
    }

    private void HandleSpriteFlip()
    {
        if (!spriteRenderer.flipX && direction.x < 0)
        {   
            spriteRenderer.flipX = true;
        }
        else if (spriteRenderer.flipX && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        if (direction.y > 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = neSprites;
            }
            else
            {
                selectedSprites = nSprites;
            }
        }
        else if (direction.y < 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = seSprites;
            }
            else
            {
                selectedSprites = nSprites;
            }
        }
        else
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = eSprites;
            }
        }
        if (selectedSprites != null)
        {
            return selectedSprites;
        }
        return null;


    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        OnSpeedChange?.Invoke(this.movementVector.magnitude);
    }
}
