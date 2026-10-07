using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    #region Info
    [Header("Preferences")]
    protected Rigidbody2D rb { get; private set; }
    protected Animator anim { get; private set; }
    protected StateMachine stateMachine { get; private set; }

    [Header("Settings")]
    protected bool nonMoveableTerrainDetected { get; private set; }
    protected bool facingDown { get; private set; } = true;
    protected bool facingRight { get; private set; } = false;
    protected Vector2Int facingDir { get; private set; } = new Vector2Int(0, -1);

    [Header("Character: Terrain Retricted")]
    [SerializeField] protected LayerMask whatIsNonMoveableTerrain;

    #endregion

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        stateMachine = new StateMachine();
    }
    protected virtual void Start() { }
    //protected virtual void Update() => stateMachine.UpdateActiveState();
    protected virtual void FixedUpdate() => HandleTerrainDetection();
    protected virtual void CharacterDeath() { }
    protected virtual void HandleTerrainDetection()
    {
        
    }
    protected virtual void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, Vector2.right);
        //Gizmos.DrawLine(transform.position, Vector2.left);
        //Gizmos.DrawLine(transform.position, Vector2.up);
        //Gizmos.DrawLine(transform.position, Vector2.down);
    }
    protected virtual bool IsWalkAble(Vector2Int moveDir) => !Physics2D.Raycast
    (transform.position, moveDir, 1f, whatIsNonMoveableTerrain);
}
