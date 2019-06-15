using UnityEngine;
public class GamePad : MonoBehaviour
{
    ////XBox Controller
    public static Vector3 Direction = new Vector3(0, 0, 0); //thumbstick (or arrow keys)
    public static bool ButtonA, ButtonB, ButtonX, ButtonY; //buttons

    //public static Vector3 Aim = new Vector3(0, 0, 0); //right-thumbstick
    public static bool HasDirection => Direction.sqrMagnitude > 0.01; //ignore centre deadzone
    public void Update()
    {
        GetInput();
    }

    public static void GetInput()
    {
        //Thumbstick (or arrow keys)
        var h = Input.GetAxis("Horizontal"); //x-axis
        var v = Input.GetAxis("Vertical");   //z-axis
        Direction.Set(h, 0f, v);             //Set 'Direction' based on input.

        //Right thumbstick (for aiming)
        //h = Input.GetAxis("Axis4");
        //v = Input.GetAxis("Axis5");
        //Aim.Set(h, 0f, v);

        //Buttons
        ButtonA = Input.GetButton("Fire1"); //Left Shift
        ButtonB = Input.GetButton("Fire2"); //Left Alt
        ButtonX = Input.GetButton("Fire3"); //Left Ctrl
        ButtonY = Input.GetButton("Jump");  //Space
    }
}
