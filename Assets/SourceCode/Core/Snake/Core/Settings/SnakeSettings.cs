using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SnakeSettings
{
    public List<Transform> bodyParts;
    [Space]
    public float minDistance = 1f;
    public float speed = 1f;
    public float rotationSpeed = 50f;
    public GameObject snakeBody;
    public int beginSize = 1;
}
