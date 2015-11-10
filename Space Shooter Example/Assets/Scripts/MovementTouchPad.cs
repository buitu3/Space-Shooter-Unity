using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MovementTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler 
{

    public float smoothing;

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerID;

    private Vector2 previousPointerPosition;
    void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }

    void Start()
    {
        StartCoroutine(returnZeroIfNotDrag());
    }

    public void OnPointerDown(PointerEventData data)
    {
        touched = true;
        pointerID = data.pointerId;
        origin = data.position;
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {
            Vector2 currentPosition = data.position;
            direction = currentPosition - origin;
            origin = data.position;
            //print(direction.magnitude);
            /*
            if (direction.magnitude <= 2)
            {
                direction = Vector2.zero;
            }
            */
            direction = direction.normalized;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }

    public Vector2 getDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        //smoothDirection = direction;
        return smoothDirection;
    }

    IEnumerator returnZeroIfNotDrag()
    {
        while (true)
        {
            if (touched)
            {
                //print(Input.mousePosition.x + ":" + Input.mousePosition.y);
                /*
                float deltaHorizontal = Input.mousePosition.x - origin.x;
                float deltaVertical = Input.mousePosition.y - origin.y;
                print(deltaHorizontal + ":" + deltaVertical);
                 */
                float deltaHorizontal = Input.mousePosition.x - previousPointerPosition.x;
                float deltaVertical = Input.mousePosition.y - previousPointerPosition.y;
                //print(deltaHorizontal + ":" + deltaVertical);
                if (deltaHorizontal == 0 && deltaVertical == 0)
                {
                    direction = Vector2.zero;
                }
                previousPointerPosition.x = Input.mousePosition.x;
                previousPointerPosition.y = Input.mousePosition.y;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
