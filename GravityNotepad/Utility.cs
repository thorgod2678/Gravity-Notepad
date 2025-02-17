using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace GravityNotepad
{
    public static class Utility
    {
        public static Bitmap GetScreenImage(Rectangle clientRect,int menustriph )
        {
            // Rectangle clientRect = ClientRectangle;
            //clientRect.Location = PointToScreen(clientRect.Location); // Convert to screen coordinates
            if (clientRect.Width <= 0 || clientRect.Height <= 0)
            {
                throw new ArgumentException("Invalid rectangle dimensions.");
            }
            // Adjust for the MenuStrip
            int offsetY = menustriph;
            clientRect.Y += offsetY;
            clientRect.Height -= offsetY;
            Bitmap bitmap = new Bitmap(clientRect.Width, clientRect.Height);
            
            
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(clientRect.Location, Point.Empty, clientRect.Size);
                }
                return bitmap; // Display the captured image
            

        }


    }
}
