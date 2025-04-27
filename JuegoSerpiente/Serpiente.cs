using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuegoSerpiente
{
    public class Serpiente
    {
        List<Posicion> Cola { get; set; }
        public Direccion Direccion { get; set; }
        public int Puntos { get; set; }
        public bool EstaViva { get; set; }

        public Serpiente(int x, int y)
        {

            Posicion posicionInicial = new Posicion(x, y);
            Cola = new List<Posicion>() { posicionInicial };
            Direccion = Direccion.Abajo;
            Puntos = 0;
            EstaViva = true;

        }
        public void DibujarSerpiente()
        {
            var cabeza = Cola.First();

            Console.ForegroundColor = ConsoleColor.Green;
            Util.DibujarPosicion(cabeza.X, cabeza.Y, "x");
            Console.ResetColor();
        }

        public void BorrarUltimaPosicion()
        {
            var cola = Cola.Last();
            Console.SetCursorPosition(cola.X, cola.Y);
            Console.Write(" ");
        }
        public bool ComprobarMorir(Tablero tablero)
        {
            //Si nos chocamos contra nosotros
            Posicion primeraPosicion = Cola.First();

            return !((Cola.Count(a => a.X == primeraPosicion.X && a.Y == primeraPosicion.Y) > 1)
                || CabezaEstaEnPared(tablero, Cola.First()));

        }

        //si la primera posicion esta en cualquiera de los muros, morimos.
        private bool CabezaEstaEnPared(Tablero tablero, Posicion primeraPoisicon)
        {
            return primeraPoisicon.Y == 0 || primeraPoisicon.Y == tablero.Altura
                || primeraPoisicon.X == 0 || primeraPoisicon.X == tablero.Anchura;

        }

        public void Moverse(bool haComido)
        {
            List<Posicion> nuevaCola = new List<Posicion>();
            nuevaCola.Add(ObtenerNuevaPrimeraPosicion());
            nuevaCola.AddRange(Cola);

            if (!haComido)
            {
                nuevaCola.Remove(nuevaCola.Last());
            }

            Cola = nuevaCola;
        }

        private Posicion ObtenerNuevaPrimeraPosicion()
        {
            int x = Cola.First().X;
            int y = Cola.First().Y;

            switch (Direccion)
            {
                case Direccion.Abajo:
                    y += 1;
                    break;
                case Direccion.Arriba:
                    y -= 1;
                    break;
                case Direccion.Derecha:
                    x += 1;
                    break;
                case Direccion.Izquierda:
                    x -= 1;
                    break;
            }

            return new Posicion(x, y);
        }

        public bool PosicionEnCola(int x, int y)
        {
            return Cola.Any(a => a.X == x && a.Y == y);
        }


        public bool ComeCaramelo(Caramelo caramelo, Tablero tablero)
        {
            if (PosicionEnCola(caramelo.Posicion.X, caramelo.Posicion.Y))
            {
                Puntos += 10; // sumamos puntos
                tablero.ContieneCaramelo = false;//Quitar el caramelo o generar uno nuevo
                return true;
            }
            return false;

        }

    }

}
