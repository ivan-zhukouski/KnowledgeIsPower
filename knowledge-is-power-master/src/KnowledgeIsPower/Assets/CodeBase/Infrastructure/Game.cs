using CodeBase.Services.Inputs;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public Game()
        {
            RegisterInputService();
            
        }

        private static void RegisterInputService()
        {
            if (Application.isEditor)
                InputService = new StandAloneInputService();
            else
            {
                InputService = new MobileInputService();
            }
               
        }
    }
}