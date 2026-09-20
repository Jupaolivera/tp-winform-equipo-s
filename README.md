# Sistema de Gestión de Artículos - Documentación y Guía Rápida

Este documento contiene las instrucciones necesarias para configurar el entorno de desarrollo y una guía rápida para el manejo de la aplicación.

## 🔧 1. Configuración y Conexión a la Base de Datos

Si al iniciar la aplicación por primera vez ocurre un error de conexión, es muy probable que la cadena de conexión esté apuntando a un servidor SQL distinto al de tu computadora. 

**Cómo solucionarlo:**

1. En Visual Studio, ve al Explorador de soluciones y abre el archivo **`App.config`**.
2. Busca la etiqueta `<connectionStrings>`.
3. Asegúrate de que el valor `server=` coincida con tu instancia local. 
   * Si usas **SQL Server LocalDB** (por defecto en Visual Studio), la línea debe quedar exactamente así:
     ```xml
     <add name="CatalogoDB" connectionString="server=(localdb)\MSSQLLocalDB;database=CATALOGO_P3_DB;integrated security=true" providerName="System.Data.SqlClient" />
     ```
   * Si usas **SQL Server Express**, el servidor probablemente deba ser `server=localhost\SQLEXPRESS` o `server=.\SQLEXPRESS`.

> **Nota:** Asegúrate de haber ejecutado el script `.sql` en tu SQL Server Management Studio para crear la base de datos `CATALOGO_P3_DB` y sus tablas antes de iniciar el programa.

---

## 🖼️ 2. Guía para Agregar Imágenes por URL

El sistema utiliza enlaces (URLs) alojados en internet para mostrar las fotos de los artículos. 

**Cómo obtener el enlace correcto:**
Haz clic derecho sobre la foto que deseas utilizar en tu navegador web y selecciona **"Copiar dirección de la imagen"** (o "Copy image address"). Luego, pega ese enlace en el sistema.

**Formatos Compatibles:**
.jpg` / `.jpeg`
.png`
.gif`
.bmp`

**Formatos y Enlaces NO Soportados (Dejarán el recuadro en blanco):**
Enlaces indirectos (por ejemplo, links que abren un visor de Google Drive, álbumes de Imgur, o pines de Pinterest).
Formatos modernos de compresión web como **`.webp`**, **`.avif`** o **`.heic`**.
ormatos vectoriales como **`.svg`**.
Imágenes codificadas en Base64 (URLs que comienzan con `data:image/...`).
Imágenes de sitios que bloquean descargas externas o requieren inicio de sesión.

---

Guía Rápida de Uso

Pantalla Principal:** Muestra la grilla completa con todos los artículos activos en la base de datos.
<img width="852" height="249" alt="image" src="https://github.com/user-attachments/assets/2ecfb073-1587-4312-ae69-945dde649383" />

* **Agregar Artículo:** Abre el formulario para ingresar código, nombre, descripción, precio y seleccionar la marca y categoría
<img width="412" height="183" alt="image" src="https://github.com/user-attachments/assets/833c6849-d9fc-4b78-9fcc-94c83814e4d9" />

Modificar Artículo:** Selecciona un renglón en la grilla y haz clic en "Modificar" para editar sus datos. Dentro de esta ventana también podrás **gestionar las imágenes**, permitiendo agregar múltiples URLs o quitar las existentes.
  <img width="610" height="359" alt="image" src="https://github.com/user-attachments/assets/37f9bca2-9f07-4ca8-be8a-121657955ee1" />

Detalle:** Abre una ventana de solo lectura para revisar la ficha completa del producto y navegar por la galería de sus imágenes.
  <img width="503" height="234" alt="image" src="https://github.com/user-attachments/assets/3894ab5e-50eb-4c9a-85ab-989b3cbc4352" />

Buscar:** Permite filtrar rápidamente la lista de artículos mostrados en la grilla principal.
  <img width="664" height="273" alt="image" src="https://github.com/user-attachments/assets/2a521778-9637-4229-8b5f-388b8baada6f" />

Mantenimiento:** Desde el menú superior, puedes acceder a la gestión de Marcas y Categorías para dar de alta nuevos rubros o editar los existentes de forma independiente.
<img width="144" height="65" alt="image" src="https://github.com/user-attachments/assets/df1fde2e-b138-4c48-ab9a-d07833e20996" />
