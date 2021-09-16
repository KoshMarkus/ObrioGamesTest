using DG.Tweening;
using OBRIOGamesTest.Project.Scripts.Managers;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OBRIOGamesTest.Project.Scripts
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image filling;
        [SerializeField] private float fadeDuration;
        [SerializeField] private float fillAmountDuration;

        [SerializeField] private UnityEvent onProgressComplete;
        
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FillProgressBar()
        {
            DoTweenManager.Instance.FadeIn(fadeDuration, canvasGroup);
            DoTweenManager.Instance.FillAmount(1, fillAmountDuration, filling,
                onEnd: () =>
                {
                    DoTweenManager.Instance.Fade(0, fadeDuration, canvasGroup, () =>
                    {
                        filling.fillAmount = 0f;
                        onProgressComplete.Invoke();
                    });
                });
        }
    }
}