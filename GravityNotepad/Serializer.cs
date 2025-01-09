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
            catch (Exception ex) { 
            
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
                    fileStream.Write(data, 0, data.Length);
                }
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
