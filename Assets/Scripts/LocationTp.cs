using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LocationTp : MonoBehaviour
{
    [SerializeField] Image tpFade;
    [SerializeField] float fadeSpeed = 2f;
    [SerializeField] Transform menu;
    [SerializeField] InputActionReference toogleMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        tpFade.gameObject.SetActive(false);
        Color monke = tpFade.color;
        monke.a = 0;
        tpFade.color = monke;

    }

    private void OnEnable()
    {
        toogleMenu.action.performed += ToggleMenu;
    }

    private void OnDisable()
    {
        toogleMenu.action.performed += ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        menu.gameObject.SetActive(!menu.gameObject.activeSelf);
    }

    public void Teleport(Transform targetPos)
    {
        StartCoroutine(FadeTp(targetPos));
    }

    IEnumerator FadeTp(Transform targetPos) 
    {
        tpFade.gameObject.SetActive(true);
        Color monke = tpFade.color;
        while (tpFade.color.a<1)
        {
            monke.a += fadeSpeed*Time.deltaTime;
            tpFade.color = monke;
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPos.position;
        while (tpFade.color.a > 0)
        {
            monke.a -= fadeSpeed * Time.deltaTime;
            tpFade.color = monke;
            yield return new WaitForEndOfFrame();
        }
        tpFade.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }
}
