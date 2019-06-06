using Currencies;
using UnityEngine;
using UnityEngine.UI;

namespace Dev
{
    [RequireComponent(typeof(Button))]
    public class MoneyButton : MonoBehaviour
    {
        public Price[] Grants = { };
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                foreach (var g in Grants)
                {
                    if (g == null || g.Currency == null) continue;
                    g.Currency.Add(g.GetAmount()).AndSave();
                }
            });
        }
    }
}