using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Control
{
    /// <summary>
    /// Ventana flotante tipo "toast" con spinner giratorio para operaciones en curso.
    /// Se posiciona centrada sobre la ventana dueña y no roba el foco.
    /// </summary>
    public class FrmLoadingOverlay : Form
    {
        private readonly System.Windows.Forms.Timer animationTimer;
        private readonly string message;
        private float spinnerAngle;

        private const int CARD_WIDTH = 300;
        private const int CARD_HEIGHT = 100;
        private const int SPINNER_SIZE = 40;
        private const float ARC_SWEEP = 110F;

        public FrmLoadingOverlay(Form owner, string message = "Procesando...")
        {
            this.message = message;

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            TopMost = true;
            DoubleBuffered = true;
            BackColor = Color.FromArgb(45, 45, 48);
            Size = new Size(CARD_WIDTH, CARD_HEIGHT);

            SetRoundedRegion();
            PositionOver(owner);

            animationTimer = new System.Windows.Forms.Timer { Interval = 30 };
            animationTimer.Tick += AnimationTimer_Tick;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x08000000; // WS_EX_NOACTIVATE: no roba el foco
                cp.ExStyle |= 0x00000080; // WS_EX_TOOLWINDOW: sin ícono en alt-tab
                return cp;
            }
        }

        protected override bool ShowWithoutActivation => true;

        public new void Show()
        {
            base.Show();
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            spinnerAngle = (spinnerAngle + 8F) % 360F;
            Invalidate();
        }

        private void SetRoundedRegion()
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 18;

                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                Region = new Region(path);
            }
        }

        private void PositionOver(Form owner)
        {
            if (owner != null && owner.IsHandleCreated && owner.Visible)
            {
                Rectangle ownerBounds = owner.RectangleToScreen(owner.ClientRectangle);

                Location = new Point(
                    ownerBounds.Left + (ownerBounds.Width - Width) / 2,
                    ownerBounds.Top + (ownerBounds.Height - Height) / 2);
            }
            else
            {
                Rectangle screen = Screen.PrimaryScreen.WorkingArea;

                Location = new Point(
                    screen.Left + (screen.Width - Width) / 2,
                    screen.Top + (screen.Height - Height) / 2);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Spinner
            Rectangle spinnerRect = new Rectangle(
                (Width - SPINNER_SIZE) / 2,
                16,
                SPINNER_SIZE,
                SPINNER_SIZE);

            using (Pen trackPen = new Pen(Color.FromArgb(55, 220, 220, 230), 4))
            {
                e.Graphics.DrawEllipse(trackPen, spinnerRect);
            }

            using (Pen arcPen = new Pen(Color.Gainsboro, 4))
            {
                arcPen.StartCap = LineCap.Round;
                arcPen.EndCap = LineCap.Round;
                e.Graphics.DrawArc(arcPen, spinnerRect, spinnerAngle, ARC_SWEEP);
            }

            // Mensaje
            Rectangle textRect = new Rectangle(12, 16 + SPINNER_SIZE + 4, Width - 24, Height - (16 + SPINNER_SIZE + 4) - 8);

            TextRenderer.DrawText(
                e.Graphics,
                message,
                new Font("Segoe UI Semibold", 10F),
                textRect,
                Color.White,
                Color.Transparent,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                animationTimer?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
