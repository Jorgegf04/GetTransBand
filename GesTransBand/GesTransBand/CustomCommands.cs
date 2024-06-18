using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GesTransBand
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand ListActive = new RoutedUICommand
            (
                "ListActive",
                "ListActive",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.L, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand NuevoActivo = new RoutedUICommand
            (
                "NuevoActivo",
                "NuevoActivo",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.N, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand ListaCintas = new RoutedUICommand
            (
                "ListaCintas",
                "ListaCintas",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.L, ModifierKeys.Alt)
                }
            );

        public static readonly RoutedUICommand NuevaCinta = new RoutedUICommand
            (
                "NuevaCinta",
                "NuevaCinta",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.N, ModifierKeys.Alt)
                }
            );

        public static readonly RoutedUICommand ExitAplication = new RoutedUICommand
        (
            "ExitAplication",
            "ExitAplication",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand ManageUsers = new RoutedUICommand
        (
            "ManageUsers",
            "ManageUsers",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.U, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand ManageContactPersons = new RoutedUICommand
        (
            "ManageContactPersons",
            "ManageContactPersons",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.C, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand ManageCompanies = new RoutedUICommand
        (
            "ManageCompanies",
            "ManageCompanies",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.P, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand ManageProducts = new RoutedUICommand
        (
            "ManageProducts",
            "ManageProducts",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.P, ModifierKeys.Alt)
            }
        );

        public static readonly RoutedUICommand ManageAssembler = new RoutedUICommand
        (
            "ManageAssembler",
            "ManageAssembler",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.M, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand MontajeCinta = new RoutedUICommand
        (
            "MontajeCinta",
            "MontajeCinta",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.J, ModifierKeys.Alt)
            }
        );

        public static readonly RoutedUICommand CintasPorActivo = new RoutedUICommand
        (
            "CintasPorActivo",
            "CintasPorActivo",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.J, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand ViewTree = new RoutedUICommand
       (
           "ViewTree",
           "ViewTree",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.T, ModifierKeys.Control)
           }
       );
    }
}
