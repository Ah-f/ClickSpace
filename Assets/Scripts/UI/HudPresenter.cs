using UnityEngine;
using UnityEngine.UI;
using ClickSpace.Messiah.Core;

namespace ClickSpace.Messiah.UI
{
    public class HudPresenter : MonoBehaviour
    {
        [SerializeField] private Text tickText;

        public void Bind(RunState state)
        {
            if (tickText != null)
            {
                tickText.text = $"Tick: {state.Tick}";
            }
        }
    }
}
