using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector2 vertBoundry = new Vector2(-4.5f, 4.5f);
    private Vector2 direction;
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                direction = touch.deltaPosition;                
                Move();
            }
        }
    }

    void Move()
    {
        var newXPos = transform.position.x + speed * direction.x * Time.deltaTime;
        newXPos = Mathf.Clamp(newXPos, vertBoundry.x, vertBoundry.y);
        transform.position = 
                    new Vector3(newXPos, 
                    transform.position.y, transform.position.z);
    }
}
