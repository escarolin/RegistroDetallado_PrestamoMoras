using System;
using System.Linq;
using System.Linq.Expressions;
using RegistroDetallado_PrestamoMoras.DAL;
using System.Collections.Generic;
using RegistroDetallado_PrestamoMoras.Entidades;
using Microsoft.EntityFrameworkCore;

namespace RegistroDetallado_PrestamoMoras.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PrestamoId))
                return Insertar(prestamos);
            else
            {
                return Modificar(prestamos);
            }
        }

        private static bool Insertar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //agregar la entidad que decea insertar en el contexto
                contexto.Prestamos.Add(prestamos);
                paso = contexto.SaveChanges() > 0;

            }

            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        private static bool Modificar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(prestamos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entida que se desea eliminar
                var prestamos = contexto.Prestamos.Find(id);
                if (prestamos != null)
                {
                    contexto.Prestamos.Remove(prestamos); //remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos;
            try
            {
                prestamos = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestamos;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Prestamos.Any(e => e.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return encontrado;

        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
            try
            {
                //Obtener la lista y filtrarla segun el criterio recibido por parametro.
                lista = contexto.Prestamos.Where(criterio).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return lista;
        }

        public static List<Prestamos> GetPrestamo()
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return lista;
        }
    }
}