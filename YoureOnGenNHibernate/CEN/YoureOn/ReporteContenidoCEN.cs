

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using YoureOnGenNHibernate.Exceptions;

using YoureOnGenNHibernate.EN.YoureOn;
using YoureOnGenNHibernate.CAD.YoureOn;


namespace YoureOnGenNHibernate.CEN.YoureOn
{
/*
 *      Definition of the class ReporteContenidoCEN
 *
 */
public partial class ReporteContenidoCEN
{
private IReporteContenidoCAD _IReporteContenidoCAD;

public ReporteContenidoCEN()
{
        this._IReporteContenidoCAD = new ReporteContenidoCAD ();
}

public ReporteContenidoCEN(IReporteContenidoCAD _IReporteContenidoCAD)
{
        this._IReporteContenidoCAD = _IReporteContenidoCAD;
}

public IReporteContenidoCAD get_IReporteContenidoCAD ()
{
        return this._IReporteContenidoCAD;
}

public int New_ (Nullable<DateTime> p_fecha, int p_contenido)
{
        ReporteContenidoEN reporteContenidoEN = null;
        int oid;

        //Initialized ReporteContenidoEN
        reporteContenidoEN = new ReporteContenidoEN ();
        reporteContenidoEN.Fecha = p_fecha;


        if (p_contenido != -1) {
                // El argumento p_contenido -> Property contenido es oid = false
                // Lista de oids id_reporte
                reporteContenidoEN.Contenido = new YoureOnGenNHibernate.EN.YoureOn.ContenidoEN ();
                reporteContenidoEN.Contenido.Id_contenido = p_contenido;
        }

        //Call to ReporteContenidoCAD

        oid = _IReporteContenidoCAD.New_ (reporteContenidoEN);
        return oid;
}

public void Modify (int p_ReporteContenido_OID, Nullable<DateTime> p_fecha)
{
        ReporteContenidoEN reporteContenidoEN = null;

        //Initialized ReporteContenidoEN
        reporteContenidoEN = new ReporteContenidoEN ();
        reporteContenidoEN.Id_reporte = p_ReporteContenido_OID;
        reporteContenidoEN.Fecha = p_fecha;
        //Call to ReporteContenidoCAD

        _IReporteContenidoCAD.Modify (reporteContenidoEN);
}

public void Destroy (int id_reporte
                     )
{
        _IReporteContenidoCAD.Destroy (id_reporte);
}
}
}
