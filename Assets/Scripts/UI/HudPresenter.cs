using UnityEngine;
using UnityEngine.UI;
using ClickSpace.Messiah.Core;

namespace ClickSpace.Messiah.UI
{
    public class HudPresenter : MonoBehaviour
    {
        [SerializeField] private Text tickText;
        [SerializeField] private Text followersText;
        [SerializeField] private Text resourcesText;
        [SerializeField] private Text statusText;

        public void Bind(RunState state)
        {
            if (tickText != null)
            {
                tickText.text = $"Tick: {state.Tick}";
            }

            if (followersText != null)
            {
                followersText.text = $"Followers: {state.Followers}";
            }

            if (resourcesText != null)
            {
                resourcesText.text = $"Faith {state.Faith:0.0} | Fund {state.Fund:0.0} | Trust {state.Trust:0.0} | Stability {state.Stability:0.0}";
            }

            if (statusText != null)
            {
                statusText.text = $"Last: {state.LastEventId} | Ending: {state.EndingType}";
            }
        }
    }
}
