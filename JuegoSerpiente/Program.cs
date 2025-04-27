using System;
using System.Diagnostics;

namespace JuegoSerpiente
{
    class Program
    {
        static void Main(string[] args)
        {
            Tablero tablero = new Tablero(20, 20);

            Serpiente serpiente = new Serpiente(10, 10);
            Caramelo caramelo = new Caramelo(0, 0);
            bool haComido = false;
            tablero.DibujarTablero();

            do
            {
                serpiente.BorrarUltimaPosicion();

                //movemos y comprobamos si ha comido en el turno anterior.
                serpiente.Moverse(haComido);

                //Comprobamos si se ha comido el caramelo
                haComido = serpiente.ComeCaramelo(caramelo, tablero);

                //Dibujamos serpiente
                serpiente.DibujarSerpiente();

                //Si no contiene el caramelo, instanciamos uno nuevo.
                if (!tablero.ContieneCaramelo)
                {
                    caramelo = Caramelo.CrearCaramelo(serpiente, tablero);
                }

                //Dibujamos caramelo
                caramelo.DibujarCaramelo();

                //Leemos informacion por teclado de la direccion.
                var sw = Stopwatch.StartNew();
                while (sw.ElapsedMilliseconds <= 250)
                {
                    serpiente.Direccion = Util.LeerMovimiento(serpiente.Direccion);
                }

            } while (serpiente.ComprobarMorir(tablero));

            Util.MostrarPuntuación(tablero, serpiente);

            Console.ReadKey();
        }
    }
}
