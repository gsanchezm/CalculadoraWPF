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

namespace Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Variable auxiliar para determinar cuando se debe borrar el texto que está en pantalla.
        bool limpiarPantalla = false;

        // Variables para las operaciones de la calculadora.
        double operando1;
        double operando2;
        string operador;

        //Crear un objeto del tipo Operaciones
        readonly Operaciones operacion = new Operaciones();
        public Operaciones Operacion => operacion;

        private void gridDigitos_Click(object sender, RoutedEventArgs e)
        {
            //Comprobamos que el evento se originó en un botón.(recordar que WPF maneja eventos enrutados que son diferentes a los eventos win form clásicos.
            if (e.OriginalSource is Button)
            {
                Button digitoPulsado = (Button)e.OriginalSource; // Conversión de e.OriginalSource a Button.

                // Comprobamos que es un botón que representa un digito.
                int i = 0;
                bool isDigit = false;
                isDigit = int.TryParse(digitoPulsado.Tag.ToString(), out i);// Si la conversión es posible, el número entero se almacena en la variable i.

                if (isDigit)
                {
                    if (limpiarPantalla)
                    {
                        txtbkPantalla.Text = "";
                        limpiarPantalla = false;
                    }
                    txtbkPantalla.Text += digitoPulsado.Tag.ToString(); // se puede sustituir por i.
                }
                else if (digitoPulsado.Tag.ToString() == ".") // se presiono botón punto.
                {
                    // Checamos si ya se ha escrito un punto anteriormente
                    if (txtbkPantalla.Text.IndexOf(".") >= 0) // IndexOf() retorna -1 si no se encuentra el punto en la cadena.
                    {
                        return;
                    }
                    else
                    {
                        txtbkPantalla.Text += ".";
                    }
                }
                else if (digitoPulsado.Tag.ToString() == "C") // Se presionó el botón "limpiar pantalla" (C).
                {
                    txtbkPantalla.Text = "";
                }
            }
        }

        private void gridOperadores_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button)
            {
                Button operadorPulsado = (Button)e.OriginalSource;

                if (operadorPulsado.Tag.ToString() != "=") // No se presionó el botón signo igual.
                {
                    operando1 = Convert.ToDouble(txtbkPantalla.Text);
                    operador = operadorPulsado.Tag.ToString();
                    limpiarPantalla = true; // Ahora vamos a escribir el segundo operador por lo que se tiene que limpiar la pantalla.
                }
                else // Se presionó el signo igual.
                {

                    try // Las operaciones van en un bloque try-catch por que puede haber desbordamiento debido a los límites de almacenamiento del tipo double.
                    {
                        double resultadoDeOperacion = 0;
                        operando2 = Convert.ToDouble(txtbkPantalla.Text);

                        switch (operador)
                        {
                            case "+":
                                resultadoDeOperacion = Operacion.Suma(operando1, operando2);
                                break;
                            case "-":
                                resultadoDeOperacion = Operacion.Resta(operando1, operando2);
                                break;
                            case "*":
                                resultadoDeOperacion = Operacion.Multiplicacion(operando1, operando2);
                                break;
                            case "/":
                                if (operando2 != 0) 
                                {
                                    resultadoDeOperacion = Operacion.Division(operando1, operando2);
                                }
                                break;
                        }
                        txtbkPantalla.Text = resultadoDeOperacion.ToString();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        limpiarPantalla = true;
                    }
                }
            }

        }

        private void Calculadora_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string tecla = e.Text;
            //MessageBox.Show(tecla);
            switch (tecla)
            {
                case "1":
                    cmd1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Es una forma de emular un PerformClick() típico de win forms;
                    break;
                case "2":
                    cmd2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "3":
                    cmd3.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "4":
                    cmd4.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "5":
                    cmd5.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "6":
                    cmd6.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "7":
                    cmd7.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "8":
                    cmd8.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "9":
                    cmd9.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "0":
                    cmd0.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case ".":
                    cmdPunto.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "C":
                case "c":
                    cmdC.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "+":
                    cmdSumar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "-":
                    cmdRestar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "*":
                    cmdMultiplicar.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "/":
                    cmdDividir.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case "=":
                    cmdIgual.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                default: return;
            }
        }

        private void Calculadora_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Un caso especial es la tecla "Enter o Intro" que no produce un texto por eso se maneja en el PreviewKeyDown.
            if (e.Key == Key.Enter)
            {
                cmdIgual.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

        }

    }
}
