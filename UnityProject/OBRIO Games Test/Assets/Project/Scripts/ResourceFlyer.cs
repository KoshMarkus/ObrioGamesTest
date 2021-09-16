using OBRIOGamesTest.Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace OBRIOGamesTest.Project.Scripts
{
    public class ResourceFlyer : MonoBehaviour
    {
        [SerializeField] private float flyDuration;
        [SerializeField] private UnityEvent onMoveEnd;
        [SerializeField] private Vector3 startPosition;

        private void Awake()
        {
            startPosition = transform.position;
        }

        public void MoveToTarget(Transform target)
        {
            DoTweenManager.Instance.MoveTo(flyDuration, transform, target, () =>
            {
                onMoveEnd.Invoke();
            });
            
            JumpSize();
        }
        
        public void JumpToTarget(Transform target)
        {
            DoTweenManager.Instance.JumpTo(flyDuration, transform, target);
            JumpSize();
        }

        private void JumpSize()
        {
            DoTweenManager.Instance.ChangeSize(transform, 1, flyDuration/2, 
                () => DoTweenManager.Instance.ChangeSize(transform, 0, flyDuration / 2, () =>
                {
                    transform.position = startPosition;
                }));
        }
        
    }
}
