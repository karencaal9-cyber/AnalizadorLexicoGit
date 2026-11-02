# **MANUAL DE USUARIO**
## ANALIZADOR LÉXICO
### Aplicación de escritorio desarrollada en C# mediante Windows Forms

Documento de orientación para el usuario final

#### *Versión 2.0  |  2026*

## Control del documento

|           Campo        |         Descripción        |
| :--------------------- | :------------------------- |
|   Nombre del sistema   |      Analizador Léxico     |
|   Tipo de aplicación   |  Aplicación de escritorio  |
|       Tecnología       |  C# / .NET / Windows Forms |
|  Entorno de desarrollo |        Visual Studio       |
|   Tipo de documento    |      Manual de usuario     |
|   Versión del manual   |             1.0            |

## Requisitos para utilizar el sistema

Para trabajar con la aplicación se recomienda disponer de los siguientes elementos:
* Un equipo con sistema operativo Windows.
* La aplicación Analizador Léxico compilada y disponible para su ejecución.
* Un archivo de texto plano (`.txt`) que contenga código escrito con las reglas del subconjunto de lenguaje que reconoce el analizador.
* Permisos de lectura para abrir el archivo de entrada y permisos de escritura en la ubicación donde se guardará el informe.

> **Nota:** El documento del proyecto establece como entrada archivos de texto plano. La compatibilidad con otras extensiones depende de los filtros configurados en el cuadro de diálogo de apertura de archivos.

## Procedimiento de uso

### Iniciar la aplicación
1. Ejecute el archivo de la aplicación o inicie el proyecto desde Visual Studio si se encuentra en el entorno de desarrollo.
2. Espere a que aparezca la ventana principal.
3. Verifique que se muestren los botones **Abrir**, **Analizar** y **Exportar informe**, así como las áreas de resultados.

> *Verificación:* Si la ventana no aparece o el programa se cierra al iniciar, compruebe que la aplicación se haya compilado correctamente y que el equipo cuente con los componentes de .NET requeridos por la versión utilizada.

### Cargar un archivo de código fuente
4. Haga clic en el botón **Abrir**, situado en la parte superior de la ventana.
5. Cuando aparezca el cuadro de diálogo, localice la carpeta donde se encuentra el archivo que desea analizar.
6. Seleccione el archivo de texto con el código fuente.
7. Confirme la selección mediante el botón **Abrir** del cuadro de diálogo.
8. Compruebe que el archivo haya sido aceptado por la aplicación. Si la interfaz muestra el contenido en un área de texto, revise que corresponda al archivo seleccionado.

> **Recomendación:** Utilice inicialmente un archivo pequeño y válido para comprobar el funcionamiento. Evite modificar el archivo original durante el análisis.

### Ejecutar el análisis léxico
9. Después de cargar el archivo, presione el botón **Analizar**.
10. Espere a que el sistema termine de procesar el contenido.
11. Revise la tabla de tokens para consultar los elementos reconocidos y su ubicación.
12. Consulte la tabla inferior para verificar los identificadores que fueron incorporados a la tabla de símbolos.
13. Revise el Panel Estadístico y los contadores para conocer el resumen del proceso.

El análisis léxico debe identificar unidades como palabras reservadas, identificadores, números, cadenas, caracteres, operadores, signos de puntuación y comentarios, siempre que estén incluidos en el lenguaje definido para el proyecto. Los caracteres o secuencias que no correspondan a una categoría válida pueden reportarse como errores léxicos.

## Interpretación de los resultados

### Tabla de tokens
La tabla de tokens permite consultar las unidades léxicas reconocidas durante el procesamiento. Cada fila representa un elemento identificado en el archivo fuente.

| Columna | Significado |
| :--- | :--- |
| **Token** | Categoría o nombre asignado al elemento reconocido. Identifica qué clase de unidad léxica es. |
| **Lexema** | Texto exacto encontrado en el archivo fuente. Por ejemplo, en la instrucción `int edad;`, el lexema `edad` corresponde al nombre del identificador. |
| **Patrón** | Patrón o clasificación asociada al reconocimiento del lexema, según la implementación del analizador. |
| **Fila** | Número de línea en la que comienza el lexema dentro del archivo. |
| **Columna** | Posición de columna donde comienza el lexema, si está habilitada como columna visible en la tabla. |

### Tabla de símbolos
La tabla de símbolos reúne los identificadores detectados durante el análisis. Su finalidad es mantener un registro organizado de nombres utilizados en el código fuente, como variables, funciones o clases, según el alcance definido.

| Columna | Significado |
| :--- | :--- |
| **Identificador** | Nombre del identificador encontrado en el código. |
| **Tipo** | Tipo o clasificación asociada al identificador, cuando la implementación dispone de ese dato. |
| **Primera fila** | Número de la primera línea en la que aparece el identificador. |
| **Primera columna** | Posición de columna de su primera aparición. |

La tabla de símbolos permite consultar la primera ubicación de cada identificador. De acuerdo con los requisitos del proyecto, los identificadores distintos deben almacenarse evitando duplicados.

### Panel estadístico

