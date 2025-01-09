using UnityEngine;

public class PoweredWireBehaviuor : MonoBehaviour
{

    bool mouseDown = false;
    public PoweredWireStatus powerWires;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerWires = gameObject.GetComponent<PoweredWireStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWire();
    }

    private void OnMouseDown()
    {
        mouseDown = true;
    }

    private void OnMouseOver()
    {
        powerWires.movable = true;
    }

    private void OnMouseExit()
    {
        if (!powerWires.moving)
        {
            powerWires.movable = false;
        }
    }

    private void OnMouseUp()
    {
        mouseDown = false;
        gameObject.transform.position = powerWires.startPosition;
    }

    void MoveWire()
    {
        if (mouseDown && powerWires.movable)
        {
            powerWires.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 1));
        }
        else
        {
            powerWires.moving = false;
        }
    }
}
