using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GravityNotepad
{
    public class Serializer
    {
        public byte[] data;
        public Save input;
        public Exception LastEx;
        public string filename;

        public Serializer(Save save, byte[] dat)
        {
            input = save;
            data = dat;
        }

        public bool Serialize()
        {
            var ms = new MemoryStream();
            var writer = new BinaryWriter(ms);

            try
            {
                writer.Write(input.positions.Length);
                foreach (var pos in input.positions)
                {
                    writer.Write(pos.X);
                    writer.Write(pos.Y);
                }

                writer.Write(input.letters.Length);
                foreach (var letter in input.letters)
                {
                    writer.Write(letter);
                }

                writer.Write(input.velocities.Length);
                foreach (var velocity in input.velocities)
                {
                    writer.Write(velocity);
                }

                data = ms.ToArray();

                writer.Dispose();


                return true;

            }
            catch (Exception ex)
            {

                LastEx = ex;
                return false;
            }


        }

        public bool Deserialize()
        {
            Point[] positions;
            char[] chars;
            float[] velocities;

            if (data == null || data.Length == 0)
            {
                LastEx = new ArgumentNullException(nameof(data), "Data cannot be null or empty.");
                return false;
            }

            var ms = new MemoryStream(data);
            var reader = new BinaryReader(ms);

            try
            {
                // Read positions
                int posCount = reader.ReadInt32();
                positions = new Point[posCount];
                for (int i = 0; i < posCount; i++)
                {
                    int xx = reader.ReadInt32();
                    int y = reader.ReadInt32();
                    positions[i] = new Point(xx, y);
                }

                // Read letters
                int lettersCount = reader.ReadInt32();
                chars = new char[lettersCount];
                for (int i = 0; i < lettersCount; i++)
                {
                    chars[i] = reader.ReadChar();
                }

                // Read velocities
                int velocityCount = reader.ReadInt32();
                velocities = new float[velocityCount];
                for (int i = 0; i < velocityCount; i++)
                {
                    velocities[i] = reader.ReadSingle();
                }

                reader.Dispose();
                Save x = new Save(posCount, lettersCount, velocityCount);
                for(int i = 0; i< posCount; i++)
                {
                    x.Increment(positions[i], chars[i], velocities[i]);
                }
                x.filename = filename;
                input = x;
                return true;
            }
            catch (Exception ex)
            {
                LastEx = ex;
                return false;
            }
        }


        public bool WriteToFile(string path)
        {
            
            try
            {
                
                // Write binary data to the file
                using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    //data = new DataForm
                    fileStream.Write(data, 0,data.Length);
                }
                return true;
            }
            catch (Exception ex)
            {
                LastEx = ex;
                return false;
            }




        }

        public bool ReadFromFile(string path)
        {
            filename = path;
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    data = new byte[fileStream.Length];
                    fileStream.Read(data, 0, (int)fileStream.Length);
                }
                return true;

            }
            catch (Exception ex)
            {
                LastEx = ex;
                return false;
            }

        }

        public bool StandardSerialize()
        {
            var ms = new MemoryStream();
            var writer = new BinaryWriter(ms);
            try
            {
                for (int i = 0; i < input.letters.Length; i++)
                {
                    writer.Write(input.letters[i]);
                }
                data = ms.ToArray();

                return true;
            }
            catch (Exception ex)
            {
                LastEx = ex;
                return false;
            }
        
        }

        public bool StandardDeSerialize()
        {
            var ms = new MemoryStream(data);
            var reader = new BinaryReader(ms);
            Form thisform = Form.ActiveForm;
            char[] chars = new char[data.Length];
            Point[] positions = new Point[chars.Length];
            float[] velocities = new float[chars.Length];

            try
            {
               
                int startX = 5;
                int startY = 25;
                int x = startX;
                int y = startY;
                int lineWidth = thisform.Width;
                int charWidth = 10;
                int lineHeight = 20;

                for (int i = 0; i < chars.Length; i++)
                {
                    chars[i] = reader.ReadChar();

                    velocities[i] = 0f;
                    positions[i] = new Point(x, y);
                    
                   
                    x += charWidth;

                    
                    if (x >= lineWidth)
                    {
                        x = startX; 
                        y += lineHeight; 
                    }
                }
                Save save = new Save(chars.Length,positions.Length,velocities.Length);
                for (int i = 0; i < chars.Length; i++) 
                {
                    save.Increment(positions[i], chars[i], velocities[i]);
                }
                save.filename = filename;
                input = save;
               // MessageBox.Show(new string(chars));
                //MessageBox.Show(chars.Length.ToString());
               // MessageBox.Show(data.Length.ToString());
                return true;
            }
            catch (Exception ex)
            {
                LastEx = ex;
                return false;
            }


        }
    }
}
