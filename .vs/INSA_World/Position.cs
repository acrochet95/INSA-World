using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
            throw new System.NotImplementedException();
        }

        public int X
        {
            get
            {
                return X;
                throw new System.NotImplementedException();
            }

            set
            {
                X = value;
            }
        }

        public int Y
        {
            get
            {
                return Y;
                throw new System.NotImplementedException();
            }

            set
            {
                Y = value;
            }
        }
    }
}