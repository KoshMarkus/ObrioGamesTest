using OBRIOGamesTest.Project.Scripts.Managers;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace OBRIOGamesTest.Project.Scripts
{
    public class Counter : MonoBehaviour
    {
        public void TextColorJump(Transform targetTransform, float duration, Color color)
        {
            DoTweenManager.Instance.ChangeSize(targetTransform, 1.3f, duration/2, () =>
            {
                DoTweenManager.Instance.ChangeSize(targetTransform, 1.0f, duration/2);
            });

            DoTweenManager.Instance.ChangeTextMeshProGUITextColor(GetComponent<TextMeshProUGUI>(), 1f, color, () =>
            {
                DoTweenManager.Instance.ChangeTextMeshProGUITextColor(GetComponent<TextMeshProUGUI>(), 1f, Color.white);
            });
        }
    }
}
