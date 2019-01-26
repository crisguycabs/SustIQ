using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustIQ
{
    public class CDupla
    {
        public int indice = -1;
        public int distancia = 0;

        public CDupla()
        {
            indice = -1;
            distancia = 0;
        }

        public CDupla(int _indice, int _distancia)
        {
            indice = _indice;
            distancia = _distancia;
        }

        public CDupla(CDupla cp)
        {
            indice = cp.indice;
            distancia = cp.distancia;
        }
    }
}
