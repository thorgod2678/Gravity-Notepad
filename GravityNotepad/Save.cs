using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityNotepad
{
    [Serializable]
    public class Save
    {
        public Point[] positions;
        
        public char[] letters;
        
        public float[] velocities;
        int count = 0;

        public Save(int pc,int lc,int vc) { 
        
            positions = new Point[pc];
           
            letters = new char[lc];
           
            velocities = new float[vc];
           
        
        }

        public void Increment(Point pos, char letter, float velocity)
        {
            positions[count] = pos;
            letters[count] = letter;
            velocities[count] = velocity;

            count++;
        }


        public override string ToString() 
        {
            string x = "";

            for (int i = 0; i < count; i++) 
            {
                x += "{";
                x+= positions [i].ToString();
                x += ",";
                x+= letters [i].ToString();
                x+= ",";
                x += velocities[i].ToString();
                x += "}\n";

            }


            return x;
        }

    }
}
