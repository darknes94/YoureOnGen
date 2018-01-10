
using System;
// Definición clase ReporteContenidoEN
namespace YoureOnGenNHibernate.EN.YoureOn
{
public partial class ReporteContenidoEN                                                                     : YoureOnGenNHibernate.EN.YoureOn.ReporteEN


{
/**
 *	Atributo contenido
 */
private YoureOnGenNHibernate.EN.YoureOn.ContenidoEN contenido;






public virtual YoureOnGenNHibernate.EN.YoureOn.ContenidoEN Contenido {
        get { return contenido; } set { contenido = value;  }
}





public ReporteContenidoEN() : base ()
{
}



public ReporteContenidoEN(int id_reporte, YoureOnGenNHibernate.EN.YoureOn.ContenidoEN contenido
                          , Nullable<DateTime> fecha
                          )
{
        this.init (Id_reporte, contenido, fecha);
}


public ReporteContenidoEN(ReporteContenidoEN reporteContenido)
{
        this.init (Id_reporte, reporteContenido.Contenido, reporteContenido.Fecha);
}

private void init (int id_reporte
                   , YoureOnGenNHibernate.EN.YoureOn.ContenidoEN contenido, Nullable<DateTime> fecha)
{
        this.Id_reporte = id_reporte;


        this.Contenido = contenido;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReporteContenidoEN t = obj as ReporteContenidoEN;
        if (t == null)
                return false;
        if (Id_reporte.Equals (t.Id_reporte))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id_reporte.GetHashCode ();
        return hash;
}
}
}
