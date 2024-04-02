using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace TestCreator
{
    public partial class TestPage : Window
    {
        private TestViewModel viewModel;

        public TestPage()
        {
            InitializeComponent();
            viewModel = new TestViewModel();
            DataContext = viewModel;
        }

        private void Ass1_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var answer = (string)button.Content;

            viewModel.CheckAnswer(answer);
        }

        private void Ass2_Click(object sender, RoutedEventArgs e)
        {
         
        }
        private void Ass3_Click(object sender, RoutedEventArgs e)
        {

        }

    }

    public class TestViewModel : INotifyPropertyChanged
    {
        private List<test> tests;
        private int currentQuestionIndex;
        private int correctAnswersCount;

        public TestViewModel()
        {
            tests = jsonKrch.Deseril<test>("Quest.json");
            currentQuestionIndex = 0;
            correctAnswersCount = 0;

            UpdateQuestion();
        }

        public string Quest => tests[currentQuestionIndex].disc;
        public string Ass1 => tests[currentQuestionIndex].aFirst;
        public string Ass2 => tests[currentQuestionIndex].aSecond;
        public string Ass3 => tests[currentQuestionIndex].aThird;

        public ICommand AnswerCommand => new RelayCommand<string>(CheckAnswer);

        private void UpdateQuestion()
        {
            OnPropertyChanged(nameof(Quest));
            OnPropertyChanged(nameof(Ass1));
            OnPropertyChanged(nameof(Ass2));
            OnPropertyChanged(nameof(Ass3));
        }
        public void CheckAnswer(string selectedAnswer)
        {
            var trueAnswer = tests[currentQuestionIndex].trueAnswer.ToString();

            if (selectedAnswer == trueAnswer)
                correctAnswersCount++;
                currentQuestionIndex++;
            if (currentQuestionIndex < tests.Count)
                UpdateQuestion();
            else
                MessageBox.Show($"Правильно {correctAnswersCount} из {tests.Count} вопросов.", "ДЖИ ДЖИ");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Predicate<T> canExecute;

        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            execute((T)parameter);
        }
    }
}
