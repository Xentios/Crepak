using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    [SerializeField]
    private float fillSpeed = 1.0f;

    [SerializeField]
    private Image pointerEnterImage;


    private bool pointerInside = false;
    private RectTransform pointerRectTransform;

    private float timer = 0;
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        pointerRectTransform = pointerEnterImage.GetComponent<RectTransform>();
    }

    public void OnPointerEntered()
    {
        pointerInside = true;
        Debug.Log("Pointer entered.");
        timer = 0;
    }

    public void OnPointerExited()
    {
        Debug.Log("Pointer exited.");
        pointerEnterImage.transform.localScale = Vector3.zero;
        pointerInside = false;
        timer = 0;
    }

    private void Update()
    {
        if (pointerInside == true)
        {
            timer += Time.deltaTime;
            pointerEnterImage.transform.localScale += fillSpeed * Vector3.one * Time.deltaTime;
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            pointerRectTransform.position = mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
         pointerRectTransform as RectTransform,
         mousePosition,
         Camera.main,
         out Vector2 localPoint
     );

            if (timer > 2f)
            {
                SceneManager.LoadSceneAsync(0);
            }
            // pointerRectTransform.anchoredPosition = localPoint;
        }

    }

    public void OnClick()
    {
        Application.Quit();
    }


}
