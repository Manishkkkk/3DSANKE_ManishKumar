using UnityEngine;
namespace Core.Food
{
    public interface ISpawnArea
    {
        Vector3 Center { get; }
        Vector3 Size { get; }
    }
}