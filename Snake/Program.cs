using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            snake.Desplazamiento = Snake.Direccion.Up;
            food foode = new food();
            food foodVelocidad = new food();
            Console.CursorVisible = false;
            bool salir = false;
            
            

            while (!salir) {
                Console.Clear();
                Console.Title = "Juego Snake, presionar w, a, s, d para moverse y q para salir";
               
                //dibujando los bordes del programa para no tener que hacerlo con puntos.
                string row = new String('#', Console.WindowWidth);
                Console.SetCursorPosition(0, 0);
                Console.Write(row);
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write(row);
                for (int bordeY = 0; bordeY < Console.WindowHeight - 1; bordeY++)
                {
                    Console.SetCursorPosition(0, bordeY);
                    Console.Write('#'.ToString());
                    Console.SetCursorPosition(Console.WindowWidth - 1, bordeY);
                    Console.Write('#'.ToString());
                }

                foreach (Position point in snake.body)
                {
                    Console.SetCursorPosition(point.Posx, point.Posy);
                    Console.Write("*");
                }

                Thread moverThread = new Thread(() => {
                    
                    lock (snake)
                    {
                        snake.mover(ref salir); 
                    }
                });

                moverThread.Start();
                foode.cambiarTipo("comida");
                foodVelocidad.cambiarTipo("powerUp");

                Console.SetCursorPosition(foode.pos.Posx, foode.pos.Posy);
                Console.SetCursorPosition(foodVelocidad.pos.Posx, foodVelocidad.pos.Posy);
                if (snake.body[0].Posx == foode.pos.Posx && snake.body[0].Posy == foode.pos.Posy)
                {
                    foode.cambiarPosicion();

                    if (snake.Desplazamiento == Snake.Direccion.Up)
                    {
                        snake.body.Add(new Position(snake.body[snake.body.Count - 1].Posx, snake.body[snake.body.Count - 1].Posy - 1));
                    }
                    else if (snake.Desplazamiento == Snake.Direccion.Left)
                    {
                        snake.body.Add(new Position(snake.body[snake.body.Count - 1].Posx + 1, snake.body[snake.body.Count - 1].Posy));
                    }
                    else if (snake.Desplazamiento == Snake.Direccion.Right)
                    {
                        snake.body.Add(new Position(snake.body[snake.body.Count - 1].Posx + 1, snake.body[snake.body.Count - 1].Posy));
                    }
                    else if (snake.Desplazamiento == Snake.Direccion.Down)
                    {
                        snake.body.Add(new Position(snake.body[snake.body.Count - 1].Posx, snake.body[snake.body.Count - 1].Posy + 1));
                    }

                    Console.SetCursorPosition(foode.pos.Posx, foode.pos.Posy);
                    Console.Write(foode.Figura);
                    snake.Velocidad -= 1;

                }
                else if (snake.body[0].Posx == foodVelocidad.pos.Posx && snake.body[0].Posy == foodVelocidad.pos.Posy)
                {
                    foodVelocidad.cambiarPosicion();
                    Console.SetCursorPosition(foodVelocidad.pos.Posx, foodVelocidad.pos.Posy);
                    Console.Write(foodVelocidad.Figura);
                    snake.Velocidad -= 10;
                }
                else
                {
                    Console.SetCursorPosition(foode.pos.Posx, foode.pos.Posy);
                    Console.Write(foode.Figura);
                    Console.SetCursorPosition(foodVelocidad.pos.Posx, foodVelocidad.pos.Posy);
                    Console.Write(foodVelocidad.Figura);
                    
                }

                //Elimino la cola una por una del cuerpo
                snake.body.RemoveAt(snake.body.Count - 1);
                
                // captura la posicion del snake
                Position next = snake.body[0];
                if (snake.Desplazamiento == Snake.Direccion.Up)
                {
                    next = new Position(next.Posx, next.Posy - 1);
                    System.Threading.Thread.Sleep(snake.Velocidad);
                    snake.pos.Posy--;
                }
                else if(snake.Desplazamiento == Snake.Direccion.Left)
                {
                    next = new Position(next.Posx - 1, next.Posy);
                    System.Threading.Thread.Sleep(snake.Velocidad);
                    snake.pos.Posx--;
                }
                else if(snake.Desplazamiento == Snake.Direccion.Right)
                {
                    next = new Position(next.Posx + 1, next.Posy);
                    System.Threading.Thread.Sleep(snake.Velocidad);
                    snake.pos.Posx++;
                }
                else if(snake.Desplazamiento == Snake.Direccion.Down)
                {
                   
                    next = new Position(next.Posx, next.Posy + 1);
                    System.Threading.Thread.Sleep(snake.Velocidad);
                    snake.pos.Posy++;
                }

                // inserto una nueva cabeza al cuerpo del snake.
                snake.body.Insert(0, next);

                if (snake.body[0].Posy < 1 || snake.body[0].Posy > Console.WindowHeight - 2
                    || snake.body[0].Posx < 1 || snake.body[0].Posx > Console.WindowWidth - 2)
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 25, Console.WindowHeight / 2);
                    Console.Write("Has perdido, en 5 segundo el juego empezara.");
                    
                    System.Threading.Thread.Sleep(5000);
                    
                    //Reseteo las bariables principales
                    snake = new Snake();
                    //snake.Desplazamiento = Snake.Direccion.Up;
                    foode = new food();
                    foodVelocidad = new food();
                    snake.cleanCKI();
                }



            }
        }
    }
}
