using UnityEngine;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject lightOn;
    private Vector3 startPoint;       // Fixed start position of the wire
    private Vector3 startPosition;   // Original position of the wire
    private Vector2 originalSize;    // Original size of the wireEnd

    void Start()
    {
        // Initialize starting values
        startPoint = transform.parent.position;
        startPosition = transform.position;
        originalSize = wireEnd.size; // Save the initial size of the wireEnd
    }

    private void OnMouseDrag()
    {
        // Get the mouse position in world space
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0; // Ensure the wire stays in the 2D plane

        // check for nearby connection
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);

        foreach (Collider2D collider in colliders)
        {
            // make sure its not my own collider
            if (collider.gameObject != gameObject)
            {
                // update wire to the connection point position
                UpdateWire(collider.transform.position);
                
                // check if wires are the same color
                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    //finish step
                    collider.GetComponent<Wire>()?.Done();
                    Done();

                }

                return;


            }

        }

        // Update wire during drag
        UpdateWire(newPosition);
    }

    void Done()
    {
        // turn on light
        lightOn.SetActive(true);

        //destroy the script
        Destroy(this);

    }

    private void OnMouseUp()
    {
        // Reset the wire to its original position and size when released
        ResetWire();
    }

    void UpdateWire(Vector3 newPosition)
    {
        // Update position of the main wire object
        transform.position = newPosition;

        // Calculate direction and distance
        Vector3 direction = newPosition - startPoint;
        transform.right = direction.normalized; // Rotate the wire to face the drag direction

        // Update the wireEnd's size based on the distance
        float distance = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(distance, originalSize.y);
    }

    void ResetWire()
    {
        // Reset the wire's position and size
        transform.position = startPosition;
        transform.right = Vector3.right; // Reset rotation to default
        wireEnd.size = originalSize;     // Restore the original size of the wireEnd
    }
}
