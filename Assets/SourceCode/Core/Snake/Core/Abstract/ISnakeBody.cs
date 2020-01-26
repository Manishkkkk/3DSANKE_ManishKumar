using System.Collections.Generic;
using UnityEngine;
namespace Core.Snake
{
    public interface ISnakeBody
    {
        List<Transform> BodyPart { get; }
    }
}