using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class Exemple_InputKeyboard : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.Space;
    [HorizontalLine(color: EColor.Blue)]
    public KeyCode upKey = KeyCode.Z;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.Q;
    public KeyCode rightKey = KeyCode.D;

    [HorizontalLine(color: EColor.Red)]
    public UnityEvent onJump;
    public UnityEvent onClickDroit;
    public UnityEvent onClickGauche;
    public UnityEvent<Vector2> onMove;

    [Button]
    public void SwitchToAZERTY()
    {
        upKey = KeyCode.Z;
        downKey = KeyCode.S;
        leftKey = KeyCode.Q;
        rightKey = KeyCode.D;
    }
    [Button]
    public void SwitchToQWERTY()
    {
        upKey = KeyCode.W;
        downKey = KeyCode.S;
        leftKey = KeyCode.A;
        rightKey = KeyCode.D;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space key is pressed");
            onJump?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button is pressed");
            onClickGauche?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right mouse button is pressed");
            onClickDroit?.Invoke();
        }

        Vector2 movement = Vector2.zero;
        if (Input.GetKey(upKey)) movement += Vector2.up;
        if (Input.GetKey(downKey)) movement += Vector2.down;
        if (Input.GetKey(leftKey)) movement += Vector2.left;
        if (Input.GetKey(rightKey)) movement += Vector2.right;
        // Normalize the movement vector to ensure diagonal movement isn't faster
        if (movement.magnitude > 1) movement.Normalize();
        onMove?.Invoke(movement);
    }
}
