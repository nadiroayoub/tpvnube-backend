
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CEN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;
using TPVNUBEGenNHibernate.Enumerated.Rest;
using TPVNUBEGenNHibernate.CP.Rest;

/*PROTECTED REGION END*/
namespace InitializeDB
{
    public class CreateDB
    {
        public static void Create(string databaseArg, string userArg, string passArg)
        {
            String database = databaseArg;
            String user = userArg;
            String pass = passArg;

            // Conex DB
            SqlConnection cnn = new SqlConnection(@"Server=(local)\sqlexpress; database=master; integrated security=yes");

            // Order T-SQL create user
            String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END";

            //Order delete user if exist
            String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
            //Order create databas
            string createBD = "CREATE DATABASE " + database;
            //Order associate user with database
            String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
            SqlCommand cmd = null;

            try
            {
                // Open conex
                cnn.Open();

                //Create user in SQLSERVER
                cmd = new SqlCommand(createUser, cnn);
                cmd.ExecuteNonQuery();

                //DELETE database if exist
                cmd = new SqlCommand(deleteDataBase, cnn);
                cmd.ExecuteNonQuery();

                //CREATE DB
                cmd = new SqlCommand(createBD, cnn);
                cmd.ExecuteNonQuery();

                //Associate user with db
                cmd = new SqlCommand(associatedUser, cnn);
                cmd.ExecuteNonQuery();

                System.Console.WriteLine("DataBase create sucessfully..");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void InitializeData()
        {
            /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
            try
            {
                // Insert the initilizations of entities using the CEN classes


                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");


                //crear dueno

                DuenyoCEN duenyo = new DuenyoCEN();
                int duenyo1 = duenyo.Nuevo("y1234", "Schahineze", "lairedj", "602579378", "Na41@.so8.", "schai@gmail.com", "");
                int duenyo2 = duenyo.Nuevo("Y6965X", "Ayoub", "Nadir", "602579378", "Na41@.so8.", "nadir@gmail.com", "");

                //crear empresa

                EmpresaCEN empresa = new EmpresaCEN();
                int empresa1 = empresa.Nuevo("empresa1", "calle universidad", duenyo1, "W0031949A", "empresa1@gmail.com", new DateTime(2010, 1, 18), "901063457", "Alicante", "Alicante", "España", "123456");

                NegocioCAD negocioCAD = new NegocioCAD();
                IList<NegocioEN> negocios1 = negocioCAD.ReadAll(0, -1);

                //crear negocio
                NegocioCEN negocio = new NegocioCEN();
                int negocio1 = negocio.Nuevo("negocio1", "saint vicente", "Alicante", "03001", "Alicante", "Pais", empresa1);
                int negocio2 = negocio.Nuevo("negocio2", "Alicante", "Alicante", "03001", "Alicante", "Pais", empresa1);
                int negocio3 = negocio.Nuevo("negocio3", "Murcia", "Murcia", "03001", "Alicante", "Pais", empresa1);
                int negocio4 = negocio.Nuevo("negocio4", "Valencia", "Valencia", "03001", "Alicante", "Pais", empresa1);


                IList<NegocioEN> negocios = negocioCAD.ReadAll(0, -1);
                //crear empleado
                EmpleadoCEN empleado = new EmpleadoCEN();


                int empleado1 = empleado.Nuevo(negocio2, "chahi", "ldj", "1234", "", "Y6946594", "scha@gmail.com", "602063565");
                int empleado2 = empleado.Nuevo(negocio2, "juan", "pederez", "1234", "", "Y6946595", "scha@gmail.com", "602070560");
                int empleado3 = empleado.Nuevo(negocio2, "ayoub", "nadir", "Na41@.so8.", "", "Y6946595X", "nadiroayoub@gmail.com", "602060090");

                IList<NegocioEN> negocios2 = negocioCAD.ReadAll(0, -1);

                //crear caja
                CajaCEN caja = new CajaCEN();
                int caja1 = caja.Nuevo(negocio2, "caja 1", duenyo1, 150, DateTime.Today);
                int caja2 = caja.Nuevo(negocio3, "caja 2", duenyo1, 120, DateTime.Today.AddDays(1));
                int caja3 = caja.Nuevo(negocio3, "caja 3", duenyo1, 120, DateTime.Today.AddDays(2));
                int caja4 = caja.Nuevo(negocio3, "caja 4", duenyo1, 120, DateTime.Today.AddDays(3));
                int caja5 = caja.Nuevo(negocio3, "caja 5", duenyo1, 120, DateTime.Today.AddDays(4));
                int caja6 = caja.Nuevo(negocio3, "caja 6", duenyo1, 120, DateTime.Today.AddDays(5));


                IList<NegocioEN> negocios4 = negocioCAD.ReadAll(0, -1);
                //crear tipo pago
                TipoPagoCEN tipoPago = new TipoPagoCEN();
                int pagotarjeta = tipoPago.Nuevo("tarjeta");
                int pagoeffectivo = tipoPago.Nuevo("effectivo");

                IList<NegocioEN> negocios5 = negocioCAD.ReadAll(0, -1);
                //crear pago
                PagoCEN pago = new PagoCEN();
                pago.Nuevo(50.5, new DateTime(2022, 10, 10), pagotarjeta, 123456, caja1);



                //crear mesa
                MesaCEN mesa = new MesaCEN();
                int mesa1 = mesa.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum.disponible, 1, negocio2);
                int mesa2 = mesa.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum.disponible, 2, negocio2);
                int mesa4 = mesa.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum.disponible, 4, negocio2);
                int mesa5 = mesa.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum.disponible, 5, negocio2);
                int mesa6 = mesa.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum.disponible, 6, negocio2);
                int mesa7 = mesa.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum.disponible, 7, negocio2);
                int mesa8 = mesa.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum.disponible, 8, negocio2);
                int mesa3 = mesa.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum.pendientePago, 3, negocio3);



                //crear cliente
                ClienteCEN cliente = new ClienteCEN();
                int cliente1 = cliente.Nuevo("y222", "maria", "sanchez", negocio2, "nadiroayoub@gmail.com");

                //crear tipo cobro
                TipoCobroCEN tipoCobro = new TipoCobroCEN();
                int tipoCobrotarjeta = tipoCobro.Nuevo("tarjeta");
                int tipoCobroeffectivo = tipoCobro.Nuevo("effectivo");



                //crear unidad medida
                UnidadMedidaCEN unidadMedida = new UnidadMedidaCEN();
                int litro = unidadMedida.Nuevo("litro");
                int kilo = unidadMedida.Nuevo("kg");

                //crear producto
                // ProductoCEN producto = new ProductoCEN();
                //int producto1= producto.Nuevo(litro, negocio2, "producto1");
                // int producto2 = producto.Nuevo(kilo, negocio2, "producto2");

                //crear proveedor
                ProveedorCEN proveedor = new ProveedorCEN();
                int proveedor1 = proveedor.Nuevo("proveedor", "602555986", "proveedor@gmail.com");

                //crear categoria servicio

                CategoriaServicioCEN categoriaServicio = new CategoriaServicioCEN();
                int servicioluz = categoriaServicio.Nuevo("luz");
                int servicioagua = categoriaServicio.Nuevo("agua");

                //crear servicio
                ServicioCEN servicio = new ServicioCEN();
                int servicio1 = servicio.Nuevo(negocio2, "luz", servicioluz);
                int servicio2 = servicio.Nuevo(negocio2, "agua", servicioagua);

                List<LineaCompraProveedorEN> lineaCompraProveedorEN = new List<LineaCompraProveedorEN>(){
                        new LineaCompraProveedorEN (0, 1, new ServicioCEN ().ReadOID (servicio1), null, null, 100),
                        new LineaCompraProveedorEN (0, 1, null, null, new ProductoCEN ().ReadOID (servicio2), 120)
                };

                // PRoductos
                ProductoCEN productoCEN = new ProductoCEN();
                int patatas = productoCEN.Nuevo(kilo, negocio2, "patatas");
                int aceite = productoCEN.Nuevo(litro, negocio2, "aceite");

                List<LineaPlatoEN> lineaPlatoENs1 = new List<LineaPlatoEN>(){
                        new LineaPlatoEN (0, 6, new ProductoCAD ().ReadOID (patatas), null),
                        new LineaPlatoEN (0, 4, new ProductoCAD ().ReadOID (aceite), null)
                };

                // Tipo Plato
                TipoPlatoCEN tipoPlatoCEN = new TipoPlatoCEN();
                int entrada = tipoPlatoCEN.Nuevo("Entrada");

                // Plato
                PlatoCEN platoCEN = new PlatoCEN();
                int sopaDePolloID = platoCEN.Nuevo("Sopa de pollo", 6, lineaPlatoENs1, "", entrada, negocio1);
                int tortaDePanquequesSaladaID = platoCEN.Nuevo("Torta de panqueques salada", 9, lineaPlatoENs1, "", entrada, negocio2);
                int cremaDeArvejasConTocinoID = platoCEN.Nuevo("Crema de arvejas con tocino", 5, lineaPlatoENs1, "", entrada, negocio2);

                //plato Menu
                List<LineaPlatoEN> lineaPlatoENs2 = new List<LineaPlatoEN>(){
                        new LineaPlatoEN (0, 3, new ProductoCAD ().ReadOID (patatas), null),
                        new LineaPlatoEN (0, 2, new ProductoCAD ().ReadOID (aceite), null)
                };
                int patatasFritasMenu = platoCEN.Nuevo("Patatas fritas Menu", 3, lineaPlatoENs2, "", entrada, negocio1);


                //Linea Platos
                LineaPlatoCEN lineaPlatoCEN = new LineaPlatoCEN();
                lineaPlatoCEN.Nuevo(0.3, patatas, sopaDePolloID);
                lineaPlatoCEN.Nuevo(0.05, aceite, cremaDeArvejasConTocinoID);

                // Linea plato menu
                lineaPlatoCEN.Nuevo(0.1, patatas, patatasFritasMenu);
                lineaPlatoCEN.Nuevo(0.03, aceite, patatasFritasMenu);


                //liena de menu
                List<LineaMenuEN> lineaMenuENs = new List<LineaMenuEN>(){
                        new LineaMenuEN (0, 1, new  PlatoCAD ().ReadOID (patatas), null)
                };


                // Menu
                MenuCEN menuCEN = new MenuCEN();
                int menu1 = menuCEN.Nuevo("diario 1", lineaMenuENs, "", 25, negocio2);
                int menu2 = menuCEN.Nuevo("diario 2", lineaMenuENs, "", 25, negocio2);
                int menu3 = menuCEN.Nuevo("diario 3", lineaMenuENs, "", 25, negocio2);
                int menu4 = menuCEN.Nuevo("diario 4", lineaMenuENs, "", 25, negocio2);


                //crear commanda
                ComandaCEN comanda = new ComandaCEN();
                // TODO: REMOVE
                //int comanda1 = comanda.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum.comanda, mesa1, empleado2);
                //int comanda2 = comanda.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum.comanda, mesa1, empleado2);
                //int comanda3 = comanda.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum.comanda, mesa1, empleado2);
                //int comanda4 = comanda.Nuevo(TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum.comanda, mesa1, empleado2);

                //// mesa modificar

                //LineaComandaCP lineaComandaCP = new LineaComandaCP ();
                //lineaComandaCP.NuevaLineaMenu (comanda1, 2, menu1);

                //lineaComandaCP.NuevaLineaMenu (comanda2, 2, menu1);

                //lineaComandaCP.NuevaLineaMenu (comanda3, 1, menu1);
                //lineaComandaCP.NuevaLineaMenu (comanda2, 2, menu2);

                //lineaComandaCP.NuevaLineaMenu (comanda3, 1, menu3);
                //lineaComandaCP.NuevaLineaMenu (comanda2, 2, menu4);

                //lineaComandaCP.NuevaLineaMenu (comanda3, 1, menu2);

                //lineaComandaCP.NuevaLineaPlato (comanda3, 3, cremaDeArvejasConTocinoID);
                //lineaComandaCP.NuevaLineaPlato (comanda3, 3, sopaDePolloID);
                //lineaComandaCP.NuevaLineaPlato (comanda3, 3, tortaDePanquequesSaladaID);
                //lineaComandaCP.NuevaLineaPlato (comanda3, 3, sopaDePolloID);
                //lineaComandaCP.NuevaLineaPlato (comanda3, 3, sopaDePolloID);

                ////crear cobro
                //CobroCP cobro = new CobroCP ();
                //cobro.Nuevo (50, comanda1, tipoCobrotarjeta, caja2, empleado1, negocio1);
                //cobro.Nuevo (150, comanda2, tipoCobrotarjeta, caja2, empleado1, negocio2);
                //cobro.Nuevo (140, comanda3, tipoCobrotarjeta, caja2, empleado1, negocio3);
                //cobro.Nuevo (10, comanda4, tipoCobrotarjeta, caja2, empleado2, negocio4);
                //cobro.Nuevo (15, comanda4, tipoCobrotarjeta, caja1, empleado3, negocio1);
                //cobro.Nuevo (6, comanda4, tipoCobrotarjeta, caja1, empleado3, negocio2);
                //cobro.Nuevo (12, comanda4, tipoCobrotarjeta, caja1, empleado3, negocio3);
                //cobro.Nuevo (13.50f, comanda4, tipoCobrotarjeta, caja1, empleado3, negocio4);
                //cobro.Nuevo (20.25f, comanda4, tipoCobrotarjeta, caja1, empleado1, negocio1);
                //cobro.Nuevo (15, comanda4, tipoCobrotarjeta, caja2, empleado1, negocio1);
                //cobro.Nuevo (6, comanda4, tipoCobrotarjeta, caja2, empleado2, negocio2);
                //cobro.Nuevo (12, comanda4, tipoCobrotarjeta, caja3, empleado3, negocio3);
                //cobro.Nuevo (13.50f, comanda4, tipoCobrotarjeta, caja3, empleado1, negocio4);
                //cobro.Nuevo (20.25f, comanda4, tipoCobrotarjeta, caja3, empleado3, negocio1);

                //cobro.Nuevo (12, comanda4, tipoCobrotarjeta, caja4, empleado3, negocio2);
                //cobro.Nuevo (13.50f, comanda4, tipoCobrotarjeta, caja4, empleado2, negocio3);
                //cobro.Nuevo (20.25f, comanda4, tipoCobrotarjeta, caja5, empleado3, negocio4);
                //cobro.Nuevo (20.25f, comanda4, tipoCobrotarjeta, caja6, empleado2, negocio1);



                //crear factura
                FacturaCEN factura = new FacturaCEN();
                factura.Nuevo("A123", new DateTime(2022, 10, 14), 50.5, "factura", comanda1, cliente1);












                /*PROTECTED REGION END*/
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
    }
}
