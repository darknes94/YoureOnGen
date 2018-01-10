
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using YoureOnGenNHibernate.EN.YoureOn;
using YoureOnGenNHibernate.CAD.YoureOn;
using YoureOnGenNHibernate.CEN.YoureOn;



/*PROTECTED REGION ID(usingYoureOnGenNHibernate.CP.YoureOn_Usuario_comentar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace YoureOnGenNHibernate.CP.YoureOn
{
public partial class UsuarioCP : BasicCP
{
public int Comentar (string usuario_oid, int contenido_oid, string texto)
{
        /*PROTECTED REGION ID(YoureOnGenNHibernate.CP.YoureOn_Usuario_comentar) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        IContenidoCAD contenidoCAD = null;
        UsuarioCEN usuarioCEN = null;
        ContenidoCEN contenidoCEN = null;
        UsuarioEN usuario = null;
        ContenidoEN contenido = null;

        ComentarioCAD comentarioCAD = null;
        ComentarioCEN comentarioCEN = null;

        int result = -1;

        try
        {
                SessionInitializeTransaction ();
                session.BeginTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                contenidoCAD = new ContenidoCAD (session);
                comentarioCAD = new ComentarioCAD (session);

                usuarioCEN = new UsuarioCEN (usuarioCAD);
                contenidoCEN = new ContenidoCEN (contenidoCAD);
                comentarioCEN = new ComentarioCEN (comentarioCAD);

                usuario = usuarioCAD.ReadOIDDefault (usuario_oid);
                contenido = contenidoCAD.ReadOIDDefault (contenido_oid);

                ComentarioEN comentario = new ComentarioEN ();
                comentario = new ComentarioEN (comentario.Id_comentario, texto, DateTime.Now, usuario, null, contenido, null);

                usuario.Comentario.Add (comentario);
                contenido.Comentario.Add (comentario);

                /*Debug.WriteLine(contenido.Comentario.IndexOf(comentario));
                 * Debug.WriteLine(usuario.Email);
                 * Debug.WriteLine(contenido.Titulo);*/

                session.Save (comentario);
                session.Save (contenido);
                session.Save (usuario);
                session.Transaction.Commit ();
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
