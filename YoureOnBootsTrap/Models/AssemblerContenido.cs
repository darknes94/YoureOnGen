﻿using YoureOnBootsTrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoureOnGenNHibernate.EN.YoureOn;
using YoureOnGenNHibernate.Enumerated.YoureOn;
using System.Diagnostics;

namespace WebApplication1.Models
{
    public class AssemblerContenido
    {
        public Contenido ConvertENToModelUI(ContenidoEN contenidoEN)
        {
            Contenido contenido = new Contenido();
            contenido.Id = contenidoEN.Id_contenido;
            contenido.Titulo = contenidoEN.Titulo;
            contenido.Tipo = contenidoEN.TipoArchivo;
            contenido.Descripcion = contenidoEN.Descripcion;
            contenido.Licencia = contenidoEN.Licencia;
            contenido.Autor = contenidoEN.Autor;
            contenido.EnBibioteca = contenidoEN.EnBiblioteca;
            contenido.Ruta = contenidoEN.Url;
            contenido.FCreacion = contenidoEN.FechaCreacion.Value;

            return contenido;
        }
        public ContenidoYComentarios ConvertENToModel(ContenidoEN contenidoEN)
        {
            ContenidoYComentarios contenido = new ContenidoYComentarios();
            contenido.Id = contenidoEN.Id_contenido;
            contenido.Titulo = contenidoEN.Titulo;
            contenido.Tipo = contenidoEN.TipoArchivo;
            contenido.Descripcion = contenidoEN.Descripcion;
            contenido.Licencia = contenidoEN.Licencia;
            contenido.Autor = contenidoEN.Autor;
            contenido.EnBibioteca = contenidoEN.EnBiblioteca;
            contenido.Ruta = contenidoEN.Url;
            contenido.FCreacion = contenidoEN.FechaCreacion.Value;
            Debug.WriteLine(contenidoEN.Comentario.Count);
            if (contenidoEN.Comentario.Count > 0)
                contenido.ListaComentarios = contenidoEN.Comentario;

            return contenido;
        }
        //Está la lista generada faltaria ordenarla por fecha
        public IList<Contenido> ConvertListENToModel(IList<ContenidoEN> contenidosEN)
        {
            IList<Contenido> contenidos = new List<Contenido>();
            ContenidoEN contenEn = new ContenidoEN();
            int contador = 0;
            while (contador < 4)
            {
                contenEn = contenidosEN.ElementAt(contador);
                contenidos.Add(ConvertENToModelUI(contenEn));
                contador++;
            }
            return contenidos;
        }
    }
}
