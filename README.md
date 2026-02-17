📊 FinanceManager - Sistema de Gestión de Gastos
================================================

**FinanceManager** es una aplicación monolítica diseñada para el control financiero personal. Permite a los usuarios gestionar categorías, registrar gastos y visualizar análisis presupuestarios mediante gráficos interactivos. El sistema está construido bajo una **Arquitectura en N-Capas** con persistencia en archivos **JSON**.

🏗️ Arquitectura del Sistema
----------------------------

El proyecto sigue una estructura de separación de responsabilidades:

*   **Capa de Presentación (UI):** Web API en .NET 10 y Frontend en React (TypeScript) + Tailwind CSS.
    
*   **Capa de Negocio (BLL):** Lógica de validaciones, cálculos de reportes y control de presupuestos.
    
*   **Capa de Datos (DAL):** Repositorios para lectura/escritura asíncrona en archivos JSON.
    
*   **Capa de Entidades:** Modelos de dominio y DTOs compartidos.
    

🚀 Requisitos Previos
---------------------

Antes de ejecutar el proyecto, asegúrate de tener instalado:

*   SDK de .NET 10
    
*   Node.js (v18 o superior) y npm
    
*   Un entorno compatible
    

🛠️ Instrucciones de Ejecución
------------------------------

### 1\. Clonar y preparar el Frontend

El frontend se compila dentro de la carpeta wwwroot del proyecto Web para funcionar como un monolito.

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   cd webapi/Api.Web/ClientApp  npm install  npm run build   `

### 2\. Ejecutar el Backend (.NET)

Desde la raíz del proyecto de presentación (Api.Web), inicia el servidor:

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   cd ..  dotnet run   `

La aplicación estará disponible en: http://localhost:5000 (o el puerto configurado en launchSettings.json).

📂 Estructura de Persistencia
-----------------------------

Los datos se almacenan automáticamente en la carpeta de salida del proyecto:Api.Web/bin/Debug/net10.0/

*   categories.json: Almacena el mantenimiento de categorías.
    
*   spends.json: Almacena los registros de gastos.
    

✅ Funcionalidades Principales
-----------------------------

*   **Gestión de Categorías:** CRUD completo con validación de nombres duplicados.
    
*   **Control de Gastos:** Registro con validación de montos y fecha automática.
    
*   **Dashboard Estadístico:** Gráfico de pastel por categorías y medidores de presupuesto restante (Gauges).
    
*   **Alertas de Presupuesto:** Notificaciones visuales cuando una categoría excede su límite mensual.
    
*   **Exportación:** Generación de resúmenes mensuales en formato JSON descargable.
    

🛠️ Tecnologías Utilizadas
--------------------------

*   **Backend:** C#, ASP.NET Core Web API, System.Text.Json.
    
*   **Frontend:** React 18, TypeScript, Tailwind CSS v4, Chart.js.
    
*   **Persistencia:** FileSystem (JSON).
    

### Notas de Entrega

*   El sistema crea automáticamente la carpeta Storage si no existe al iniciar.
    
*   No se permiten eliminar categorías que tengan gastos asociados (Integridad referencial).
    
*   Los cálculos de porcentajes y resúmenes se realizan exclusivamente en la **BLL**.