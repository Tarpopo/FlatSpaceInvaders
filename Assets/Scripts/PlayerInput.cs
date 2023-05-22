using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction<Vector2> OnMove;
    public event UnityAction OnShoot;
    private UserInput _userInput;

    private void Awake() => _userInput = new UserInput();

    private void OnEnable()
    {
        _userInput.Enable();
        _userInput.User.Shoot.performed += InvokeShoot;
    }

    private void OnDisable()
    {
        _userInput.Disable();
        _userInput.User.Shoot.performed -= InvokeShoot;
    }

    private void InvokeShoot(InputAction.CallbackContext context) => OnShoot?.Invoke();

    private void Update()
    {
        if (_userInput.User.Move.IsPressed() == false) return;
        OnMove?.Invoke(_userInput.User.Move.ReadValue<Vector2>());
    }
}