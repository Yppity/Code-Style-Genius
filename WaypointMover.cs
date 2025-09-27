using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointsParent;

    private Transform[] _waypoints;
    private int _currentWaypointIndex;

    private void Start()
    {
        int count = _waypointsParent.childCount;
        _waypoints = new Transform[count];

        for (int i = 0; i < count; i++)
            _waypoints[i] = _waypointsParent.GetChild(i);
    }

    private void Update()
    {
        Transform targetPoint = _waypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == targetPoint.position) 
            MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;

        Vector3 direction = _waypoints[_currentWaypointIndex].transform.position;
        transform.forward = direction - transform.position;
    }
}
