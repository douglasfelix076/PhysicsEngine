using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace Physics
{
    class PhysicsWorld
    {
        public float gravity { get; set; }
        public float radius { get; set; }
        public Vector2 position { get; set; }
        private Vector2 center => position + new Vector2(radius, radius);
        public int BodyCount => quad.GetBodies().Count;

        private const int MaxIterations = 3;
        private readonly Quad quad;


        public PhysicsWorld(Vector2 position, float gravity, float radius)
        {
            this.position = position;
            this.gravity = gravity;
            this.radius = radius;
            quad = new Quad(new RectangleF(-radius, -radius, radius * 2, radius * 2));
        }

        public RectangleF bounds => new RectangleF(position.X, position.Y, radius * 2, radius * 2);

        public void AddBody(PhysicsBody body)
        {
            quad.Insert(body);
        }

        public void AddBody(PhysicsBody body, Vector2 position)
        {
            body.SetPosition(center + position);
            quad.Insert(body);
        }

        public void Clear()
        {
            quad.ClearAll();
        }

        public void Update(float dt)
        {
            quad.Update();   
            Parallel.ForEach(quad.GetBodies(), (bodyA) =>
            {
                // quad.Retrieve pega todos os objetos em uma area que podem
                // colidir com este objeto
                List<PhysicsBody> objectsToCollide = quad.Retrieve(bodyA.bounds);

                //gravidade
                bodyA.Move(0, gravity * dt * dt);

                if (objectsToCollide.Count != 0)
                {
                    for (int j = 0; j < Math.Min(MaxIterations, objectsToCollide.Count); j++)
                    {
                        for (int k = 0; k < objectsToCollide.Count; k++)
                        {
                            PhysicsBody bodyB = objectsToCollide[k];
                            if (bodyA.IsColliding(bodyB))
                            {
                                bodyA.HandleCollision(bodyB);
                            }
                        }
                    }
                }

                // impedir o objeto de sair pra fora do mundo
                if (bodyA is CircleBody circleBody)
                {
                    var fromTo = center - circleBody.position;
                    float distToBorder = fromTo.Length() + circleBody.Radius;
                    if (distToBorder > radius)
                    {
                        circleBody.Move(Vector2.Normalize(fromTo) * (distToBorder - radius));
                    }

                }
                else if (bodyA is BoxBody boxBody)
                {
                    // a ser adicionado
                }

                bodyA.Update(dt);
            });
        }

        public void Draw(Graphics g)
        {
            // desenha o mundo ligeiramente menor pra evitar um pequeno bug visual
            float newSize = (radius - 1) / radius;
            g.ScaleTransform(newSize, newSize);

            // move o mundo para o centro da tela independente da posição
            g.TranslateTransform(-position.X, -position.Y);

            g.DrawEllipse(new Pen(Color.Black), bounds);

            //g.DrawEllipse(new Pen(Color.Black), new RectangleF(0f, 0f, radius * 2, radius * 2));

            foreach (PhysicsBody body in quad.GetBodies())
            {
                body.DrawSelf(g);
            }

            // Descomente para ver o numero de objetos em cada plano
            //quad.Draw(g);
        }

        public void OnResize(float newRadius)
        {
            radius = newRadius;
            // também é necessario atualizar a area dos planos
            quad.UpdateBounds(new RectangleF(-radius, -radius, radius * 2, radius * 2));
        }
    }
}
