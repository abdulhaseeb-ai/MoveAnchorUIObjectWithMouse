using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Anchor
{
    Center,
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
    MiddleLeft,
    MiddleRight,
    MiddleUp,
    MiddleDown
}

public class MoveAnchoredUIObjectWithMouse : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public Anchor m_Anchor;

    bool m_IsMouseDown;




    public void OnPointerDown(PointerEventData pointerEventData)
    {
        m_IsMouseDown = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        m_IsMouseDown = false;
    }


    void Start()
    {
        
    }
    
    void Update()
    {
        if (!m_IsMouseDown) return;

        transform.GetComponent<RectTransform>().anchoredPosition = TransformedMousePosition(m_Anchor);
    }




    public Vector2 TransformedMousePosition(Anchor _Anchor)
    {
        Vector2 _TransformedPosition = Vector2.zero;
        Vector2 _MousePosition = Input.mousePosition;


        if (_Anchor == Anchor.Center)
        {
            _TransformedPosition = _MousePosition - new Vector2(Screen.width, Screen.height) / 2.0f;
        }
        else if (_Anchor == Anchor.TopRight)
        {
            _TransformedPosition = _MousePosition - new Vector2(Screen.width, Screen.height);
        }
        else if (_Anchor == Anchor.TopLeft)
        {
            _TransformedPosition = new Vector2(_MousePosition.x, _MousePosition.y - Screen.height);
        }
        else if (_Anchor == Anchor.BottomRight)
        {
            _TransformedPosition = new Vector2(_MousePosition.x - Screen.width, _MousePosition.y);
        }
        else if (_Anchor == Anchor.BottomLeft)
        {
            _TransformedPosition = new Vector2(_MousePosition.x, _MousePosition.y);
        }
        else if (_Anchor == Anchor.MiddleRight)
        {
            _TransformedPosition = new Vector2(_MousePosition.x - Screen.width, _MousePosition.y - Screen.height / 2.0f);
        }
        else if (_Anchor == Anchor.MiddleLeft)
        {
            _TransformedPosition = new Vector2(_MousePosition.x, _MousePosition.y - Screen.height / 2.0f);
        }
        else if (_Anchor == Anchor.MiddleUp)
        {
            _TransformedPosition = new Vector2(_MousePosition.x - Screen.width / 2.0f, _MousePosition.y - Screen.height);
        }
        else if (_Anchor == Anchor.MiddleDown)
        {
            _TransformedPosition = new Vector2(_MousePosition.x - Screen.width / 2.0f, _MousePosition.y);
        }

        return _TransformedPosition;
    }
}
