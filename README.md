# 📦 Proveedores.API


API REST para la gestión de proveedores, desarrollada como parte de una prueba técnica para el rol de desarrollador backend .NET.

---

## 📌 Requisitos de la prueba

| Requisito                                 | Estado    |
|-------------------------------------------|-----------|
| .NET 6                                     | ✅ Cumplido |
| C# + Entity Framework                     | ✅ Cumplido (adaptado con MongoDB) |
| Documentación con Swagger                 | ✅ Cumplido |
| Autenticación JWT                         | ✅ Cumplido |
| Contenerización con Docker                | ✅ Cumplido |
| Base de datos MongoDB                     | ✅ Cumplido |
| Pruebas unitarias e integración           | ✅ Cumplido |
| Arquitectura limpia + patrón de diseño    | ✅ Cumplido |

---

## 🛠️ Tecnologías utilizadas

- ASP.NET Core 6
- MongoDB como base de datos (reemplazo de EF por decisión técnica)
- JWT para autenticación
- Docker y Docker Compose
- xUnit + Moq + FluentAssertions para testing
- Swagger (Swashbuckle)
- Arquitectura limpia + patrón de repositorio

---

## 📐 Arquitectura

El proyecto sigue los principios de **Clean Architecture** y está dividido en las siguientes capas:

- `Domain`: Entidades del dominio
- `Application`: Lógica de negocio y contratos (interfaces, DTOs)
- `Infrastructure`: Implementaciones de acceso a datos (MongoDB)
- `API`: Controladores, configuración, autenticación y startup

---

## 🧪 Pruebas

- **Unitarias**: pruebas de la lógica del servicio de proveedores (`ProveedorService`)
- **Integración**: pruebas reales contra la API (`POST` + `GET` con autenticación JWT)
- Herramientas: `xUnit`, `Moq`, `Microsoft.AspNetCore.Mvc.Testing`, `FluentAssertions`

---

## 🔐 Autenticación

La API está protegida con JWT. Para autenticarte:

1. Hacer un `POST` a `/api/Auth/login` con:

```json
{
  "username": "admin",
  "password": "admin123"
}
```

2. Copiar el token y usarlo en Swagger con el botón Authorize:
Bearer eyJhbGciOiJIUzI1NiIs...

3. 📦 Docker
🔧 Requisitos
Tener Docker Desktop instalado

▶️ Instrucciones
docker-compose up --build
Esto levantará:

MongoDB (localhost:27017)

API (http://localhost:5000)

Swagger (http://localhost:5000/swagger)

📬 Endpoints principales
Método	Endpoint	Descripción
POST	/api/Auth/login	Autenticación JWT
GET	/api/Proveedores	Obtener todos los proveedores
GET	/api/Proveedores/{id}	Obtener proveedor por ID
POST	/api/Proveedores	Crear proveedor
PUT	/api/Proveedores/{id}	Actualizar proveedor
DELETE	/api/Proveedores/{id}	Eliminar proveedor

🧾 Ejemplo de proveedor
``` json
{
  "nit": "123456789",
  "razonSocial": "Proveedor Ejemplo",
  "direccion": "Calle 123 #45-67",
  "ciudad": "Bogotá",
  "departamento": "Cundinamarca",
  "correo": "proveedor@ejemplo.com",
  "activo": true,
  "fechaCreacion": "2025-05-01T00:00:00Z",
  "nombreContacto": "Carlos Pérez",
  "correoContacto": "carlos@ejemplo.com"
}
```
🧠 Notas adicionales
El repositorio incluye archivo docker-compose.yml y Dockerfile para facilitar la ejecución del entorno completo.

La documentación Swagger está enriquecida con comentarios XML para claridad.
🚀 Autor
Santiago N.S.
Prueba técnica para desarrollador backend .NET



