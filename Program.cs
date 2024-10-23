using System;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Переменные здоровья
            int hp_player = 1000;
            int hp_boss = 3000;
            // Переменные множители атак. Множители в конце хода сбрасываются в исходное значение.
            byte atk_player = 100;
            byte atk_boss = 100;

            bool companion = false; // Отвечает за призыв духа
            byte i = 0; // Очередность атак Босса

            Console.WriteLine("Вы встречаете Молоха Пустоты");
            while (hp_boss > 0 && hp_player > 0) // Пока у кого-нибудь не кончится здоровье, битва будет идти

            {
            
                Console.WriteLine();
                Console.WriteLine($"Ваше здоровье: {hp_player}");
                Console.WriteLine($"Здоровье Босса: {hp_boss}");
                Console.WriteLine("Выберите заклинание");
                Console.WriteLine("1 - Удар слабости; 2 - Призыв духа; 3 - Атака духом; 4 - Целебное восстановление.");
            Start:                              // Если условие заклинания не выполняется, возвращаемся сюда
                Console.WriteLine();



                byte read = Convert.ToByte(Console.ReadLine());

                switch (read)
                {
                    case 1:
                        Console.WriteLine("Вы наносите удар слабости!");
                        hp_boss -= (200 * atk_player) / 100;
                        Console.WriteLine($"Вы наносите {(200 * atk_player) / 100}!");
                        atk_boss = 20;
                        Console.WriteLine("Атака Молоха Пустоты уменьшена на 80%!");
                        atk_player = 100;
                        break;

                    case 2:
                        if (companion == false)
                        {
                            Console.WriteLine("Вы призываете духа!");
                            companion = true;
                        }
                        else
                        {
                            Console.WriteLine("Дух уже призван!");
                            goto Start;
                        }
                        atk_player = 100;
                        break;

                    case 3:
                        if (companion == true)
                        {
                            Console.WriteLine("Вы атакуете духом!");
                            hp_boss -= (500 * atk_player) / 100;
                            Console.WriteLine($"Вы наносите {(500 * atk_player) / 100}!");
                        }
                        else
                        {
                            Console.WriteLine("Вы ещё не призвали духа!");
                            goto Start;
                        }
                        atk_player = 100;
                        break;

                    case 4:
                        if (hp_player < 1000)
                        {
                            Console.WriteLine("Вы используете целебное восстановление!");
                            hp_player += 200;
                            if (hp_player > 1000) { hp_player = 1000; }
                            atk_player = 100;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("У вас уже максимальное количество здоровья!"); 
                            goto Start;
                        }
                    default:
                        Console.WriteLine("Вы не выбрали заклинание!");
                        goto Start;

                }

                Console.WriteLine();
                Console.WriteLine("Ход Молоха пустоты");

                
                switch (i)
                {
                    case 0:
                        Console.WriteLine("Молох бьёт вас Хвостом!");
                        hp_player -= (200 * atk_boss) / 100;
                        Console.WriteLine($"Молох наносит {(200 * atk_boss) / 100}!");
                        atk_boss = 100;
                        i++;
                        break;

                        case 1:
                        Console.WriteLine("Молох накладывает на вас слабость!");
                        atk_player = 10;
                        Console.WriteLine("Ваша атака ослаблена.");
                        atk_boss = 100;
                        i++;
                        break;

                        case 2:
                        Console.WriteLine("Молох восстанавливает себе здоровье!");
                        hp_boss += 100;
                        atk_boss = 100;
                        i++;
                        break;

                        case 3:
                        if (companion == true)
                        {
                            Console.WriteLine("Молох изгоняет вашего духа!");
                            companion = false;
                            atk_boss = 100;
                            i++;
                            break;
                        }
                        else goto case 0;

                        case 4:
                        
                            Console.WriteLine("Молох готовится нанести критический удар!");
                            atk_boss = 200;
                        i++;
                        break;

                        case 5:

                        if (atk_boss >= 100)
                        {
                            Console.WriteLine("Молох наносит критический удар!");
                            hp_player -= (400 * atk_boss) / 100;
                            Console.WriteLine($"Молох наносит {(400 * atk_boss) / 100}!");
                            atk_boss = 100;
                            i++;
                            break;
                        }
                        else goto case 0;

                    default:
                        i = 0;
                        goto case 0;



                }
                Console.WriteLine();
                Console.WriteLine("СЛЕДУЮЩИЙ ХОД");
                Console.WriteLine();

            }
            if (hp_boss <= 0)
            {
                Console.WriteLine("ВЫ ПОБЕДИЛИ!");
            }
            else
            {
                Console.WriteLine("Вас поглотил Молох Пустоты...");
            }
            Console.ReadKey();
        }
    }
}


