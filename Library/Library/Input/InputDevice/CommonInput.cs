public enum InputMessage
{
    LButtonDown,
    RButtonDown,
    KeyDown,
}

public delegate void Hooker(InputMessage message);

public abstract class CommonInput
{
    public Hooker InputHooker { get; set; }

    public abstract void InputUpdate();
}
