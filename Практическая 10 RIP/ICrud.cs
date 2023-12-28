using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пятёрочка
{
    internal interface ICrud
    {
        void Create(int y);
        void Read(int y);
        void Update(int y);
        void Delete();
    }
}