using System;
using System.Drawing;
using System.Numerics;

namespace Physics
{
    abstract class PhysicsBody
    {
        public Vector2 position { get; set; } // posição no mundo
        private Vector2 oldPosition { get; set; } // posição anterior no mundo
        public Vector2 velocity { get; private set; }
        public abstract RectangleF bounds { get; } // a possivel caixa de colisão desse objeto
        protected readonly float Mass; // afeta a intensidade das colisões com outros 
        public readonly CollisionShape shape;

        public PhysicsBody(Vector2 position, float weight)
        {
            oldPosition = this.position = position;
            Mass = weight;
        }

        public PhysicsBody(float weight)
        {
            Mass = weight;
        }

        public abstract void DrawSelf(Graphics g);

        // move o objeto
        public void Move(Vector2 vector)
        {
            position += vector;
        }

        public void Move(float x, float y)
        {
            Move(new Vector2(x, y));
        }

        // move o objeto sem afetar a velocidade
        public void SetPosition(Vector2 vector)
        {
            oldPosition = position = vector;
        }

        public void SetPosition(float x, float y)
        {
            SetPosition(new Vector2(x, y));
        }

        public abstract void HandleCollision(PhysicsBody body);

        // retorna true se dois objetos estão se sobrepondo
        public abstract bool IsColliding(PhysicsBody target);

        public void Update(float dt)
        {
            velocity = position - oldPosition;
            oldPosition = position;
            position += velocity;
        }

        protected Color GetColor()
        {
            float colorSpeed = Math.Min(Math.Max(0, velocity.Length()), 5f) / 5f * 255f;
            return Color.FromArgb(0, (int)colorSpeed, 255 - (int)colorSpeed);
        }
    }
}
