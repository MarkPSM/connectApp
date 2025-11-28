using Niantic.Lightship.AR.NavigationMesh;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class AgentRandomMove : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [FormerlySerializedAs("_navMeshManager")]
    [SerializeField]
    private LightshipNavMeshManager _navMeshManager;

    [FormerlySerializedAs("_agentPrefab")]
    [SerializeField]
    private GameObject agentPrefab;

    private GameObject _creature;
    private LightshipNavMeshAgent _agent;

    private InputAction _touch;
    private PlayerInput _playerInput;

    public bool canMove = true;
    public bool haveStarted = false;

    private void Awake()
    {
        if (haveStarted == true)
        {
            _playerInput = GetComponent<PlayerInput>();
            _touch = _playerInput.actions["Point"];
        }
    }

    private void FixedUpdate()
    {
        if (haveStarted == true)
        {
            if (_creature == null)
            {
                Vector3 randomposition;

                if (_navMeshManager.LightshipNavMesh.FindRandomPosition(out randomposition))
                {
                    _creature = Instantiate(agentPrefab, Vector3.zero, Quaternion.identity);
                    _creature.transform.position = randomposition;
                }
                else
                {
                    return;
                }

                _agent = _creature.GetComponent<LightshipNavMeshAgent>();
            }
            else
            {
                StartCoroutine(RandomMovement());

                Ray ray = _camera.ScreenPointToRay(_touch.ReadValue<Vector2>());

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    OnTouch(hit);
                }
            }
        }
    }

    private IEnumerator RandomMovement()
    {
        if (canMove)
        {
            Vector3 randompos;
            if (_navMeshManager.LightshipNavMesh.FindRandomPosition(out randompos))
                _agent.SetDestination(randompos);
            canMove = false;

            yield return new WaitForSeconds(10f);
            canMove = true;
        }
        else
        {

            yield return null;
        }
    }

    private void OnTouch(RaycastHit hit)
    {
        Ray ray = _camera.ScreenPointToRay(_touch.ReadValue<Vector2>());
            if (hit.collider.gameObject == _creature)
            {
                _agent.SetDestination(_camera.transform.position);
                canMove = false;
            }
    }
}
