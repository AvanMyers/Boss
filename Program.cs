using System;

namespace Boss
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string ComandHitBoss = "1";
            const string ComandSmash = "2";
            const string ComandUseRage = "3";
            const string ComandUsePotion = "4";

            int healthPlayer = 150;
            int stamina = 5;
            Random random = new Random();
            int playerDamage = 0;
            int smashDamage = 0;
            int rageDamageMultiply = 2;
            int rageDuration = 3;
            int rageDurationEffect = 3;
            int takedDamageInRage = 10;
            int potionNumber = 3;
            int potionHealEffect = 150;
            int potionStaminaEffect = 3;
            int bossHealth = 500;
            int bossDamage = 20;
            int minPlayerDamage = 20;
            int maxPlayerDamage = 40;
            int minSmashDamage = 60;
            int maxSmashDamage = 100;
            int bossRageDamage = bossDamage + takedDamageInRage;
            string userInput;
            bool inRage = false;

            Console.WriteLine("Твоим глазам предстал дракон к которому вы с группой так долго шли, но ты пришел позднее своей команды, дав им больше времени" +
                "сдерживая врагов, но они проиграли, раненные товарищи лежали не в силах подняться и продолжить бой" +
                ", и ты понял, только от тебя зависит, выживите вы в этой битве или нет");

            Console.WriteLine("Какой будет твой следующий шаг?\n \n" +
                $"{ComandHitBoss} Совершить удар который непременно поразит врага\n \n" +
                $"{ComandSmash} Совершить могучий удар на который ты потратишь часть своих сил\n \n" +
                $"{ComandUseRage} Впасть в ярость увеличив наносимый урон, но ослабив защиту на {rageDuration}\n \n" +
                $"{ComandUsePotion} Использовать зелье, котороые востановит твое здоровье и выносливость, но помни зелий всеволишь {potionNumber}\n \n");

            while (healthPlayer > 0 && bossHealth > 0)
            {
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ComandHitBoss:
                        playerDamage = random.Next(minPlayerDamage, maxPlayerDamage);

                        if (inRage)
                        {
                            bossHealth -= playerDamage * rageDamageMultiply;
                            Console.WriteLine($"Не сдерживая свою ярость которая несет твои ноги прямо на врага ты делаешь широкий взмах топора" +
                                $" прорезая плоть своего недруга нанося {playerDamage * rageDamageMultiply}");
                            rageDuration--;

                            if (rageDuration <= 0)
                            {
                                Console.WriteLine("Порыв ярости прекращается, ослабляя тебя, но ты вс еще готов сражаться дальше");
                                inRage = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Вы взмахиваетие своим могучим топором нанося {playerDamage} " +
                                $"и оставляю глубокую рану на теле дракона, но и открываясь получая ");
                            bossHealth -= playerDamage;
                        }

                        break;
                    case ComandSmash:

                        if (stamina > 0)
                        {
                            smashDamage = random.Next(minSmashDamage, maxSmashDamage);
                            stamina--;

                            if (inRage)
                            {
                                bossHealth -= smashDamage * rageDamageMultiply;
                                Console.WriteLine($"Ты яростно взмахиваешь своим топором отсекая дракону одну из конечностией, нанося {smashDamage * rageDamageMultiply}" +
                                    " но ты не можешь определить, что это было, потому что ярость застелает глаза красной пеленой");
                                rageDuration--;

                                if (rageDuration <= 0)
                                {
                                    Console.WriteLine("Порыв ярости прекращается, ослабляя тебя, но ты вс еще готов сражаться дальше");
                                    inRage = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Хоть ярость и затилает взор, но твердая рука уверенно направляет топор в тело дракона нанося {smashDamage}");
                                bossHealth -= smashDamage;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно выносливости");

                            if (inRage)
                            {
                                rageDuration--;

                                if (rageDuration <= 0)
                                {
                                    Console.WriteLine("Порыв ярости прекращается, ослабляя тебя, но ты вс еще готов сражаться дальше");
                                    inRage = false;
                                }
                            }
                        }
                        break;
                    case ComandUseRage:
                        inRage = true;
                        Console.WriteLine("Пелена застелает твой взор и ты видишь перед собой одну единственную цель, твоего враг, огромного дракона.");
                        rageDuration = rageDurationEffect;
                        break;
                    case ComandUsePotion:

                        if (potionNumber > 0)
                        {
                            potionNumber--;
                            healthPlayer = potionHealEffect;
                            stamina = potionStaminaEffect;
                            Console.WriteLine("Почувсвовасть слабюость в теле, ты достаешь одну из припасенных еще с самого начала путешествия склянку выпивая ее" +
                                ", но то ли из-за неосторожности, то ли по невнимательности коготь дракона все равно настигает тебя, но все старые раны затягиваются на глазах.");

                            if (inRage)
                            {
                                rageDuration--;

                                if (rageDuration == 0)
                                    inRage = false;
                            }
                        }
                        else if (potionNumber == 0)
                        {
                            Console.WriteLine("Увы зелий больше нет");
                        }
                        break;
                    default:
                        Console.WriteLine("Ты спотыкаешься о камень и даркон не упускает данного шанса нанося удар хвостом");

                        if (inRage)
                        {
                            rageDuration--;

                            if (rageDuration <= 0)
                            {
                                Console.WriteLine("Порыв ярости прекращается, ослабляя тебя, но ты вс еще готов сражаться дальше");
                                inRage = false;
                            }
                        }
                        break;
                }

                if (rageDuration > 0)
                    healthPlayer -= bossRageDamage;
                else
                    healthPlayer -= bossDamage;

                Console.WriteLine($"У тебя осталось {healthPlayer} жизненных сил, в то время как у Дракона {bossHealth}");
            }

            if (healthPlayer <= 0)
            {
                Console.WriteLine("Возможно победа и была бляизко но ты больше не увидишь ни яркого солнечного света, ни своих друзей, ни королевства." +
                    "Со падением твоих напарников и тебя палои и все ближайшие королевства, мир захватил страх и смерть," +
                    " возможно, кто-нибудь и победит дракона, но ты этого никогда не увидишь.");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("Дракон повержен, ты бросаешь свой топор и бежишь спасать своих друзей, к счастью ты успеваешь и оказываешь им первую помощь, вы спасены," +
                    "Королевство спасено, но на долголи, ведь это был только один из шаов по спасению королевства, впереди еще множество угроз которые передстоит преодлеть" +
                    " и врагов которые которые ждут ощутить на вкус твой топор");
            }
            else if (healthPlayer <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Ты победил...победил же? Да, ты видишь голову драона лежащую рядом с тобой, но эта боль, ты опускаешь взгляд вниз и видишь как острый шип " +
                    "драконьего хвоста пронзил твое сердце. И когда твои глаза застелает пелена, ты видишь как к тебе несутся твои товарищи, но они не успеют, ты в этом точно уверен" +
                    "как хорошо, что они живы, это последняя мысль которая пронисится в твоем затуманенном сознании");
            }

            Console.WriteLine("Вот такой вот конец, спасибо.");
            Console.ReadKey();
        }
    }
}