using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    public bool isPressing;
    private Image bgImage;
    private Image joystickImage;
    public Vector2 inputDir { set; get; }
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        inputDir = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData) {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData) {
        inputDir = Vector2.zero;
        joystickImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData) {

        Vector2 pos = Vector2.zero;
        float bgImageSizeX = bgImage.rectTransform.sizeDelta.x;
        float bgImageSizeY = bgImage.rectTransform.sizeDelta.y;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, eventData.position, eventData.pressEventCamera, out pos)) {
            pos.x /= bgImageSizeX;
            pos.y /= bgImageSizeY;
            inputDir = new Vector2(pos.x, pos.y);
            inputDir = inputDir.magnitude > 1 ? inputDir.normalized: inputDir;            
            joystickImage.rectTransform.anchoredPosition = new Vector2(inputDir.x * (bgImageSizeX/offset), inputDir.y * (bgImageSizeY/offset));
        }

    }

}