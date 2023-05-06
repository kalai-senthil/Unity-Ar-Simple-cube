using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    private PlayerInput playerInput;
    private InputAction touchSpawnAction;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchSpawnAction = playerInput.actions["Spawn"];
    }
    private void OnEnable()
    {
        touchSpawnAction.performed += SpawnObject;
    }
    private void SpawnObject(InputAction.CallbackContext ctx)
    {
        Vector2 pos = ctx.ReadValue<Vector2>();
        Vector3 newPos = new Vector3(pos.x * .01f, pos.y * .01f, Random.Range(-10f, 10f)
);
        Instantiate(cube, newPos, Quaternion.identity);
        Debug.Log(newPos);
    }
    private void OnDisable()
    {
        touchSpawnAction.performed += SpawnObject;
    }
}
