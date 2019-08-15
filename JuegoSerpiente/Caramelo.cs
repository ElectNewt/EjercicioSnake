using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoSerpiente
{
    public class Caramelo
    {
        public Posicion Posicion { get; set; }

        public Caramelo(int x, int y)
        {
            Posicion = new Posicion(x, y);
        }


        public void DibujarCaramelo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Util.DibujarPosicion(Posicion.X, Posicion.Y, "O");
            Console.ResetColor();
        }

        public static Caramelo CrearCaramelo(Serpiente serpiente, Tablero tablero)
        {
            bool carameloValido;
            int x,y;

            do
            {
                Random random = new Random();
                x = random.Next(1, tablero.Anchura - 1);
                y = random.Next(1, tablero.Altura - 1);
                carameloValido = serpiente.PosicionEnCola(x, y);

            } while (carameloValido);

            tablero.ContieneCaramelo = true;
            return new Caramelo(x, y);
        }
    }
}
