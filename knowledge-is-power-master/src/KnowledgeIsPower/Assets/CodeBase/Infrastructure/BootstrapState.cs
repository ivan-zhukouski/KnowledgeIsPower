using System;
using System.Net.Mime;
using CodeBase.Services.Inputs;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
           RegisterServices();
           _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>("Main");
        }

        private  void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }

        public void Exit()
        {
            
        }

        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
                
                return new StandAloneInputService();
            else
            {
                return new MobileInputService();
            }
        }
        
    }
}