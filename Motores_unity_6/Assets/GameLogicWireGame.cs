using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameLogicWireGame : MonoBehaviour
{

    public List<WiresCables> Wires;


    void ShuffleWires()
    {
        List<Vector3> endWirePositions = new List<Vector3>();
        foreach (WiresCables w in Wires)
        {
            Vector3 pos = w.EndWire.position;
            endWirePositions.Add(pos);
        }
        foreach (WiresCables w in Wires)
        {
            int randomIndex = Random.Range(0, endWirePositions.Count);
            w.EndWire.position = endWirePositions[randomIndex];
            endWirePositions.RemoveAt(randomIndex);
        }
    }
    void Start()
    {
        ShuffleWires();   
    }

    // Update is called once per frame
    void Update()
    {
        int connectedWires = 0;
        foreach (WiresCables w in Wires)
        {
            if (w.IsConnected())
            {
                connectedWires++;
            }
        }

        if (connectedWires == Wires.Count)
        {
            //ResetWires();
            Debug.Log("GGS");
        }
    }

    public void ResetWires()
    {
        foreach (WiresCables w in Wires)
        {
            w.SetConnected(false);
        }
        ShuffleWires();
    }


}
