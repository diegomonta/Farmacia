PROYECTO FINAL DE PRIMER AÑO CARRERA DE ANALISTA DE SISTEMAS PROGRAMADOR WEB .NET 2018 

Generalidades  La entrega final se hará durante la última clase de tutoría. Durante las clases de tutorías deberán realizarse entregas parciales de acuerdo a lo establecido en la sección Tutorías & Entregas.    Se deberá realizar la entrega mediante correo electrónico, del software junto con toda la documentación exigida en la sección Requerimientos de Entrega :  Asunto: Entrega Proyecto Final PRO 2018  Destinatarios:  primeroanalista@bios.edu.uy y tutor asignado (OBLIGATORIO)  Adjuntos - Compartido: documentación y solución completa  Cuerpo: Nombre y Cedula de los integrantes del grupo que realiza la entrega   Se deberán formar grupos de 1 a 3 personas, los cuales deberán inscribirse en bedelía (bedeliasistemas@bios.edu.uy) desde el día 19 de noviembre hasta el día 3 de diciembre .
 N o s e a c e p t a r a n i n s c r i p c i o n e s f u e r a d e f e c h a .  Luego de esto, Bedelía publicara la asignación de tutores así como los horarios. La inscripción es únicamente por vía mail ( bedeliasistemas@bios.edu.uy ) , con el sig uiente formato : 1. Asunto: Inscripción a Proyecto Final Primer Año 2. Contenido:  a. Cedula y Nombre de todos los integrantes del grupo que se presenta b. Franja Horaria a la que se concurre a clase  La asistencia a la última tutoría es obligatoria para todos los miembros del grupo ya que se realizara la defensa en máquina del proyecto.  

Idea General Una farmacia, se ha contactado con su equipo para encargarle el desarrollo de su nuevo sitio web para pedidos online.  

Descripción de la Realidad   La farmacia trabaja con un conjunto de farmacéuticas, que proveen los medicamentos que se venden. De dichas farmacéuticas se sabe: su RUC (único en el sistema e identificador), nombre, correo electrónico, y dirección.  De cada medicamento de una farmacéutica que se tiene en stock, se deberá saber: farmacéutica que lo produce, código (el cual dependerá de la farmacéutica), nombre, descripción, y su precio.    Todos los usuarios del sistema deberán tener nombre de usuario de logueo (único en el sistema e identificador del usuario), contraseña y nombre completo (compuesto por nombre y apellido). De los usuarios de tipo cliente, también se deberá saber dirección de entrega de pedidos y un teléfono de contacto. De los usuarios empleados se deberá saber su horario de trabajo, compuesto por hora de inicio y hora final.   Los clientes que realicen pedidos de medicamentos, deberán estar previamente registrados en el sistema. De los pedidos se sabe: el número (autogenerado por el sistema e identificador único), cliente que lo realiza, que medicamento y cantidad se solicita, y el estado actual del mismo.


Proyecto Final Primer Año Página 2 de 5 Carrera Analista de Sistemas
Funcionalidades Mínimas del Sitio Web

Formulario Web: Logueo (formulario por defecto del sitio)  Actor Participante: público Resumen: Mediante esta página se permitirá el logueo de un usuario al sitio (ingreso de usuario y contraseña). No se permite el uso de controles de tipo Login . Si el usuario logueado es de tipo empleado, el sistema lo re direccionará a la página de bienvenida para empleados . Si el usuario es de tipo cliente, se lo re direccionará a la página Realizar Pedidos .  


Formulario Web: ABM de Farmacéuticas.  Actor Participante: Usuario empleado  Resumen: Este formulario permitirá realizar cualquiera de las 3 acciones, a partir del ingreso del RUC. Si el RUC ya existe se podrá eliminar o modificar dicha farmacéutica (previo despliegue de todos sus datos). En caso de que no exista, se solicitaran todos los datos para generar una nueva farmacéutica en el repositorio de datos. Tomar en cuenta que si se elimina una farmacéutica, y ti ene pedidos asociados, no se podrá eliminar; de lo contrario se podrá eliminar conjuntamente con sus dependencias (medicamentos).


