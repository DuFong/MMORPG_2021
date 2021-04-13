using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;

    public Action<Defines.MouseEvent> MouseAction = null;

    public void OnUpdate()
    {
        if(Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }

        if(MouseAction != null)
        {
            if(Input.GetMouseButton(1))
            {
                MouseAction.Invoke(Defines.MouseEvent.Press);
            }
            if(Input.GetMouseButtonUp(1))
            {
                MouseAction.Invoke(Defines.MouseEvent.Click);
            }
        }
    }
}
