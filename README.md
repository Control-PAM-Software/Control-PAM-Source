# CONTROL PAM - Sistema de Gestión Operativa

Bienvenido al repositorio central de **Control PAM**. Este software ha sido diseñado para centralizar y optimizar los procesos operativos y de gestión de datos de la empresa.

---

## 🚀 Guía de Instalación para Usuarios

Para asegurar el correcto funcionamiento de la aplicación en entornos Windows, siga estos pasos:

### 1. Requisitos Previos (Indispensables)
Antes de ejecutar la aplicación, su sistema debe contar con el entorno de ejecución de .NET 8. Sin esto, la aplicación no podrá iniciar.

* **Runtime:** [.NET Desktop Runtime 8.0 (Windows x64)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* **Sistema Operativo:** Windows 10 (versión 1809) o superior / Windows 11.

---

## 💼 Documentación del Negocio

Control PAM integra múltiples reglas de negocio para estandarizar la operativa de la empresa. A continuación, se detallan las funcionalidades principales:

## 💼 Documentación del Negocio

Control PAM actúa como un puente de inteligencia operativa entre la carga física y los sistemas digitales. El software está estructurado en los siguientes módulos clave:

### Módulos del Sistema

* **📥 Ingreso (Control de Importaciones):**
  Módulo dedicado a la validación de mercadería entrante. Asegura de forma automatizada que los productos físicos recibidos coincidan exactamente con las órdenes de importación y documentos esperados, reduciendo errores humanos en la recepción.
* **📦 Inventario (Conciliación Automática):**
  Herramienta de alta velocidad para el proceso de conteo. Identifica automáticamente las diferencias entre el **stock físico** relevado y el stock informado por el sistema de gestión **Open Orange**, permitiendo una auditoría inmediata y precisa.
* **🚚 Movimientos (Logística de Salida):**
  Optimización del desglose de movimientos internos. Este módulo agiliza el proceso de picking y despacho, facilitando el envío rápido y sin errores hacia los distribuidores autorizados.
* **🏁 Trazabilidad QR:**
  Generación de identificadores únicos para cada activo o bulto, permitiendo un seguimiento integral mediante el motor de códigos QR.

> [!IMPORTANT]
> **Manual de Procedimientos:**
> Puede consultar el instructivo detallado de uso y reglas de negocio en el siguiente enlace:
> **[📥 Descargar Manual de Operaciones (PDF)](https://docs.google.com/document/d/1XxrMVUxnAqO5_JTmW8_ez16MiKe5a5l2O9w7Zzh8KG0/edit?usp=sharing)**

---

## 🛠 Información Técnica (Desarrolladores)

Este proyecto está desarrollado bajo el stack de **.NET 8.0** con arquitectura WinForms.

### Tecnologías y Librerías (NuGet)
* **ClosedXML / ExcelDataReader:** Motor de procesamiento de archivos Excel.
* **HtmlAgilityPack:** Parseo y validación de contenido HTML.
* **Newtonsoft.Json:** Gestión de configuración y comunicación con el actualizador.
* **QRCoder:** Motor de generación de códigos QR.

### Compilación Local
1. Clonar el repositorio privado.
2. Abrir `Control.sln` en **Visual Studio 2022**.
3. Restaurar paquetes NuGet e iniciar la depuración (F5).

---

## 🌳 Flujo de Trabajo (Git Flow)

Para mantener la estabilidad de **CONTROL PAM**, utilizamos un sistema de ramas basado en funcionalidades. Ningún desarrollador debe realizar commits directamente sobre `main`.

### Estructura de Ramas
* **`main`**: Solo código estable y testeado. Es la rama de producción.
* **`develop`**: Rama de integración. Aquí se unen todas las nuevas funcionalidades antes de pasar a main.
* **`feature/nombre-tarea`**: Ramas temporales para desarrollar nuevas características o corregir errores.

---

### 🛠 Comandos Básicos y Ciclo de Vida

Cada vez que comiences una nueva tarea, seguí este flujo:

#### 1. Crear una nueva funcionalidad
Primero, asegúrate de tener lo último del equipo y crea tu rama:
```bash
git checkout develop
git pull origin develop
git checkout -b feature/nombre-de-tu-tarea
```

#### 2. Guardar cambios (Commits)
Realizá commits pequeños y descriptivos mientras trabajás:

```bash
git add nombre-de-archivo-modificado
git commit -m "Explicación breve de lo que hiciste"
git push origin feature/nombre-de-tu-tarea
```

#### 3. Integración (Merge)
Una vez finalizada y testeada la tarea localmente:

1. Subí tu rama a GitHub.
2. Abrí un Pull Request (PR) desde GitHub hacia la rama develop.
3. Una vez aprobado el PR, eliminá la rama feature/ para mantener el orden.

#### 4. Actualizar tu rama con cambios de otros
Si un compañero subió algo a develop y lo necesitás:

```bash
git checkout feature/nombre-de-tu-tarea
git merge develop
```

> [!WARNING]
> **Regla de Oro:** Nunca hagas push a main directamente. Los pasos a main solo se realizan mediante Pull Requests desde develop al finalizar un hito de versión (ej. v5.4.2).

© 2026 Control PAM - Todos los derechos reservados.