| Indicador | Interpretación |
| :--- | :--- |
| **Total de Tokens** | Cantidad total de tokens reconocidos durante el análisis. |
| **Total de Líneas** | Cantidad de líneas procesadas del archivo fuente. |
| **Total de errores** | Número de errores léxicos detectados. |
| **Tiempo de Análisis** | Tiempo aproximado que tardó el sistema en procesar el archivo. |
| **Total Símbolos** | Cantidad de identificadores registrados en la tabla de símbolos, según el criterio utilizado por la aplicación. |

Los valores estadísticos se interpretan después de ejecutar el análisis. Si todavía no se ha cargado o analizado un archivo, los campos pueden aparecer vacíos o mostrar valores iniciales.

### Errores léxicos
Un error léxico ocurre cuando una secuencia de caracteres no corresponde a ningún token válido del lenguaje reconocido. Entre los casos que el proyecto contempla se encuentran los caracteres no permitidos, números mal formados y cadenas o comentarios que no se cierran correctamente.

Cuando el sistema presenta un error, se recomienda revisar el carácter o lexema señalado, la línea y la columna indicadas, corregir el código fuente y ejecutar nuevamente el análisis. El diseño del proyecto establece que el analizador debe reportar los errores y continuar procesando el resto del archivo, en lugar de detenerse ante el primero.

> **Importante:** En la captura proporcionada no se distingue un encabezado específico para una tabla de errores. Por tanto, la ubicación exacta de dichos mensajes debe confirmarse en la versión final de la interfaz.

### Exportar el informe
14. Una vez ejecutado el análisis, presione el botón **Exportar informe**.
15. Si aparece un cuadro de diálogo para guardar, seleccione la carpeta de destino.
16. Escriba un nombre descriptivo para el archivo.
17. Seleccione el formato disponible, si la aplicación ofrece más de uno.
18. Presione **Guardar** y espere la confirmación del sistema, si corresponde.

El proyecto contempla la exportación de resultados a un archivo de texto o CSV. El contenido exacto del informe depende de las secciones que la implementación haya incorporado (tokens, errores y/o tabla de símbolos).

## Recomendaciones de uso
* Verifique que el archivo seleccionado contenga código fuente en el subconjunto de lenguaje que reconoce el analizador.
* Guarde una copia del archivo original antes de realizar correcciones.
* Ejecute primero el análisis con un archivo pequeño para comprobar que la carga y el procesamiento funcionan correctamente.
* Revise la ubicación de cada token y error antes de modificar el código.
* Utilice nombres de archivo claros al exportar los informes para facilitar su identificación.
* No cierre la aplicación mientras se está ejecutando el análisis o guardando el informe.
* Si una tabla contiene más columnas de las que caben en pantalla, utilice la barra de desplazamiento horizontal para consultar los datos restantes.

## Solución de problemas frecuentes
| Situación | Posible causa | Acción recomendada |
| :--- | :--- | :--- |
| **No se puede abrir el archivo.** | El archivo no existe, no hay permisos de lectura o el formato no está admitido. | Compruebe la ruta, los permisos y que se trate de un archivo de texto compatible. |
| **La tabla de tokens aparece vacía.** | No se ha cargado un archivo, no se ha ejecutado el análisis o el archivo está vacío. | Cargue un archivo con contenido y presione **Analizar**. |
| **Se muestran errores léxicos.** | El código contiene caracteres o secuencias que no reconoce el lenguaje definido. | Revise el lexema y la ubicación del error; corrija el código y vuelva a analizar. |
| **Las estadísticas no muestran valores.** | El análisis aún no se ha ejecutado o no se actualizaron los indicadores. | Ejecute el análisis y compruebe si la interfaz actualiza los contadores. |
| **No se puede guardar el informe.** | La carpeta no permite escritura o el nombre/ruta no es válido. | Seleccione otra ubicación y utilice un nombre de archivo válido. |
| **La aplicación se cierra inesperadamente.** | Puede existir una excepción no controlada o un problema de ejecución. | Vuelva a iniciar la aplicación y comunique el problema al responsable del desarrollo. |


## Glosario
| Término | Definición |
| :--- | :--- |
| **Analizador léxico** | Componente que examina el código fuente y lo transforma en una secuencia de tokens. |
| **Token** | Unidad léxica reconocida por el analizador, como un identificador, número u operador. |
| **Lexema** | Secuencia concreta de caracteres del archivo que forma un token. |
| **Identificador** | Nombre utilizado para representar variables, funciones, clases u otros elementos nombrados. |
| **Tabla de símbolos** | Estructura que almacena información de los identificadores encontrados. |
| **Error léxico** | Secuencia de caracteres que no corresponde a ningún token válido definido para el lenguaje. |
| **Fila y columna** | Coordenadas que indican la ubicación de un elemento dentro del archivo fuente. |
| **Exportación** | Proceso de guardar los resultados generados por la aplicación en un archivo externo. |

## Consideraciones finales
El Analizador Léxico facilita la revisión inicial de un programa al identificar sus unidades léxicas, registrar los identificadores y presentar estadísticas generales del procesamiento. Para obtener resultados confiables, el usuario debe seleccionar un archivo compatible, ejecutar el análisis y revisar cuidadosamente la información presentada antes de exportarla.

Este manual se elaboró a partir de la interfaz visible en las capturas proporcionadas y de los requisitos funcionales descritos en el documento del proyecto. Los elementos cuya función no puede confirmarse visualmente se señalan expresamente para evitar atribuir al sistema operaciones que no estén verificadas.
