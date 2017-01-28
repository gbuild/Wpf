using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
/// <summary>
/// Тип значения клетки в текущей игре
/// </summary>
    public enum MarkType
    {
        /// <summary>
        /// Клетка еще не заполнена
        /// </summary>
        Free,
        /// <summary>
        /// Значение клетки O
        /// </summary>
        Nought,
        /// <summary>
        /// Значение клетки X
        /// </summary>
        Cross
    }
}
