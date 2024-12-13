using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelsBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CarMinigameController _controller;
    private DragScript dragScript;
    private float currentHoldTime;
    private bool screwable;
    private Vector3 originalScale;
    public float screwableTime;
    public float reductionFactor;

    private void Start()
    {
        _controller = FindFirstObjectByType<CarMinigameController>();
        dragScript = GetComponent<DragScript>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (dragScript.snaped)
        {
            screwable = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (dragScript.snaped)
        {
            _controller.audioSource.Stop();
            screwable = false;
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && screwable && !dragScript.screwed)
        {
            currentHoldTime += Time.deltaTime;

            if (currentHoldTime >= screwableTime)
            {
                if (_controller.audioSource.clip != _controller.audioClips[0] || !_controller.audioSource.isPlaying)
                {
                    _controller.audioSource.clip = _controller.audioClips[0];
                    _controller.audioSource.Play();
                }

                dragScript.screwed = true;
                _controller.wheelsScrewed += 1;
                _controller.CheckIfEnded();
                Debug.Log("Se ha atornillado");
            }
            else
            {
                if (_controller.audioSource.clip != _controller.audioClips[1] || !_controller.audioSource.isPlaying)
                {
                    _controller.audioSource.clip = _controller.audioClips[1];
                    _controller.audioSource.Play();
                }

                float scaleProgress = Mathf.Lerp(1f, reductionFactor, currentHoldTime);

                if ((originalScale * scaleProgress).magnitude >= new Vector3(1,1,1).magnitude)
                {
                    transform.localScale = originalScale * scaleProgress;
                }

            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                _controller.audioSource.Stop();
            }

            currentHoldTime = 0;

            if (!dragScript.screwed)
            {
                StopCoroutine("ResizeWheel");
                StartCoroutine(ResizeWheel(originalScale));
            }
        }
    }

    private IEnumerator ResizeWheel(Vector3 targetScale)
    {
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.5f * Time.deltaTime);
            yield return null;
        }

        transform.localScale = targetScale;
    }

}
