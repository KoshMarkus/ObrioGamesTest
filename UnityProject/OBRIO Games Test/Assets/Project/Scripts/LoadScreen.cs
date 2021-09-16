using System.Collections;
using OBRIOGamesTest.Project.Scripts.Managers;
using UnityEngine;

namespace OBRIOGamesTest.Project.Scripts
{
    public class LoadScreen : MonoBehaviour
    {
        [SerializeField] private float timeBeforeHide;
        [SerializeField] private float fadeDuration;
        
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            StartCoroutine(Hide());
        }

        private IEnumerator Hide()
        {
            yield return new WaitForSeconds(timeBeforeHide);
            DoTweenManager.Instance.FadeOut(fadeDuration, canvasGroup);
        }
    }
}