using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace PracticalWork5
{
    public partial class MainWindow : Window
    {
        private Man person1;   // первый человек
        private Man person2;   // второй человек

        public MainWindow()
        {
            InitializeComponent();
            person1 = new Man();
            person2 = new Man();
        }

        // Создание двух людей
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ReadPerson(Name1Box, Age1Box, Gender1Box, Weight1Box, "№1", person1))
                    return;

                if (!ReadPerson(Name2Box, Age2Box, Gender2Box, Weight2Box, "№2", person2))
                    return;

                ShowInfo("Люди созданы.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Чтение и проверка данных одного человека
        private bool ReadPerson(TextBox nameBox, TextBox ageBox, ComboBox genderBox,
                                TextBox weightBox, string caption, Man man)
        {
            string name = nameBox.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show($"Введите имя человека {caption}!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(ageBox.Text, out int age) || age < 0 || age > 150)
            {
                MessageBox.Show($"Введите корректный возраст человека {caption} (0–150)!",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            string gender = (genderBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Не указан";

            if (!double.TryParse(weightBox.Text.Replace(',', '.'),
                                 NumberStyles.Any,
                                 CultureInfo.InvariantCulture,
                                 out double weight) || weight <= 0)
            {
                MessageBox.Show($"Введите корректный вес человека {caption}!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            man.SetParams(name, age, gender, weight);
            return true;
        }

        // Увеличение возраста на 1 год
        private void Birthday1Button_Click(object sender, RoutedEventArgs e)
        {
            if (!IsCreated()) return;

            person1.Birthday();                 // вариант через метод
            Age1Box.Text = person1.Age.ToString();
            ShowInfo($"У человека «{person1.Name}» день рождения! Возраст увеличен на 1 год.");
        }

        private void Birthday2Button_Click(object sender, RoutedEventArgs e)
        {
            if (!IsCreated()) return;

            person2++;                          // вариант через перегруженный оператор ++
            Age2Box.Text = person2.Age.ToString();
            ShowInfo($"У человека «{person2.Name}» день рождения! Возраст увеличен на 1 год.");
        }

        // Кто тяжелее / кто легче
        private void CompareButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsCreated()) return;

            string result;

            if (person1 > person2)              // перегруженный оператор >
            {
                result = $"Тяжелее: {person1.Name} ({person1.Weight} кг)\n" +
                         $"Легче:   {person2.Name} ({person2.Weight} кг)\n" +
                         $"Разница: {Math.Round(person1.Weight - person2.Weight, 2)} кг";
            }
            else if (person1 < person2)         // перегруженный оператор <
            {
                result = $"Тяжелее: {person2.Name} ({person2.Weight} кг)\n" +
                         $"Легче:   {person1.Name} ({person1.Weight} кг)\n" +
                         $"Разница: {Math.Round(person2.Weight - person1.Weight, 2)} кг";
            }
            else
            {
                result = $"{person1.Name} и {person2.Name} весят одинаково " +
                         $"({person1.Weight} кг).";
            }

            ShowInfo("Сравнение по весу:\n" + result);
        }

        // Вспомогательные методы
        private bool IsCreated()
        {
            if (person1.Name == "Не указано" || person2.Name == "Не указано")
            {
                MessageBox.Show("Сначала нажмите «Создать людей»!", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        private void ShowInfo(string header)
        {
            ResultText.Text = header + "\n\n" +
                              "--- Человек №1 ---\n" + person1.GetInfo() + "\n\n" +
                              "--- Человек №2 ---\n" + person2.GetInfo();
        }

        // О программе
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Практическая работа\n\n" +
                "Класс Man (человек) с полями: имя, возраст, пол, вес.\n\n" +
                "Реализовано:\n" +
                "• операция увеличения возраста на 1 год (метод Birthday и оператор ++);\n" +
                "• операции сравнения по весу (операторы >, <, >=, <=);\n" +
                "• методы Heavier / Lighter — кто тяжелее и кто легче;\n" +
                "• перегрузка метода SetParams.",
                "О программе",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        // Выход
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}