Formulario Web: ABM de Medicamentos.  Actor Participante: Usuario empleado Resumen: Este formulario permitirá realizar cualquiera de las 3 acciones, a partir del ingreso del identificador de un medicamento (ruc de farmacéutica y código de medicamento). Si dicho identificador ya existe se podrá eliminar o modificar el medicamento (previo despliegue de todos sus datos). En caso de que no exista, se solicitaran todos los datos para generar un nuevo medicamento en el repositorio de datos. Tomar en cuenta que si se elimina un medicamento, deberán eliminarse también todas sus dependencias (pedidos).


Formulario Web: ABM de Empleados  Actor Participante: Usuario empleado Resumen: Este formulario permitirá realizar cualquiera de las 3 acciones, a partir del ingreso del nombre de usuario de un empleado. Si el valor ya existe se podrá eliminar o modificar dicho empleado  (previo despliegue de todos sus datos). En caso de que el usuario no exista, se solicitaran todos los datos para generar un nuevo empleado en el repositorio de datos. Tomar en cuenta que el valor ingresado podrá pertenecer a un cliente, y en este formulario no se manejan clientes (se deberá desplegar un mensaje de error acorde).


Formulario Web: Cambio Estado Pedido Actor Participante: Usuario empleado Resumen: Este formulario permite cambiar el estado actual de un pedido. Se deberá desplegar en una grilla, todos los pedidos que estén en estado generado o enviado .  El usuario podrá seleccionar un pedido,  y de forma automática se lo pasara al próximo estado, previa confirmación del cambio. Los estados son: Generado (automático cuando se realiza el pedido), Enviado (cuando se lo entrega al repartidor), y Entregado (cuando el cliente lo recibe).  Tomar en cuenta, que el usuario NO elige el estado para el cambio, se hace automáticamente. Realizada dicha acción, la lista deberá actualizarse.  


Proyecto Final Primer Año Página 3 de 5 Carrera Analista de Sistemas
Formulario Web: Listado de Medicamentos y Pedidos.  Actor Participante: Usuario empleado Resumen: Este formulario permitirá consultar todos los datos de medicamentos y pedidos del sistema. El usuario primero deberá seleccionar una farmacéutica desde un control DropDownList. En una grilla se desplegaran todos los medicamentos de dicha farmacéutica. Seleccionado un medicamento, se desplegaran todos sus pedidos (con todos sus datos), ordenadas cronológicamente. Se podrá filtrar dicha lista de pedidos por: todo s (no importa su estado), solo gene rados , o solo entregados .     


Formulario Web: Registro Cliente  Actor Participante: Publica Resumen: Este formulario solicita los datos necesarios para realizar el registro de un nuevo usuario cliente en el sistema.  


Formulario Web: Realizar un Pedido  Actor Participante: Usuario Cliente Resumen: Este formulario permitirá generar un nuevo pedido. Para ello se deberá poder seleccionar desde una grilla, el medicamento a pedir (solo uno por pedido). La lista de medicamentos deberá estar ordenada por nombre de medicamento.  Cuando el cliente seleccione un medicamento, se deberá desplegar toda su información (incluyendo la farmacéutica que lo produce). El cliente determinara la cantidad que desea pedir, se indicara el costo total del pedido, y podrá confirmar la acción. El usuario cliente actualmente logueado será relacionado al pedido. Por defecto se considera al pedido en estado “ generado ”.  


