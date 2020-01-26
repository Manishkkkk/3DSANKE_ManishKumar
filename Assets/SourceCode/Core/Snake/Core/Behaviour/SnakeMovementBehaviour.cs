using Core.Gameplay;
using Core.Snake;
using UnityEngine;
using Zenject;

namespace Core.Gameplay
{
    public class SnakeMovementBehaviour : ISnakeMovement, ITickable
    {
        public ISnake Snake { get; private set; }

        private readonly SnakeSettings snakeSettings;
        private readonly GameManager gameManager;
        private float dis;
        private Transform currntBodyPart;
        private Transform prevBodyPart;

        public SnakeMovementBehaviour(GameManager gameManager, ISnake snake, SnakeSettings snakeSettings)
        {
            Snake = snake;
            this.snakeSettings = snakeSettings;
            this.gameManager = gameManager;
        }

        public void Tick()
        {
            if (gameManager.gameState != GameState.Process)
                return;
            Snake.Move();
            MoveSnakeBody();
        }

        private void MoveSnakeBody()
        {
            float currSpeed = snakeSettings.speed;


            if (Input.GetKey(KeyCode.W))
            {
                currSpeed *= 2;
            }

            Snake.BodyPart[0].Translate(Snake.BodyPart[0].forward * currSpeed * Time.smoothDeltaTime, Space.World);

            if (Input.GetAxis("Horizontal") != 0)
            {
                Snake.BodyPart[0].Rotate(Vector3.up * snakeSettings.rotationSpeed * Time.smoothDeltaTime * Input.GetAxis("Horizontal"));
            }
            for (int i = 1; i < Snake.BodyPart.Count; i++)
            {
                currntBodyPart = Snake.BodyPart[i];
                prevBodyPart = Snake.BodyPart[i - 1];

                dis = Vector3.Distance(prevBodyPart.position, currntBodyPart.position);

                Vector3 newPos = prevBodyPart.position;

                newPos.y = Snake.BodyPart[0].position.y;
                float T = Time.deltaTime * dis / snakeSettings.minDistance * currSpeed;
                if (T > 0.5f)
                    T = 0.5f;

                currntBodyPart.position = Vector3.Slerp(currntBodyPart.position, newPos, T);
                currntBodyPart.rotation = Quaternion.Slerp(currntBodyPart.rotation, prevBodyPart.rotation, T);
            }
        }

    }
}
