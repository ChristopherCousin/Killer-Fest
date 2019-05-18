using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    [SerializeField] private Camera _Camera;
    [SerializeField] private Joystick Joystick = null;

    //speed of the character or AIM
    [SerializeField] private float Speed = 2;


    private float v = 0f;
    private float h = 0f;


    void Update()
    {
        //Character - Joystick movement
        getJoyStickValues();
        moveAim();
    }

    private void getJoyStickValues()
    {
        v = Joystick.Vertical; //get the vertical value of joystick
        h = Joystick.Horizontal;//get the horizontal value of joystick
    }

    private void moveAim()
    {
        
        float xLeft;
        float xRight;
        float yTop;
        float yBottom;


        if (_Camera != null)
        {
            xLeft = _Camera.transform.position.x - 1.3f;
            xRight = _Camera.transform.position.x + 1.3f;
            yTop = _Camera.transform.position.y - 1.3f;
            yBottom = _Camera.transform.position.y + 1.3f;

            Vector3 translate = (Joystick.Direction.normalized * Time.deltaTime) * Speed;

            float newX;
            float newY;

            if ((newX = transform.position.x + translate.x) >= xLeft && newX <= xRight)
            {
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
            if ((newY = transform.position.y + translate.y) >= yTop && newY <= yBottom)
            {
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }

        } else
        {
            _Camera = Camera.main;
        }
        
    


    }
}