Formulario Web: Listado de Pedidos Generados – Eliminación Pedido Actor Participante: Usuario Cliente Resumen: Este formulario mostrara en una grilla , la lista de pedidos en estado “ generado ” del usuario cliente actualmente logueado. Si se selecciona uno, se deberán desplegar todos los datos del mismo (incluyendo los datos de medicamento y la farmacéutica que lo produce). Deberá permitírsele al usuario cliente, eliminar dicho pedido. Esta acción elimina el pedido del repositorio de datos.  

   Formulario Web: Consulta Estado Pedido  Actor Participante: público Resumen: En este formulario se podrá ingresar el código de un pedido. En caso de encontrarse (existe en el sistema), se informa de su estado actual.


Nota : todas las páginas no públicas del sistema deberán desplegarse con una Master Page , en la cual se encontrará el menú principal correspondiente al tipo de usuario, un control que despliegue el nombre del usuario logueado y un acceso a desloguearse. Tomar en cuenta que la verificación de permisos deberá realizarse dentro de la MP correspondiente.


Proyecto Final Primer Año Página 4 de 5 Carrera Analista de Sistemas
Requerimientos de Implementación   Implementación completa del sitio web con tecnologías .Net (ASP.NET, ADO.NET), en lenguaje C# para Visual Studio 2010; teniendo el repositorio de datos sobre SQL Server 2008 R2.  El script de la base de datos debe generarse manualmente, sin la ayuda de un asistente. Deberá contener el Esquem a de creación de la base de datos , los Stored Procedures necesarios para realizar todas las tareas solicitadas y la Inserción
 de datos de prueba
  Para el desarrollo del sistema utilizar la arquitectura en 3 capas vista en el curso, mediante la utilización de bibliotecas de clases.   Obligatorio el uso de clases definidas por el usuario para la comunicación de datos e n t r e c o m p o n e n t e s ( t a n t o p a r a i n v o c a c i ó n c o m o r e s p u e s t a ) . Solo se considera crear objetos de dichas clases completos . Además, se deberá genera todo el código defensivo necesario en dichas clases.
  Siempre se deberá de trabajar en forma conectada (ADO.NET) para el manejo de la información de la base de datos; y a través del uso exclusivo de procedimientos almacenados (no se aceptan accesos a base de datos mediante sentencias SQL directas).  Los componentes deberán lanzar excepciones en caso de error. No se contempla otra forma de comunicación de errores entre componentes .  Uso obligatorio de Master Pages para el despliegue del nombre de usuario, acceso rápido a deslogueo, y menú principal al que tiene acceso el usuario actualmente logueado.  No se podrá usar asistentes de ningún tipo. La realización del script mediante asistentes implica cero (0) punto en el proyecto.  La no compilación del script o del sitio web implica cero (0) punto en el proyecto


Requerimientos de Entrega  Solución completa del Software  Script de la base de datos  Modelo Conceptual.  MER   Diagrama de Clases completo de la Arquitectura en capas (incluye a todos los componentes, clases y relaciones entre ellos)


Nota: todos los diagramas deberán ser generados con una herramienta para lenguaje UML. Estos deberán ser entregados en forma digital: una copia del archivo original del diagrama y una copia en formato PDF o JPG



Proyecto Final Primer Año Página 5 de 5 Carrera Analista de Sistemas
Tutorías & Entregas A continuación se detallan las entregas sugeridas para cada sesión:  Primera Sesión (semana del 28/01 al 01/02):  Modelo Conceptual  MER  Capa de Entidades Compartidas  Script (al menos el esquema de la base de datos)  Segunda Sesión (semana del 11/02 al 15/02):  Versión de la aplicación incluyendo, al menos:  Interfaz Gráfica Completa  Mantenimiento de Farmacéuticas – Medicamentos   Tercera Sesión (semana del 25/02 al 01/03):  Versión de la aplicación agregando, al menos:  Mantenimiento de todo tipo de Usuario  Logueo  Alta de Pedidos  Cuarta Sesión1 (semana del 11/03 al 15/03):  Defensa del proyecto  Deberán entregarse todos los elementos descriptos en la sección Requerimientos de Entreg
