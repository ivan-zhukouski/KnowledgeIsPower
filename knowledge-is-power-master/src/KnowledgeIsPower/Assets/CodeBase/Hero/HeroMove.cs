using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using CodeBase.Services.Inputs;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroMove : MonoBehaviour
    {
        private IInputService _inputService;
        public CharacterController CharacterController;
       
        private Camera _camera;
        public float MovementSpeed;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            Debug.Log(_inputService.Axis);
        }

        private void Update()
        {
            
            Vector3 movementVector = Vector3.zero;
           
            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = Camera.main.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
               
            CharacterController.Move(movementVector * (MovementSpeed * Time.deltaTime));
        }
    }
}
