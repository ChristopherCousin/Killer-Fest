using UnityEngine;

public class controllerJoyStick : MonoBehaviour {

	[SerializeField]private Joystick Joystick;

    //speed of the character or AIM
    [SerializeField]private float Speed = 2;

    private Animator anim;

    private float v = 0f;
    private float h = 0f;


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Character - Joystick movement
        getJoyStickValues();
        animateChar();
    }
    private void FixedUpdate()
    {
        moveChar();
    }

    private void getJoyStickValues()
    {
        v = Joystick.Vertical; // get the vertical value of joystick
        h = Joystick.Horizontal; // get the horizontal value of joystick
    }

    private void moveChar()
    {
        Vector3 translate = (Joystick.Direction.normalized * Time.deltaTime) * Speed;
        transform.Translate(translate);
    }

    private void animateChar()
    {
        Vector2 direction = Joystick.Direction;
        float x = direction.x;
        float y = direction.y;

        if(x > 0 && y > 0)
        {
            if(x >= y)
            {
                AllFalse();
                anim.SetBool("walkRight", true);
            } else
            {
                AllFalse();
                anim.SetBool("walkUp", true);
            }
        } else if(x < 0 && y < 0)
        {
            if(x <= y)
            {
                AllFalse();
                anim.SetBool("walkLeft", true);
            } else
            {
                AllFalse();
                anim.SetBool("walkDown", true);
            }
        } else if(x > 0 && y < 0)
        {
            y *= -1;
            if(y >= x)
            {
                AllFalse();
                anim.SetBool("walkDown", true);
            } else
            {
                AllFalse();
                anim.SetBool("walkRight", true);
            }
        } else if(x < 0 && y > 0)
        {
            x *= -1;
            if(y >= x)
            {
                AllFalse();
                anim.SetBool("walkUp", true);
            } else
            {
                AllFalse();
                anim.SetBool("walkLeft", true);
            }
        }  else {
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
}