using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader instance;

    Image myImage;

    private void Awake()
    {
        if (instance) Destroy(instance.gameObject);
        else instance = this;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// duringBlackActions occur while the screen is black
    /// postActions occur after the fade is done
    /// </summary>
    public void ScreenFade(Action duringBlackActions = null, Action postActions = null)
    {
        gameObject.SetActive(true);
        if (!myImage) myImage = GetComponent<Image>();
        StartCoroutine(Fade(duringBlackActions, postActions));
    }

    IEnumerator Fade(Action duringBlackActions = null, Action postActions = null)
    {
        float start = 0F;
        float startTime = Time.unscaledTime;
        float time = 0F;
        Color fader = myImage.color;

        while (time < 2F)
        {
            fader.a = Mathf.Lerp(start, 1 - start, time);
            time = (Time.unscaledTime - startTime);
            myImage.color = fader;
            yield return null;
        }

        if (duringBlackActions != null) duringBlackActions();

        time = 0F;
        start = 1F;
        startTime = Time.unscaledTime;
        while (time < 2F)
        {
            fader.a = Mathf.Lerp(start, 1 - start, time);
            time = (Time.unscaledTime - startTime);
            myImage.color = fader;
            yield return null;
        }

        if (postActions != null) postActions();
        gameObject.SetActive(false);
    }
}
