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

        private void NewGame()
        {
            mResults = new MarkType[9];
        }
    }
}
