using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MinijuegoDeMierda : MonoBehaviour
{
    public List<Color> _wireColors = new List<Color>();
    public List<CablesDeMierda> _leftWires = new List<CablesDeMierda>();
    public List<CablesDeMierda> _rightWires = new List<CablesDeMierda>();

    public CablesDeMierda CurrentDraggedWire;
    public CablesDeMierda CurrentHoveredWire;

    public bool IsTaskCompleted = false;

    private List<Color> _availableColors;
    private List<int> _availableLeftWireIndex;
    private List<int> _availableRightWireIndex;

    GameManager GameManager;

    private void Awake()
    {
        GameManager = FindFirstObjectByType<GameManager>();
    }
    private void Start()
    {
        
        _availableColors = new List<Color>(_wireColors);
        _availableLeftWireIndex = new List<int>();
        _availableRightWireIndex = new List<int>();

        for (int i = 0; i < _leftWires.Count; i++)
        {
            _availableLeftWireIndex.Add(i);
        }

        for (int i = 0; i < _rightWires.Count; i++)
        {
            _availableRightWireIndex.Add(i);
        }

        while (_availableColors.Count > 0 &&
               _availableLeftWireIndex.Count > 0 &&
               _availableRightWireIndex.Count > 0)
        {
            Color pickedColor =
             _availableColors[Random.Range(0, _availableColors.Count)];

            int pickedLeftWireIndex = Random.Range(0,
                                      _availableLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0,
                                      _availableRightWireIndex.Count);
            _leftWires[_availableLeftWireIndex[pickedLeftWireIndex]]
                                              .SetColor(pickedColor);
            _rightWires[_availableRightWireIndex[pickedRightWireIndex]]
                                              .SetColor(pickedColor);

            _availableColors.Remove(pickedColor);
            _availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            _availableRightWireIndex.RemoveAt(pickedRightWireIndex);
        }

        StartCoroutine(CheckTaskCompletion());
    }

    private IEnumerator CheckTaskCompletion()
    {
        while (!IsTaskCompleted)
        {
            int successfulWires = 0;

            for (int i = 0; i < _rightWires.Count; i++)
            {
                if (_rightWires[i].IsSuccess) { successfulWires++; }
            }
            if (successfulWires >= _rightWires.Count)
            {
                GameManager.miniGameWiresCompleted = true;
                GameManager.personaje.SetActive(true);
                GameManager.pauseMenu.SetActive(true);
                GameManager.GameplayCanvas.SetActive(true);
                GameManager.miniGameWireCanvas.SetActive(false);
                Debug.Log("TASK COMPLETED");
            }
            else
            {
                Debug.Log("TASK INCOMPLETED");
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
