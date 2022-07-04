using System;

namespace App
{
    using System.Collections;
    using System.Collections.Generic;

    class Torneo
    {
        public int año;
        public string nombre;
        public bool esNacional;
        public bool esAmateur;

        public bool esFacilito()
        {
            return (esNacional && esAmateur);
        }
    }

    class Boxeador
    {
        public string apodo;
        public int nroUnico;
        public int peso;
        public bool esMasculino;

        Torneo miTorneo = new Torneo();
        ArrayList misTorneos = new ArrayList();
        void cargar()
        {
            misTorneos.Add(miTorneo);
        }

        public bool esPesoPesado()
        {
            return (esMasculino && peso > 81 || !esMasculino && peso > 81);
        }

        public bool ganoMenosDe3Torneos()
        {
            int aux = 0;
            bool aux2 = false;
            foreach (Torneo t in misTorneos)
            {
                if (!t.esFacilito())
                    aux++;
                if (aux < 3)
                    aux2 = true;
            }
            return aux2;
        }

        public int cuantosIntYPro()
        {
            int aux = 0;
            foreach (Torneo t in misTorneos)
            {
                if (!t.esNacional && !t.esFacilito())
                    aux++;
            }
            return aux;
        }
        public bool esGirlPower()
        {
            return (!esMasculino && esPesoPesado());
        }
    }
    class Club
    {
        Boxeador miBoxeador = new Boxeador();
        public ArrayList misBoxeadores = new ArrayList();
        void cargar()
        {
            misBoxeadores.Add(miBoxeador);
        }

        ArrayList categoriaFloja()
        {
            ArrayList lista = new ArrayList();
            foreach (Boxeador t in misBoxeadores)
            {
                if (t.ganoMenosDe3Torneos() && !t.esPesoPesado())
                    lista.Add(t);
            }

            return lista;
        }

        Boxeador masInterYPro()
        {
            Boxeador aux = new Boxeador();
            aux = (Boxeador)misBoxeadores[0];
            foreach (Boxeador b in misBoxeadores)
            {
                if (aux.cuantosIntYPro() < b.cuantosIntYPro())
                    aux = b;
            }
            return aux;
        }

        public bool girlPower()
        {
            bool aux = false;
            foreach (Boxeador b in misBoxeadores)
            {
                if (b.esGirlPower() && b == masInterYPro())
                {
                    aux = true;
                }
            }
            return aux;
        }
    }
}
