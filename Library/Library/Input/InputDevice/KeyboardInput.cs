using UnityEngine;

public class KeyboardInput : CommonInput
{
    public override void InputUpdate()
    {
        bool keyDown = Input.anyKeyDown;

        if(true == keyDown)
        {
            InputHooker(InputMessage.KeyDown);
        }
    }
}

