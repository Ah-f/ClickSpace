using UnityEngine;

namespace ClickSpace.Messiah.Core
{
    public class GameTickSystem : MonoBehaviour
    {
        [SerializeField] private float tickSeconds = 1.0f;
        private float elapsed;

        public RunState State { get; private set; } = new RunState();

        private void Update()
        {
            elapsed += Time.deltaTime;
            if (elapsed < tickSeconds) return;

            elapsed = 0f;
            State.Tick += 1;
        }
    }
}
