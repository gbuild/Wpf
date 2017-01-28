using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        /// <summary>
        /// Содержание текущего результата игры
        /// </summary>
        private MarkType[] mResults;
        /// <summary>
        /// Истина если первый игрок играет Х или второй за O
        /// </summary>
        private bool mPlayer1Turn;
        /// <summary>
        /// Истина если игра закончена
        /// </summary>
        private bool mGameEnded;
        #endregion
        #region Constructor

        /// <summary>
        ///  Default constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        #endregion

        /// <summary>
        /// Начало новой игры и установка значений по умолчанию
        /// </summary>
        private void NewGame()
        {
            // Создание пустого поля
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            // Первый игрок начинает игру
            mPlayer1Turn = true;

            // Взаимодействие с кнопками на поле
            Container.Children.Cast<Button>().ToList().ForEach(Button =>
            {
                // Замена заднего и переднего фона а так же содержимого клеток на значение по умолчанию
                Button.Content = string.Empty;
                Button.Background = Brushes.White;
                Button.Foreground = Brushes.Blue;
            }
            );

            // Игра еще не закончена
            mGameEnded = false;
            
        }
        /// <summary>
        /// Описание клика мыши по кнопке
        /// </summary>
        /// <param name="sender">Кнопка была нажата</param>
        /// <param name="e">Событие нажатия</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Старт новой игры по клику после её завершения
            if(mGameEnded)
            {
                NewGame();
                return;
            }
            // Захват кнопки
            var button = (Button)sender;

            // Нахождение позиции кнопки в массиве
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // Не делать ничего если клетка уже занята
            if (mResults[index] != MarkType.Free)
                return;

            // Установить значение поля в зависимости от очереди игроков
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // Отображение значения поля
            button.Content = mPlayer1Turn ? "X" : "O";

            // Смена цвета у второго игрока
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red; 


            // Переключение игроков
            mPlayer1Turn ^= true;

            // Проверка на победителя
            CheckForWinner();
        }
        /// <summary>
        /// Проверка на победителя 3 в ряд
        /// </summary>
        private void CheckForWinner()
        {
            #region Победа по горизонтали
            // Победа по горизонтали
            // Строка 1 {0}
            if (mResults[0] !=MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                // Игра окончена
                mGameEnded = true;
                
                // Покраска победившей линии
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            // Строка 2 {1}
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                // Игра окончена
                mGameEnded = true;

                // Покраска победившей линии
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            // Строка 3 {2}
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                // Игра окончена
                mGameEnded = true;

                // Покраска победившей линии
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }
            #endregion
            #region Победа по вертикали
            // Победа по вертикали
            // Столбец 1 {0}
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                // Игра окончена
                mGameEnded = true;

                // Покраска победившей линии
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            // Столбец 2 {1}
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                // Игра окончена
                mGameEnded = true;

                // Покраска победившей линии
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            // Столбец 3 {2}
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[7]) == mResults[2])
            {
                // Игра окончена
                mGameEnded = true;

                // Покраска победившей линии
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }
            #endregion
            #region Победа по диагонали
            // Победа по диагонали
            // Левый верх Правый низ
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                // Игра окончена
                mGameEnded = true;

                // Покраска победившей линии
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            // Правый верх Левый низ
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                // Игра окончена
                mGameEnded = true;

                // Покраска победившей линии
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }
            #endregion 
            #region Ничья
            // Проверка на ничью и заполненое поле
            if (!mResults.Any(result=>result==MarkType.Free))
            {
                // Игра окончена
                mGameEnded = true;

                // Покраска поля
                Container.Children.Cast<Button>().ToList().ForEach(Button =>
                {
                    Button.Background = Brushes.Orange;
                });
            }
            #endregion
        }
    }
}
