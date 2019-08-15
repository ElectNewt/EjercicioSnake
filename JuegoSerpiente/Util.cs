using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoSerpiente
{
    static class Util
    {
        public static void DibujarPosicion(int x, int y, string caracter)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(caracter);
        }

        public static Direccion LeerMovimiento(Direccion movimientoActual)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow && movimientoActual != Direccion.Abajo)
                {
                    return Direccion.Arriba;
                }
                else if (key == ConsoleKey.DownArrow && movimientoActual != Direccion.Arriba)
                {
                    return Direccion.Abajo;
                }
                else if (key == ConsoleKey.LeftArrow && movimientoActual != Direccion.Derecha)
                {
                    return Direccion.Izquierda;
                }
                else if (key == ConsoleKey.RightArrow && movimientoActual != Direccion.Izquierda)
                {
                    return Direccion.Derecha;
                }
            }
            return movimientoActual;
        }

        public static void MostrarPuntuación(Tablero tablero, Serpiente serpiente)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Util.DibujarPosicion(tablero.Anchura / 2, tablero.Altura / 2, "Game Over");
            Util.DibujarPosicion(tablero.Anchura / 2, (tablero.Altura / 2) + 1, $"Puntuacion {serpiente.Puntos}");
            Console.ResetColor();
        }
    }
}
