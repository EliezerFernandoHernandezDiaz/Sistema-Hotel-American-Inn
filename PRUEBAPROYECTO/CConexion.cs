using System.Windows.Forms;
using MySqlConnector; /*Libreria que es obligatoria agregarla para que conecte el visual studio con mysql*/

namespace Clave5_Grupo6
{
    class CConexion        //Nombre de la clase, esta clase es la que se encarga de mantener conectado el codigo con mysql
    {

        //Instancia de la libreria que agregamos para controlar la conexion a la bd

        MySqlConnection conex = new MySqlConnection();

        /*Cambié los parametros de la conexión a la bd*/

        static string servidor = "127.0.0.1";
        static string bd = "clave5_grupo6db";       //Se agregan los parametros de conexión con el server que aloja la bd en mysql 
        static string usuario = "fer";
        static string password = "fernando123";
        static string puerto = "3306";

        //Agregando allow public key retrieval 
        static string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" +
            "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";"
            + "AllowPublicKeyRetrieval=True;" + "SslMode=None;";
        /*Concatenación de cadenas que mantienen el codigo fuente 
                                                                                                     * conectado a mysql*/

        public object Messagebox { get; private set; }

        //Instancia de la libreria que establece la conexion entre mysql y el codigo 

        public MySqlConnection EstablecerConexion()
        {
            try
            {
                //Conexion y apertura a la bd
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MessageBox.Show("Conexión ok ");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySqlException" + ex.Message);
                return null;

            }
            return conex;
            /*Aqui implementamos un try catch para que maneje excepciones 
                                                                            * en caso de que falle la conexión, al igual que si esta conexion 
                                                                            * es exitosa tambien envie un mensaje a traves del boton de conectar
                                                                            * que pusimos en cada formulario*/
        }
    }
}
