using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Physics
{
    // Classe "Mestre"
    class Quad : QuadNode
    {
        // contém todos os objetos incluindo os sub-planos
        private readonly List<PhysicsBody> allBodies;
        
        public List<PhysicsBody> GetBodies() => allBodies;

        public Quad(RectangleF _bounds) : base(0, _bounds)
        {
            allBodies = new List<PhysicsBody>();
        }

        public override void Insert(PhysicsBody body)
        {
            allBodies.Add(body);
        }

        public void ClearAll()
        {
            allBodies.Clear();
            Clear();
        }

        public void Update()
        {
            // atualiza a posição dos objetos
            Clear();
            for (int i = 0; i < allBodies.Count; i++)
            {
                base.Insert(allBodies[i]);
            }
        }
    }

    class QuadNode
    {
        private const int MaxObjects = 5;
        private const int MaxLevels = 4; // numero de vezes que o plano pode se dividir
        private readonly int level;
        private readonly List<PhysicsBody> bodies; // contém todos os objetos no plano atual
        private readonly QuadNode[] nodes;
        private RectangleF bounds;

        private static readonly Font font = new Font("Arial", 16);
        private static readonly SolidBrush brush = new SolidBrush(Color.Black);
        private static readonly StringFormat format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        protected QuadNode(int _level, RectangleF _bounds)
        {
            level = _level;
            bodies = new List<PhysicsBody>();
            nodes = new QuadNode[4];
            bounds = _bounds;
        }

        public virtual void Insert(PhysicsBody body)
        {
            if (nodes[0] != null)
            {
                int index = GetIndex(body.bounds);
                if (index != -1)
                {
                    nodes[index].Insert(body);
                    return;
                }
            }

            bodies.Add(body);

            if (bodies.Count > MaxObjects && level < MaxLevels)
            {
                if (nodes[0] == null)
                {
                    Split();
                }

                int i = 0;
                while (i < bodies.Count)
                {
                    int index = GetIndex(bodies[i].bounds);
                    if (index != -1)
                    {
                        nodes[index].Insert(bodies[i]);
                        bodies.Remove(bodies[i]);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        public void Split()
        {
            float width = bounds.Width / 2;
            float height = bounds.Height / 2;
            float x = bounds.X;
            float y = bounds.Y;
            nodes[0] = new QuadNode(level + 1, new RectangleF(x + width, y, width, height));
            nodes[1] = new QuadNode(level + 1, new RectangleF(x, y, width, height));
            nodes[2] = new QuadNode(level + 1, new RectangleF(x, y + height, width, height));
            nodes[3] = new QuadNode(level + 1, new RectangleF(x + width, y + height, width, height));
        }

        public int GetIndex(RectangleF box)
        {
            float midX = bounds.X + bounds.Width / 2;
            float midY = bounds.Y + bounds.Height / 2;
            bool Left = box.X < midX && box.X + box.Width < midX;
            bool Top = box.Y < midY && box.Y + box.Height < midY;
            bool Right = box.X > midX;
            bool Bottom = box.Y > midY;

            if (Left)
            {
                if (Top)
                    return 1;
                if (Bottom)
                    return 2;
            }
            else if (Right)
            {
                if (Top)
                    return 0;
                if (Bottom)
                    return 3;
            }
            return -1;
        }

        public List<PhysicsBody> Retrieve(RectangleF box)
        {
            List<PhysicsBody> returnObjects = new List<PhysicsBody>();
            int index = GetIndex(box);
            if (index != -1 && nodes[0] != null)
            {
                returnObjects = (nodes[index].Retrieve(box));
            }

            returnObjects.AddRange(bodies);
            return returnObjects;
        }

        public void Clear()
        {
            bodies.Clear();

            if (nodes[0] != null)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    nodes[i].Clear();
                    nodes[i] = null;
                }
            }
        }

        public void Draw(Graphics g)
        {
            if (nodes[0] != null)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    nodes[i].Draw(g);
                }
            }

            g.DrawRectangle(new Pen(Color.Black), new Rectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height));
            g.DrawString("b: " + bodies.Count, font, brush, bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2, format);
        }

        public void UpdateBounds(RectangleF newBounds)
        {
            bounds = newBounds;

            if (nodes[0] != null)
            {
                float width = bounds.Width / 2;
                float height = bounds.Height / 2;
                float x = bounds.X;
                float y = bounds.Y;
                nodes[0].UpdateBounds(new RectangleF(x + width, y, width, height));
                nodes[1].UpdateBounds(new RectangleF(x, y, width, height));
                nodes[2].UpdateBounds(new RectangleF(x, y + height, width, height));
                nodes[3].UpdateBounds(new RectangleF(x + width, y + height, width, height));
            }
        }
    }
}
