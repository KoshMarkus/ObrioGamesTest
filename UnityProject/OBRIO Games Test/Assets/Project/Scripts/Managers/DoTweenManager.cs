using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OBRIOGamesTest.Project.Scripts.Managers
{
    public class DoTweenManager : MonoBehaviour
    {
        public static DoTweenManager Instance;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public void ChangeTextMeshProGUITextColor(TextMeshProUGUI text, float duration, Color color, TweenCallback onEnd = null)
        {
            text.DOColor(color, duration/2).onComplete += onEnd;
        }
        
        public void ChangeSize(Transform targetTransform, float finalScale, float duration, TweenCallback onEnd = null)
        {
            targetTransform.DOScale(finalScale, duration).onComplete += onEnd;
        }
        
        public void MoveTo(float duration, Transform transformToMove, Transform targetTransform, TweenCallback onEnd = null)
        {
            transformToMove.DOMove(targetTransform.position, duration, false).onComplete += onEnd;
        }
        
        public void JumpTo(float duration, Transform transformToMove, Transform targetTransform, TweenCallback onEnd = null)
        {
            transformToMove.DOJump(targetTransform.position, 1f, 1, duration, false).onComplete += onEnd;
        }

        public void FillAmount(float endValue, float duration, Image image, TweenCallback onEnd = null)
        {
            image.DOFillAmount(endValue, duration).onComplete += onEnd;
        }
        
        public void FadeIn(float duration, CanvasGroup canvasGroup)
        {
            Fade(1f, duration, canvasGroup, () =>
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            });
        }

        public void FadeOut(float duration, CanvasGroup canvasGroup)
        {
            Fade(0f, duration, canvasGroup, () =>
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            });
        }
        
        public void Fade(float endValue, float duration, CanvasGroup canvasGroup, TweenCallback onEnd = null)
        {
            canvasGroup.DOFade(endValue, duration).onComplete += onEnd;
        }
    }
}
