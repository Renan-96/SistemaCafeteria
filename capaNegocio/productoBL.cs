using capaDatos;
using capaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class productoBL
    {
        claseDatos dato = new claseDatos();

        public DataSet Listado()
        {
            return dato.Listado("SELECT * FROM PRODUCTOS");
        }

        public int guardar(ProductosEntity producto)
        {
            return dato.ejecutar("INSERT INTO CATEGORIAS(CODIGO,NOMBRE) VALUES(" + producto.codigo + ",'" + producto.nombre + "')");
        }
    }
}
