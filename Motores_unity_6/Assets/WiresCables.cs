using UnityEngine;

public class WiresCables : MonoBehaviour
{
    bool Dragging;
    Vector3 OriginalPosition;
    bool Connected = false;

    public LineRenderer Line;
    public Transform EndWire;

    private void Start()
    {
        OriginalPosition = transform.position;
    }

    private void Update()
    {
        if (Dragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 convertedMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            convertedMousePosition.z = 0;
            SetPosition(convertedMousePosition);


            Vector3 endWireDifference = convertedMousePosition - EndWire.position;
            if (endWireDifference.magnitude < 1f)
            {
                SetPosition(EndWire.position);
                Dragging = false;
                Connected = true;
            }
        }
    }

    void SetPosition(Vector3 pPosition)
    {
        transform.position = pPosition;

        Vector3 positionDifference = pPosition - Line.transform.position;
        Line.SetPosition(2, positionDifference - new Vector3(.5f, 0, 0));
        Line.SetPosition(3, positionDifference + new Vector3(.15f, 0, 0));

    }

    void ResetPosition()
    {
        SetPosition(OriginalPosition);
    }
    private void OnMouseDown()
    {
        Dragging = true;
    }

    private void OnMouseUp()
    {
        Dragging = false;
        if (!Connected)
        {
            ResetPosition();
        }
    }

    public bool IsConnected()
    {
        return (Connected);
    }

    public void SetConnected(bool pConected)
    {
        Connected = pConected;
        if(!Connected)
        {
            ResetPosition() ;
        }
    }

}
