namespace Test4
{
    public abstract class Primitive
    {
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected Point position;
        protected int size;
        protected Brush brush = Brushes.Yellow;
        protected Pen outlinePen = new Pen(Color.Black, 2);
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
        public Primitive(int initialSize)
        {
            size = initialSize;
            position = new Point(0, 0);
        }

        public void SetPosition(Point newPosition)
        {
            position = newPosition;
        }

        public void SetSize(int newSize)
        {
            if (newSize < 300)
                size = Math.Max(10, newSize);
        }

        public abstract void Draw(Graphics graphics);
    }

    public partial class Form1 : Form
    {
        private Primitive currentPrimitive;
        private string selectedPrimitive = "Квадоат"; 
        private int size = 50; 
        private bool isDragging = false; 
        private Point lastMousePosition;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.Paint += Form1_Paint;
        }

        private void InitializeComboBox()
        {
            ComboBoxPrimitives.Items.Add("Квадоат");
            ComboBoxPrimitives.Items.Add("Треугольник");
            ComboBoxPrimitives.Items.Add("Круг");
            ComboBoxPrimitives.SelectedIndex = 0;
            ComboBoxPrimitives.SelectedIndexChanged += ComboBoxPrimitives_SelectedIndexChanged;
            CreateCurrentPrimitive();
        }

        private void ComboBoxPrimitives_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPrimitive = ComboBoxPrimitives.SelectedItem.ToString();
            CreateCurrentPrimitive();
            Invalidate();
        }

        private void CreateCurrentPrimitive()
        {
            switch (selectedPrimitive)
            {
                case "Квадоат":
                    currentPrimitive = new RectanglePrimitive(size);
                    break;

                case "Треугольник":
                    currentPrimitive = new TrianglePrimitive(size);
                    break;

                case "Круг":
                    currentPrimitive = new CirclePrimitive(size);
                    break;
            }
            currentPrimitive.SetPosition(new Point(ClientSize.Width / 3 - size / 3, ClientSize.Height / 3 - size / 3));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePosition = e.Location;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            {
                currentPrimitive.SetSize(e.X / 5);
                Invalidate(); 
            }
            if (isDragging)
            {
                int deltaX = e.Location.X - lastMousePosition.X;
                int deltaY = e.Location.Y - lastMousePosition.Y;
                currentPrimitive.SetPosition(new Point(currentPrimitive.Position.X + deltaX, currentPrimitive.Position.Y + deltaY));
                lastMousePosition = e.Location;
                Invalidate();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            currentPrimitive.Draw(e.Graphics);
        }

        
    }
}
