using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Toast : MonoBehaviour, IPointerClickHandler
{
    private RectTransform rect;
    private string message;

    private Vector2 firstPosition;
    private Vector2 targetPosition;

    private bool isPlaying;
    private bool isOut;

    private int wordCount;

    private float speed = 1;

    public void Play(string message, Direction direction)
    {
        rect = GetComponent<RectTransform>();
        this.message = message;
        this.wordCount = message.Split(" ").Length;
        GetComponentInChildren<TextMeshProUGUI>().text = message;

        switch (direction)
        {
            case Direction.Up:
                rect.anchorMin = new Vector2(.5f, 1f);
                rect.anchorMax = new Vector2(.5f, 1f);
                rect.anchoredPosition += Vector2.up * rect.sizeDelta.y / 2;
                targetPosition = new Vector2(rect.anchoredPosition.x, -rect.anchoredPosition.y - 100);
                break;
            case Direction.Down:
                rect.anchorMin = new Vector2(.5f, 0f);
                rect.anchorMax = new Vector2(.5f, 0f);
                rect.anchoredPosition -= Vector2.up * rect.sizeDelta.y / 2;
                Debug.Log(rect.anchoredPosition);
                targetPosition = new Vector2(rect.anchoredPosition.x, -rect.anchoredPosition.y + 100);
                break;
        }
        firstPosition = rect.anchoredPosition;
        isPlaying = true;
    }

    private void Update()
    {
        if (isPlaying)
        {
            if (!isOut)
            {
                rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, targetPosition, speed * rect.sizeDelta.y * Time.deltaTime);

                if (rect.anchoredPosition == targetPosition)
                {
                    StartCoroutine(PlayOut());
                    isPlaying = false;
                }
            }
            else
            {
                rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, firstPosition, speed * rect.sizeDelta.y * Time.deltaTime);

                if (rect.anchoredPosition == firstPosition)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    IEnumerator PlayOut()
    {
        yield return new WaitForSeconds(Mathf.Clamp(wordCount * .25f, 1, float.MaxValue));
        isPlaying = true;
        isOut = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isOut)
        {
            StopCoroutine(PlayOut());
            isPlaying = true;
            isOut = true;
        }
    }
}