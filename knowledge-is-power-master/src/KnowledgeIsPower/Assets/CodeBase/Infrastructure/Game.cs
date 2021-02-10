using CodeBase.Logic;
using CodeBase.Services.Inputs;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, LogicCurtain curtain)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain);
        }
    }
}