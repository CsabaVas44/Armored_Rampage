using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RandomMovement : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;
    public float startWaitTime;

    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    Vector2 direction;
    Vector2 transformDir;
    int counter;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = transform.position;
    }
    IEnumerator WaitCoroutine()
    {
        transformDir = transform.position;
        yield return new WaitForSeconds(0.2f);
        direction = transform.position;
    }
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        StartCoroutine(WaitCoroutine());

        List<Sprite> directionSprites = GetSpriteDirection();

        if (directionSprites != null)
        {
            spriteRenderer.sprite = directionSprites[0];
        }



        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }


    }


    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        Debug.Log(transformDir.y + "Transform");

        if (direction.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
            //if (transformDir.y > direction.y)
            //{
            //    selectedSprites = neSprites;
            //}
            //else if (transformDir.y < direction.y)
            //{
            //    selectedSprites = seSprites;
            //}
            //else
            //{
                selectedSprites = eSprites;
            //}

            if (transformDir.x == direction.x)
            {
                selectedSprites = nSprites;
            }
            return selectedSprites;
        }

        else
        {
            spriteRenderer.flipX = true;
            //if (transformDir.y > direction.y)
            //{
            //    selectedSprites = neSprites;
            //}
            //else if (transformDir.y < direction.y)
            //{
            //    selectedSprites = seSprites;
            //}
            //else
            //{
                selectedSprites = eSprites;
            //}

            if (transformDir.x == direction.x)
            {
                selectedSprites = nSprites;
            }
            return selectedSprites;
        }
        
        
       

}





}
