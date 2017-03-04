using UnityEngine;
using System.Collections.Generic;

public class MouseInput : CommonInput
{
    public override void InputUpdate()
    {
        bool leftButtonDown     = Input.GetMouseButtonDown(0);
        bool rightButtonDown    = Input.GetMouseButtonDown(1);

        if (true == leftButtonDown)
        {
            InputHooker(InputMessage.LButtonDown);
        }
        else if (true == rightButtonDown)
        {
            InputHooker(InputMessage.RButtonDown);
        }
    }
}