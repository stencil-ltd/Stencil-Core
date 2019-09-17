using System.Collections;
using Scripts.Maths;
using UniRx.Async;
using UnityEngine;

namespace Scripts.Util
{
    public static class AnimatorExtensions
    {
        public static void Replay(this Animator anim, string state)
            => anim.Play(state, 0, 0f);
        
        public static IEnumerator Await(this Animator anim, float leadTime = 0f)
        {
            yield return null;
            var duration = anim.GetCurrentAnimatorStateInfo(0).length;
            var norm = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            Debug.Log($"Animator awaiting {duration} - {leadTime} [norm: {norm}]");
            yield return new WaitForSeconds(duration - leadTime);
            Debug.Log($"Animator await finished");
        }

        public static async UniTask AwaitTask(this Animator anim, float leadTime = 0f)
        {
            await UniTask.DelayFrame(1);
            var duration = anim.GetCurrentAnimatorStateInfo(0).length;
            var norm = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            Debug.Log($"Animator awaiting {duration} - {leadTime} [norm: {norm}]");
            await UniTask.Delay((int) (1000 * (duration - leadTime).AtLeast(0)));
            Debug.Log($"Animator await finished");
        }
    }
}