Proyecto realizado para cumplir con la prueba técnica para el puesto Mid .Net de Keylin Hidalgo Barrios.

Tecnologías utilizadas:

-Javascript (jquery, ajax)
-Json
-HTML
-C# Asp.Net MVC 4
-Microsoft visual studio 2012
-Microsoft Sql server 2008
-Enterprise Library 5.0


INSTRUCCIONES:

1)
Para la base de datos, se adjunta un script de generación en la ruta '..\prueba_keilyn\Script base de datos.sql' que creará lo siguiente:
-Base de datos
-Tabla
-Inserción de un registro.
-Procedimiento almacenado.


2)
Para poder acceder al código del proyecto, el visual studio debe tener instalado el C# Asp.Net MVC 4. Para el visual studio 2010, el MVC 4
se puede descargar en la ruta http://www.asp.net/mvc/mvc4


3)
Para realizar la conexión a la base de datos desde la aplicación, debe ingresar al archivo Web.config ubicado en el proyecto 
..\prueba_keilyn\PruebaTecnicaKeylinHidalgo\AutenticacionUsuario y cambiar el Connection String localizado en la key llamada
SQLConectionString. El nuevo valor debe corresponder al conecction string de la base de datos en su máquina.


4)
El usuario con el que se puede realizar las pruebas a la aplicación es 
Id: 'khidalgo' 
Password: '123'
No obtante, usted puede realizar una nueva inserción de un perfil directamente a la base de datos o bien cambiando los
datos en el script '..\prueba_keilyn\Script base de datos.sql' en la sección 'INSERCIÓN DE UN PERFIL' y ejecutando este segmento.





NOTA: se adjuntan imágenes del proyecto en funcionamiento, en la ruta '..\prueba_keilyn\Imagenes proyecto'