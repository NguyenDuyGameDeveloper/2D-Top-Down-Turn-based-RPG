using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : BaseCharacter
{
    [Header("Preferences")]
    public PlayerInputActions input { get; private set; }

    [Header("Settings")]
    [SerializeField] private float moveDuration = .2f;
    [SerializeField] private bool isMoving = false;
    private Vector2Int moveDir;
    private Vector2Int gridPos;

    protected override void Awake()
    {
        input = new PlayerInputActions();
    }
    protected override void Start()
    {
        base.Start();

        gridPos = new Vector2Int(
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y));
        //stateMachine.Initialize(
    }
    private void OnEnable()
    {
        input.Enable();

        input.Player.Movement.performed += OnMovementPerformed;
    }
    private void OnDisable()
    {
        input.Player.Movement.performed -= OnMovementPerformed;

        input.Disable();
    }
    private void InitializeGridStartPos()
    {

    }
    private void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        Vector2 inputVector = ctx.ReadValue<Vector2>();

        moveDir = Vector2Int.RoundToInt(inputVector);

        TryMove(moveDir);
    }
    private void TryMove(Vector2Int moveDir)
    {
        //Debug.Log(IsWalkAble(moveDir));
        Debug.Log("Player pos: " + transform.position);
        if (isMoving || IsWalkAble(moveDir) == false) return;

        gridPos += moveDir;

        Vector2 targetPos = gridPos;/*transform.position + new Vector3(moveDir.x, moveDir.y);*/
        Debug.Log("Target pos: " + targetPos);
        StartCoroutine(MoveToPosition(targetPos));
        Debug.Log("Grid pos: " + gridPos);
    }
    private IEnumerator MoveToPosition(Vector3 targetPos)
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            float t = elapsed / moveDuration;
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;

        // Player Action complete
        // → EnemyManager.TakeAction();
    }
    public void MoveUp() => TryMove(Vector2Int.up);
    public void MoveDown() => TryMove(Vector2Int.down);
    public void MoveLeft() => TryMove(Vector2Int.left);
    public void MoveRight() => TryMove(Vector2Int.right);
    //protected override void HandleTerrainDetection()
    //{
        
    //}
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + moveDir.x, transform.position.y + moveDir.y));
    }
}
