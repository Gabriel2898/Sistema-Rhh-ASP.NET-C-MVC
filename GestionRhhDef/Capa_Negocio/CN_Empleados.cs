using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Negocio
{
    public class CN_Empleados
    {
        CD_Empleados contacto = new CD_Empleados();
        DataTable datagrid;

        public void agregarEmpleados(String carId, String depId, String emplCedula, String emplNombre, String emplApellidos, String emplTelefono, String emplDireccion)
        {
            contacto.agregarEmpleados(Convert.ToInt32(carId), Convert.ToInt32(depId), emplCedula, emplNombre, emplApellidos, emplTelefono, emplDireccion);
        }

        public void actualizarEmpleados(String emplId, String carId, String depId, String emplCedula, String emplNombre, String emplApellidos, String emplTelefono, String emplDireccion)
        {
            contacto.actualizarEmpleados(Convert.ToInt32(emplId),Convert.ToInt32(carId), Convert.ToInt32(depId), emplCedula, emplNombre, emplApellidos, emplTelefono, emplDireccion);
        }

        public void eliminarEmpleados(String emplId)
        {
            contacto.eliminarEmpleados(Convert.ToInt32(emplId));
        }

        public DataTable verEmpleados()
        {
            datagrid = contacto.mostrarEmpleados();
            return datagrid;
        }

        public DataTable buscarEmpleados(String emplId)
        {
            datagrid = contacto.buscarEmpleados(Convert.ToInt32(emplId));
            return datagrid;
        }

        public bool ValidarCedula(String cedula)
        {
            int Numerico;
            var total = 0;
            int TamanoCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int provincia1 = 24;
            int Verificador = 6;

            if (int.TryParse(cedula, out Numerico) && cedula.Length == TamanoCedula)
            {
                int provincia = Convert.ToInt32(string.Concat(cedula[0], cedula[1], string.Empty));
                var digitosTres = Convert.ToInt32(cedula[2] + string.Empty);

                if ((provincia > 0 && provincia <= provincia1) && digitosTres < Verificador)
                {
                    var digitoVerificador = Convert.ToInt32(cedula[9] + string.Empty);
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) *
                                    Convert.ToInt32(cedula[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;


                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ?
                                                10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorObtenido == digitoVerificador;
                }
                return false;
            }
            return false;
        }

    }
}
