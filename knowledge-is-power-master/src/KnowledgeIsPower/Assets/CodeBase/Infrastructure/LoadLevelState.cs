using CodeBase.CameraLogic;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialpointTag = "InitialPoint";
        private const string HeroPath = "Hero/hero";
        private const string HudPath = "Hud/Hud";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LogicCurtain _curtain;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LogicCurtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.ShowCurtain();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => 
            _curtain.HideCurtain();

        private void OnLoaded()
        {
            GameObject initialPoint = GameObject.FindWithTag(InitialpointTag);
            GameObject hero = Instantiate(HeroPath, initialPoint.transform.position);
            Instantiate(HudPath);
            CameraFollow(hero);
            _gameStateMachine.Enter<GameLoopState>();
        }
        
        private void CameraFollow(GameObject hero) => Camera.main.GetComponent<CameraFollow>().Following(hero);

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}