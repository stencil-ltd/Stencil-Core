using UniRx.Async;

namespace Scripts.Extensions.LeanTween
{
    public static class LeanTweenAsync
    {
        public static async UniTask Await(this LTDescr lt)
        {
            var ready = false;
            lt.setOnComplete(() => ready = true);
            await UniTask.WaitUntil(() => ready);
        }
    }
}