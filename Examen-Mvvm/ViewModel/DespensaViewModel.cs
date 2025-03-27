using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Mvvm.ViewModel
{
    public partial class DespensaViewModel : ObservableObject
    {
        [ObservableProperty]
        private double producto1;

        [ObservableProperty]
        private double producto2;

        [ObservableProperty]
        private double producto3;

        [ObservableProperty]
        private double descuento;

        [ObservableProperty]
        private double subtotal;

        [ObservableProperty]
        private double total;



        [RelayCommand]
        private void Calcular()
        {
            try
            {
                if (Producto1 < 0)
                {

                    Alerta("ADVERTENCIA", "El valor del producto 1 no puede ser negativo");

                }
                else if (Producto2 < 0)
                {
                    Alerta("ADVERTENCIA", "El valor del producto 2 no puede ser negativo");

                }
                else if (Producto3 < 0)
                {
                    Alerta("ADVERTENCIA", "El valor del producto 3 no puede ser negativo");
                }
                else
                {
                    Subtotal = Producto1 + Producto2 + Producto3; 

                    if(Subtotal >= 0.00 && Subtotal <= 999.99)
                    {
                        Alerta("AVISO", "No se aplicara ningun descuento ");
                        Descuento = 0; 

                    }else if(Subtotal >= 1000.00 && Subtotal <= 4999.99)
                    {
                        Descuento = .10; 

                    }else if(Subtotal >= 5000.00 && Subtotal <= 9999.99)
                    {
                        Descuento = .20; 

                    }
                    else
                    {
                        Descuento = .30;

                    }

                    Total = Subtotal - (Subtotal * Descuento); 

                }

            }catch(Exception e)
            {
                Alerta("ERROR", e.Message); 
            }
        }


        [RelayCommand]
        private void Limpiar()
        {
            Producto1 = 0;
            Producto2 = 0;
            Producto3 = 0;
            Subtotal = 0;
            Descuento = 0;
            Total = 0; 
        }



        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }


    }
}
