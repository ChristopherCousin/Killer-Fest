using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private int enemySpeed;
    [SerializeField] private int stoppingDistance;

    [SerializeField] private int stopDistance;


    public Animator anim;
    private bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        inRange = false;
        stoppingDistance = 1;
        enemySpeed = 2;
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            FollowPlayer();
        }
        animateChar();
    }

    private void AllFalse()
    {
        anim.SetBool("walkLeft", false);
        anim.SetBool("walkUp", false);
        anim.SetBool("walkDown", false);
        anim.SetBool("walkRight", false);
    }

    void FindTarget()
    {
        if (player == null)
        {
            Debug.Log("There's no player in the enemy script, drag him for reduce memory usage");
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            if (player == null)
            {
                Debug.Log("There's no player in the scene or the player dosn't have a tag: Player, take a look");
            }
        }
    }

    private void FollowPlayer()
    {
        CheckIfPlayerInRange();

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
        } else {
            Debug.Log("Attack!");
        }
    }

    private void CheckIfPlayerInRange()
    {
        if (Vector2.Distance(transform.position, player.position) < 6)
        {
            inRange = true;
        } else {
            inRange = false;
        }
    }

    private void animateChar()
    {

        float x = player.transform.position.normalized.x;
        float y = player.transform.position.normalized.y;

        if (x > 0 && y > 0)
        {
            if (x >= y)
            {
                AllFalse();
                anim.SetBool("walkRight", true);
            }
            else
            {
                AllFalse();
                anim.SetBool("walkUp", true);
            }
        }
        else if (x < 0 && y < 0)
        {
            if (x <= y)
            {
                AllFalse();
                anim.SetBool("walkLeft", true);
            }
            else
            {
                AllFalse();
                anim.SetBool("walkDown", true);
            }
        }
        else if (x > 0 && y < 0)
        {
            y *= -1;
            if (y >= x)
            {
                AllFalse();
                anim.SetBool("walkDown", true);
            }
            else
            {
                AllFalse();
                anim.SetBool("walkRight", true);
            }
        }
        else if (x < 0 && y > 0)
        {
            x *= -1;
            if (y >= x)
            {
                AllFalse();
                anim.SetBool("walkUp", true);
            }
            else
            {
                AllFalse();
                anim.SetBool("walkLeft", true);
            }
        } else {
            AllFalse();
        }
    }

}
