using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private int enemySpeed;
    [SerializeField] private int stoppingDistance;
    [SerializeField] private int stopDistance;

    [SerializeField] private List<Vector2> _SpawnMoves;


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
        InvokeRepeating("RandomMove", 0.0f, 2.0f);


        _SpawnMoves.Add (new Vector2(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3)));
        _SpawnMoves.Add(new Vector2(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3)));
        _SpawnMoves.Add(new Vector2(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3)));
        
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
        Vector3 ab = (player.transform.position - transform.position).normalized;
        float x = ab.x;
        float y = ab.y;


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

    private void AllFalse()
    {
        anim.SetBool("walkLeft", false);
        anim.SetBool("walkUp", false);
        anim.SetBool("walkDown", false);
        anim.SetBool("walkRight", false);
    }

    private void RandomMove()
    {
        if(!inRange)
        {
            for(int x = 0; x < _SpawnMoves.Count; x++)
            {
                transform.position = Vector2.MoveTowards(transform.position, _SpawnMoves[x], enemySpeed * Time.deltaTime);
            }
        }
    }

}
