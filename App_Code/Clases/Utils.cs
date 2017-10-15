
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Utils
/// </summary>
public class Utils
{
    public Utils()
    {
        
    }

    public static bool validarRut(string campoValidar)
    {
        bool resultado = true;

        campoValidar = campoValidar.Replace("-", "");

        string digitoVerificador = campoValidar.Substring(campoValidar.Length - 1);
        string sinDigito = campoValidar.Substring(0, campoValidar.Length - 1);

        if (validarNumero(sinDigito))
        {
            int rut = Convert.ToInt32(sinDigito);

            int Digito;
            int Contador;
            int Multiplo;
            int Acumulador;
            String RutDigito;

            Contador = 2;
            Acumulador = 0;

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                {
                    Contador = 2;
                }
            }

            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
            {
                RutDigito = "K";
            }
            if (Digito == 11)
            {
                RutDigito = "0";
            }

            if (RutDigito != digitoVerificador)
            {
                resultado = false;
            }
        }
        else
        {
            resultado = false;
        }

        return resultado;
    }

    public static bool validarNumero(string campoValidar)
    {
        bool resultado = true;

        int num;

        resultado = Int32.TryParse(campoValidar.ToString(), out num);

        return resultado;
    }
}