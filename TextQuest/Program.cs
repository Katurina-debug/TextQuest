using System;
using System.Collections.Generic;

namespace TextQuest
{
    class Program
    {
        //содержимое текста сюжета и диалогов
        private string[] QuestText = new string[] { 
            "Вы тусите на дороге ничего не помня", 
            "Привет, путник, тебе придется тут выживать самому, нто для начала я тебе помогу. \nБродяга дал вам 10 монет и амулет",
            "Дальше сам, я помог уже",
            "Вокруг ничего нет, вдалеке вы замечаете лесную тропинку",  //индекс 2
            "Скоро узнаем, что дальше"};

        //действия, что будут после выбора: тект квеста, след кнопка 1, 2 (смотрит по индексу)
        private string[,] ButtonText = new string[,] {
            { "1", "0", "1", "Поговорить с бродягой" },
            { "3", "2", "3", "Осмотреть окрестности"},
            { "4", "2", "3", "Пойти в лес" },   //индекс 2
            { "4", "2", "3", "Идти дальше по дороге" } };

        //в основном добавляется только тект, а в ответах под этими номерами - нет
        private int[] NumberIsklChoice = new int[] { 0, 2 };
        private string[] Location = new string[] { "Дорога", "Лес" };

        private int LocatNumber = 0;
        private int NumberBut1 = 0;
        private int NumberBut2 = 1;

        private int money = 0;
        private bool amulet = false;

        static void Main(string[] args)
        {
            var c = new Program();
            c.PrintText(c.NumberBut1, c.NumberBut2, 0);
            while (true)
            {
                int numberCheck = Convert.ToInt32(Console.ReadLine());
                if (numberCheck == 1)
                {
                    c.Progress(c.NumberBut1);
                }
                else if (numberCheck == 2)
                {
                    c.Progress(c.NumberBut2);
                }
                else
                {
                    Console.WriteLine("Такого варианта нет, попробуй еще раз");
                }

            }
        }

        //Вывода на экран текстов
        void PrintText(int button1, int button2, int text)
        {
            Console.WriteLine("Вы в локации: " + Location[LocatNumber]+"\n" + QuestText[text] + "\n1." + ButtonText[button1, 3] + "\n2." + ButtonText[button2, 3]);
            Console.WriteLine("Введи номер варианта, который выберешь");
        }

        //получает номер варианта, что был выбран и проверяет обычный или нет
        void Progress(int variant)
        {
            int test = -1;  //для проверки несет ли доп действие или просто дальше по сюжету
            test = Array.IndexOf(NumberIsklChoice, variant);

            NumberBut1 = Int32.Parse(ButtonText[variant, 1]);
            NumberBut2 = Int32.Parse(ButtonText[variant, 2]);
            int text = Int32.Parse(ButtonText[variant, 0]);
            switch (test) //тут смотрит номер индекса в массиве NumberIsklChoice 
            {
                case 0:
                    if (!amulet)
                    {
                        amulet = true;
                        money += 10;
                    }
                    else
                    {
                        text++;
                    }
                    break;
                case 1:
                    LocatNumber++;
                    break;
            }
            PrintText(NumberBut1, NumberBut2, text);
        }
    }
}
