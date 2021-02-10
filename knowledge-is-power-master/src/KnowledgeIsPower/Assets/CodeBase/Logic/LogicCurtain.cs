﻿using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    public class LogicCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void ShowCurtain()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1f;
        }

        public void HideCurtain() => 
            StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
            gameObject.SetActive(false);
        }
    }
}