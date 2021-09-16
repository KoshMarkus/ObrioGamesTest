using System.Collections;
using OBRIOGamesTest.Project.Scripts.Managers;
using UnityEngine;
using TMPro;

namespace OBRIOGamesTest.Project.Scripts
{
    public class MessagePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI messageField;
        [SerializeField] private float fadeDuration;
        [SerializeField] private float showDuration;
        
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void ShowMessage(string text)
        {
            StartCoroutine(ShowMessageForATime(text));
        }
        
        private IEnumerator ShowMessageForATime(string text)
        {
            messageField.text = text;
            
            DoTweenManager.Instance.FadeIn(fadeDuration, canvasGroup);
            yield return new WaitForSeconds(showDuration);
            DoTweenManager.Instance.FadeOut(fadeDuration, canvasGroup);
        }
    }
}