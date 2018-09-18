using System;
using System.Collections.Generic;
using System.Text;

namespace Bindings
{
    class PacketBuffer : IDisposable
    {
        List<byte> buff;
        byte[] readBUff;
        int readPos;
        bool buffUpdate = false;

        public PacketBuffer()
        {
            buff = new List<byte>();
            readPos = 0;
        }

        public int GetReadPos()
        {
            return readPos;
        }

        public byte[] ToArray()
        {
            return buff.ToArray();
        }

        public int Count()
        {
            return buff.Count;
        }

        public int Length()
        {
            return Count() - readPos;
        }

        public void Clear()
        {
            buff.Clear();
            readPos = 0;
        }

        // Write Data 

        public void AddInteger(int input)
        {
            buff.AddRange(BitConverter.GetBytes(input));
           
            buffUpdate = true;
        }
        public void AddFloat(float input)
        {
            buff.AddRange(BitConverter.GetBytes(input));
            buffUpdate = true;
        }

        public void AddString(string input)
        {
            
            buff.AddRange(Encoding.UTF8.GetBytes(input));
            buffUpdate = true;
        }

        public void AddByte(byte input)
        {
            buff.Add(input);
            buffUpdate = true;
        }

        public void AddBytes(byte[] input)
        {
            buff.AddRange(input);
            buffUpdate = true;
        }

        public void AddShort(short input)
        {
            buff.AddRange(BitConverter.GetBytes(input));
            buffUpdate = true;
        }

        // Read Data

        public int GetInteger(bool peek = true)
        {
            if (buff.Count > readPos)
            {
                if (buffUpdate)
                {
                    readBUff = buff.ToArray();
                    buffUpdate = false;
                }

                int ret = BitConverter.ToInt32(readBUff, readPos);
                if (peek & buff.Count > readPos)
                {
                    readPos += 4;
                }
                return ret;
            }
            else
            {
                throw new Exception("Packet Buffer is past its limits");
            }
        }

        public float GetFloat(bool peek = true)
        {
            if (buff.Count > readPos)
            {
                if (buffUpdate)
                {
                    readBUff = buff.ToArray();
                    buffUpdate = false;
                }

                float ret = BitConverter.ToSingle(readBUff, readPos);
                if (peek & buff.Count > readPos)
                {
                    readPos += 4;
                }
                return ret;
            }
            else
            {
                throw new Exception("Packet Buffer is past its limits");
            }
        }

        public string GetString(int length, bool peek = true)
        {
            
            if (buffUpdate)
            {
                readBUff = buff.ToArray();
                buffUpdate = false;
            }
            string ret = Encoding.UTF8.GetString(readBUff, readPos, length);
            if (peek & buff.Count > readPos)
            {
                if (ret.Length > 0)
                {
                    readPos += length;
                }
            }
            return ret;
        }

        public byte GetByte(bool peek = true)
        {
            if (buff.Count > readPos)
            {
                if (buffUpdate)
                {
                    readBUff = buff.ToArray();
                    buffUpdate = false;
                }

                byte ret = readBUff[readPos];
                if (peek & buff.Count > readPos)
                {
                    readPos += 1;
                }
                return ret;
            }
            else
            {
                throw new Exception("Packet Buffer is past its limits");
            }
        }

        public byte[] GetBytes(int length, bool peek = true)
        {

            if (buffUpdate)
            {
                readBUff = buff.ToArray();
                buffUpdate = false;
            }

            byte[] ret = buff.GetRange(readPos, length).ToArray();
            if (peek)
            {
                readPos += length;
            }
            return ret;
        }

        // IDisposable

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    buff.Clear();
                }
                readPos = 0;
            }
            this.disposedValue = true;
        }


        public void Dispose()
        {

        }


    }
}
