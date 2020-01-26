using System.Collections.Generic;
using UnityEngine;
public class Snake : ISnake
{
    public List<Transform> BodyPart { get; set; }

    public Snake(SnakeSettings snakeSettings)
    {
        BodyPart = snakeSettings.bodyParts;
    }

    public void AddBodyPart(Transform part)
    {
        BodyPart.Add(part);
    }

    public void Move()
    {
       
    }
}
