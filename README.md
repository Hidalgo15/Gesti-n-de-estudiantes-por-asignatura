# Gestión de Estudiantes por Asignatura

![C#](https://img.shields.io/badge/C%23-.NET%208.0-blueviolet)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20%2F%20Onion-blue)
![Academic](https://img.shields.io/badge/Status-Penultimate%20Semester%20Project-orange)

## 📖 Descripción del Proyecto
Este sistema es una solución de software orientada a objetos diseñada para que los docentes universitarios gestionen el control de asistencia, asignaturas, secciones y procesamiento de calificaciones académicas de los estudiantes en sus respectivas modalidades (Presencial y A Distancia). 

La aplicación destaca por operar **completamente en memoria** mediante colecciones genéricas y estructurarse bajo los principios de **Clean Architecture (Onion Architecture)**, garantizando un desacoplamiento absoluto de las reglas de negocio frente a la infraestructura o la interfaz de usuario.

---

## 🏛️ Arquitectura del Sistema (Onion Layers)

El proyecto se encuentra estrictamente organizado según el explorador de soluciones en las siguientes capas de abstracción:

* **`Core/Domain` (Núcleo de Entidades):** Alberga los objetos del dominio, lógica pura de negocio y contratos. Contiene la clase abstracta fundamental `Estudiante` y sus derivaciones polimórficas (`EstudiantePresencial` y `EstudianteDistancia`), encapsulando sus propios métodos de cálculo de promedio.
* **`Core/Application` (Casos de Uso):** Orquesta el flujo de control y expone los servicios intermedios (como `AsignaturaService`) encargados de interactuar con el dominio y mantener el estado volátil de la aplicación.
* **`Presentation` (Interfaz de Usuario):** Contiene el hilo de ejecución principal y la interfaz de consola orientada al usuario (`MenuConsole`), la cual captura las entradas directas por teclado e interactúa defensivamente con los servicios.

---

## 🛠️ Pilares de Programación Orientada a Objetos Aplicados

1.  **Herencia y Clases Derivadas:** Se definió una superclase base `Estudiante` que unifica los atributos comunes (Matrícula, Nombre y Listas de Notas). De ella nacen especializaciones funcionales obligatorias para cada modalidad de estudio.
2.  **Polimorfismo Dinámico (`Override`):** Cada modalidad computa su promedio de forma diferenciada en tiempo de ejecución al invocar el método abstracto `CalcularNotaFinal()`:
    * **Estudiante Presencial:** Ponderación fija de 70% Exámenes y 30% Prácticas.
    * **Estudiante A Distancia:** Ponderación fija de 40% Exámenes y 60% Entregables/Proyectos.
3.  **Encapsulamiento Estricto:** Los estados de las propiedades críticas utilizan modificadores de acceso restrictivos (`private set` / `protected set`), impidiendo la mutabilidad corrupta de datos desde capas externas sin pasar por los canales lógicos de validación.
4.  **Patrón de Respuesta Defensivo (`OperationResult`):** Todas las operaciones críticas de inserción y búsqueda retornan una estructura unificada compuesta por un indicador de éxito (`Success`), un mensaje descriptivo (`Message`) y los datos resultantes (`Data dynamic`), eliminando la propagación de excepciones en crudo.

---

## 📊 Flujo Lógico: Algoritmo de Cálculo de Promedio

El procesamiento de las calificaciones y promedios aritméticos implementado en los servicios sigue de manera estricta el siguiente flujo algorítmico de control:

1.  **Inicialización:** Se instancia un objeto de transferencia de datos de entrada (`EntradaNumerosDTO`).
2.  **Lectura Cíclica:** Se capturan secuencialmente los valores numéricos por teclado hasta detectar el flag de ruptura (`Entrada == 0`).
3.  **Validación Defensiva:** Antes de realizar la operación aritmética de división, el sistema evalúa si la cantidad de registros en la lista es igual a cero (`Cantidad de número == 0`), evitando errores de desbordamiento o división por cero en el procesador.
4.  **Cálculo e Impresión:** Si existen registros válidos, ejecuta la sumatoria total, calcula el promedio ponderado y despliega el reporte analítico por pantalla.

---

## 📋 Requisitos del Entorno
* **Entorno de Ejecución:** .NET SDK 8.0 o superior.
* **IDE Recomendado:** Visual Studio 2022 o VS Code.
* **Lenguaje:** C# 12.

---

## 🚀 Instrucciones de Ejecución

1. Clona este repositorio en tu máquina local:
   ```bash
   git clone [https://github.com/tu-usuario/gestion-estudiantes-asignatura.git](https://github.com/tu-usuario/gestion-estudiantes-asignatura.git)
