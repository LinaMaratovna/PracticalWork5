using System;

namespace PracticalWork5
{
    public class Man
    {
        private string name;
        private int age;
        private string gender;
        private double weight;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        // Конструктор по умолчанию
        public Man()
        {
            name = "Не указано";
            age = 0;
            gender = "Не указан";
            weight = 0;
        }

        // Конструктор со всеми параметрами
        public Man(string name, int age, string gender, double weight)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
        }

        // Установка параметров (перегрузки)
        public void SetParams(string name)
        {
            Name = name;
        }

        public void SetParams(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void SetParams(string name, int age, string gender, double weight)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
        }

        // Операция увеличения возраста на 1 год
        public void Birthday()
        {
            Age = Age + 1;
        }

        // Перегрузка оператора ++ : день рождения (возраст +1)
        public static Man operator ++(Man m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            m.Age = m.Age + 1;
            return m;
        }

        // Операции определения, кто тяжелее / легче
        public static bool operator >(Man a, Man b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Объект не создан");

            return a.Weight > b.Weight;
        }

        public static bool operator <(Man a, Man b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Объект не создан");

            return a.Weight < b.Weight;
        }

        public static bool operator >=(Man a, Man b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Объект не создан");

            return a.Weight >= b.Weight;
        }

        public static bool operator <=(Man a, Man b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Объект не создан");

            return a.Weight <= b.Weight;
        }

        // Метод-вариант сравнения: возвращает более тяжёлого человека
        public static Man Heavier(Man a, Man b)
        {
            return (a > b) ? a : b;
        }

        // Метод-вариант сравнения: возвращает более лёгкого человека
        public static Man Lighter(Man a, Man b)
        {
            return (a < b) ? a : b;
        }

        public string GetInfo()
        {
            return $"Имя: {Name}\n" +
                   $"Возраст: {Age}\n" +
                   $"Пол: {Gender}\n" +
                   $"Вес: {Weight} кг";
        }
    }
}